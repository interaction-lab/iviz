using JetBrains.Annotations;
using UnityEngine;

namespace Iviz.Displays
{
    /// <summary>
    /// Marker resource that does nothing. Attached as a last resort to a loaded asset.
    /// </summary>
    public sealed class AssetWrapperResource : MarkerResource
    {
        protected override void Awake()
        {
            BoxCollider = null;
        }
        
        public override int Layer
        {
            get => base.Layer;
            set
            {
                base.Layer = value;
                SetLayer(transform, value);
            }
        }

        static void SetLayer([NotNull] Transform transform, int layer)
        {
            transform.gameObject.layer = layer;
            for (int i = 0; i < transform.childCount; i++)
            {
                SetLayer(transform.GetChild(i), layer);
            }
        }
    }
}