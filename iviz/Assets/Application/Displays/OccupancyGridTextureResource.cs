using System;
using BigGustave;
using Iviz.Controllers;
using Iviz.Core;
using Iviz.Resources;
using JetBrains.Annotations;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Iviz.Displays
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(MeshRenderer))]
    public class OccupancyGridTextureResource : MarkerResourceWithColormap
    {
        static Texture2D atlasLarge;

        static Texture2D AtlasLarge => (atlasLarge != null)
            ? atlasLarge
            : atlasLarge = UnityEngine.Resources.Load<Texture2D>("Materials/atlas-large");
        
        static Texture2D atlasLargeFlipped;

        static Texture2D AtlasLargeFlipped => (atlasLargeFlipped != null)
            ? atlasLargeFlipped
            : atlasLargeFlipped = UnityEngine.Resources.Load<Texture2D>("Materials/atlas-large-flip");

        static readonly int AtlasTex = Shader.PropertyToID("_AtlasTex");

        [SerializeField] Texture2D texture = null;
        Material material;
        [NotNull] sbyte[] buffer = Array.Empty<sbyte>();
        uint? previousHash;

        [CanBeNull] MeshRenderer meshRenderer;

        [NotNull]
        MeshRenderer MeshRenderer => meshRenderer != null ? meshRenderer : meshRenderer = GetComponent<MeshRenderer>();

        public bool IsProcessing { get; private set; }
        
        public int NumValidValues { get; private set; }

        public override Vector2 IntensityBounds
        {
            get => default;
            set { }
        }

        bool newFlipMinMax;

        public override bool FlipMinMax
        {
            get => newFlipMinMax;
            set
            {
                newFlipMinMax = value;
                material.SetTexture(AtlasTex, value ? AtlasLargeFlipped : AtlasLarge);
            }
        }
        
        protected override void Awake()
        {
            material = Resource.Materials.OccupancyGridTexture.Instantiate();
            
            MeshRenderer.sharedMaterial = material;

            base.Awake();
            Colormap = Resource.ColormapId.hsv;
            FlipMinMax = false;
        }

        void EnsureSize(int sizeX, int sizeY)
        {
            if (texture != null)
            {
                if (texture.width == sizeX && texture.height == sizeY)
                {
                    return;
                }

                Destroy(texture);
            }

            texture = new Texture2D(sizeX, sizeY, TextureFormat.R8, true)
            {
                name = "OccupancyGrid Texture",
                filterMode = FilterMode.Point,
                wrapMode = TextureWrapMode.Clamp,
            };
            material.mainTexture = texture;
        }

        public void Set([NotNull] sbyte[] values, float cellSize, int numCellsX, int numCellsY,
            OccupancyGridResource.Rect? inBounds = null)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            IsProcessing = true;

            var bounds = inBounds ?? new OccupancyGridResource.Rect(0, numCellsX, 0, numCellsY);
            int segmentWidth = bounds.Width;
            int segmentHeight = bounds.Height;

            float totalWidth = segmentWidth * cellSize;
            float totalHeight = segmentHeight * cellSize;


            int totalTextureSize = CalculateAllMipmapsSize(segmentWidth, segmentHeight);
            if (buffer.Length != totalTextureSize)
            {
                buffer = new sbyte[totalTextureSize];
            }

            (uint hash, int numValidValues) = Process(values, bounds, numCellsX, buffer);
            NumValidValues = numValidValues;

            if (previousHash == null)
            {
                previousHash = hash;
            }
            else if (hash == previousHash)
            {
                IsProcessing = false;
                return;
            }

            previousHash = hash;
            if (numValidValues == 0)
            {
                GameThread.PostImmediate(() =>
                {
                    Visible = false;
                    IsProcessing = false;
                });
                
                return;
            }

            CreateMipmaps(buffer, segmentWidth, segmentHeight);

            GameThread.PostImmediate(() =>
            {
                Visible = true;

                Transform mTransform = transform;
                //Vector3 rosCenter = new Vector3(width / 2 - cellSize / 2, height / 2 - cellSize / 2, 0);
                Vector3 rosCenter =
                    new Vector3(bounds.XMax + bounds.XMin - 1, bounds.YMax + bounds.YMin - 1, 0) * (cellSize / 2);
                mTransform.localPosition = rosCenter.Ros2Unity();
                mTransform.localRotation = Quaternion.Euler(0, 90, 0);
                mTransform.localScale = new Vector3(totalHeight, totalWidth, 1).Ros2Unity().Abs() * 0.1f;

                EnsureSize(segmentWidth, segmentHeight);
                texture.GetRawTextureData<sbyte>().CopyFrom(buffer);
                texture.Apply(false);
                IsProcessing = false;
            });
        }

        static unsafe (uint hash, int numValidValues)
            Process(sbyte[] src, OccupancyGridResource.Rect bounds, int pitch, sbyte[] dest)
        {
            Crc32Calculator crc32 = Crc32Calculator.Instance;
            uint hash = Crc32Calculator.DefaultSeed;
            long numValidValues = 0;

            fixed (sbyte* dstPtr0 = dest, srcPtr0 = src)
            {
                sbyte* dstPtr = dstPtr0;
                for (int v = bounds.YMin; v < bounds.YMax; v++)
                {
                    sbyte* srcPtr = srcPtr0 + v * pitch + bounds.XMin;
                    for (int u = bounds.XMin; u < bounds.XMax; u++, srcPtr++, dstPtr++)
                    {
                        *dstPtr = *srcPtr;
                        hash = crc32.Update(hash, (byte) *srcPtr);
                        numValidValues += (*srcPtr >> 8) + 1;
                    }
                }
            }

            return (hash, (int) numValidValues);
        }

        void OnDestroy()
        {
            if (texture != null)
            {
                Destroy(texture);
            }

            if (material != null)
            {
                Destroy(material);
            }
        }

        protected override void Rebuild()
        {
            // not needed
        }

        protected override void UpdateProperties()
        {
            MeshRenderer.SetPropertyBlock(Properties);
        }

        static unsafe void CreateMipmaps(sbyte[] array, int width, int height)
        {
            fixed (sbyte* srcPtr = array)
            {
                sbyte* srcMipmap = srcPtr;
                while (width > 1 && height > 1)
                {
                    Reduce(srcMipmap, width, height, srcMipmap + width * height);
                    srcMipmap += width * height;
                    width /= 2;
                    height /= 2;
                }
            }
        }

        static int CalculateAllMipmapsSize(int width, int height)
        {
            int size = 0;
            while (width > 0 && height > 0)
            {
                size += width * height;
                width /= 2;
                height /= 2;
            }

            return size;
        }

        
        static unsafe void Reduce(sbyte* src, int width, int height, sbyte* dst)
        {
            for (int v = 0; v < height; v += 2)
            {
                sbyte* row0 = src + width * v;
                sbyte* row1 = row0 + width;
                for (int u = 0; u < width; u += 2, row0 += 2, row1 += 2, dst++)
                {
                    int a = row0[0];
                    int b = row0[1];
                    int c = row1[0];
                    int d = row1[1];
                    *dst = (sbyte) Fuse(a, b, c, d);
                }
            }
        }

        static int Fuse(int a, int b, int c, int d)
        {
            int signA = ~a >> 8; // a >= 0 ? -1 : 0
            int signB = ~b >> 8; // b >= 0 ? -1 : 0
            int signC = ~c >> 8; // c >= 0 ? -1 : 0
            int signD = ~d >> 8; // d >= 0 ? -1 : 0

            int numValid = -(signA + signB + signC + signD);
            if (numValid <= 1)
            {
                return -1;
            }

            int valueA = a & signA; // a >= 0 ? a : 0
            int valueB = b & signB; // b >= 0 ? b : 0
            int valueC = c & signC; // c >= 0 ? c : 0
            int valueD = d & signD; // d >= 0 ? d : 0

            int sum = valueA + valueB + valueC + valueD;
            switch (numValid)
            {
                case 2:
                    return sum >> 1; // sum / 2
                case 3:
                    return (sum * 21845) >> 16; // sum * (65536/3) / 65536
                default:
                    return sum >> 2; // sum / 4
            }
        }
    }
}