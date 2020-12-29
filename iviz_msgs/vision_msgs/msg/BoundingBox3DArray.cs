/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.VisionMsgs
{
    [DataContract (Name = "vision_msgs/BoundingBox3DArray")]
    public sealed class BoundingBox3DArray : IDeserializable<BoundingBox3DArray>, IMessage
    {
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        [DataMember (Name = "boxes")] public VisionMsgs.BoundingBox3D[] Boxes { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public BoundingBox3DArray()
        {
            Header = new StdMsgs.Header();
            Boxes = System.Array.Empty<VisionMsgs.BoundingBox3D>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public BoundingBox3DArray(StdMsgs.Header Header, VisionMsgs.BoundingBox3D[] Boxes)
        {
            this.Header = Header;
            this.Boxes = Boxes;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public BoundingBox3DArray(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            Boxes = b.DeserializeArray<VisionMsgs.BoundingBox3D>();
            for (int i = 0; i < Boxes.Length; i++)
            {
                Boxes[i] = new VisionMsgs.BoundingBox3D(ref b);
            }
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new BoundingBox3DArray(ref b);
        }
        
        BoundingBox3DArray IDeserializable<BoundingBox3DArray>.RosDeserialize(ref Buffer b)
        {
            return new BoundingBox3DArray(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            Header.RosSerialize(ref b);
            b.SerializeArray(Boxes, 0);
        }
        
        public void RosValidate()
        {
            if (Header is null) throw new System.NullReferenceException(nameof(Header));
            Header.RosValidate();
            if (Boxes is null) throw new System.NullReferenceException(nameof(Boxes));
            for (int i = 0; i < Boxes.Length; i++)
            {
                if (Boxes[i] is null) throw new System.NullReferenceException($"{nameof(Boxes)}[{i}]");
                Boxes[i].RosValidate();
            }
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += Header.RosMessageLength;
                size += 80 * Boxes.Length;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "vision_msgs/BoundingBox3DArray";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "9e1a3932308592aa1b20232d818486db";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAE71WwW7cRgy96ysI+GC7WG+AuMjBQA8NFml9KOoiQS9FYXAlrjSNNLPhjHatfH0fRyvZ" +
                "Qp20h8YLAStpyEe+Rw5HMVX3Xazjq5+FK1Fq8l9xcNEFP668Db2vnK/fhofrzR9/0jY8SCx++J9/xS/v" +
                "f7qhuEynOKP3iX3FWlEniStOTLuANF3diF61cpAWTtztpaK8moa9xDUcPzQuEq5avCi37UB9hFEKVIau" +
                "670rOQkl18nCH57OE9OeNbmyb1lhHxQCmPlOuRNDxxXlUy++FLrd3MDGRyn75JDQAIRShSNEwyIVvfPp" +
                "+rU5FGcfjuEKj1JD7Dk4pYaTJSsPe5VoeXK8QYzvRnJrYEMcQZQq0kV+d4/HeEkIghRkH8qGLpD53ZCa" +
                "4AEodGB1vG3FgEsoANRzczq/fILsM7RnHyb4EfExxn+B9TOucbpqULPW2Me+hoAw3Gs4uAqm2yGDlK0T" +
                "n6h1W2UdCvMaQxZn70xjGMErVwT/HGMoHQpQ0dGlpohJDT1X495VxTfqxi/uAvD8ka432ArjS9sTYw1L" +
                "9rQV2ofoEnytkL4iDSknz3BAnROEA3t0wMUb2vz6znTbQAFv4SKF3cjeQFnF+hHNLxpXGYxRor5sVsCh" +
                "jgcL17lac4AUAEUwCxBZ0cTlR65llR3MsZYAKB0yp5UhWzF2feoVbZ13jRixKf8cMKjVivNzzk2WxEcu" +
                "xQL71R36aVo54Ub3WZ4DWD1lGHvVac0Mw/YvKdP5pFimh+yQ7TLe77AKep2DfKt++CfD3AgqtmmfSmQJ" +
                "GqmdCmijCigBpo69rk7rz8q7puIuYDrMBsVvPeqqPuM+2r0UQaQyTVLMhsQO3WlFmfMHF4zKnPKCbrFr" +
                "A6c339PDfDfMd59fJv1H6SYOc6EwURZ6LpO3p0+PuuO86bA3vs5ouju+DLdTtz9HjA55bUlpbQfWbT5i" +
                "gscB1QmjZDgLZ084Vk7hmtsQ21UFxCVPmSpIJIwUYHT8EZCYVGLevN8DDIeuso/tKCVew+VC1vV6RcdG" +
                "/Ghl+zmfrvk8diWpq101eprCszPTidyK0u415n3bjjmPwdB+AMkDFQ6Xa7rd0RB6Ohoh3OjpMyDYXJzy" +
                "ysdVCmFl3wAniGd6HbLEiHkJ7WLCB8i/Vv1vdVxpJD4JAAA=";
                
    }
}