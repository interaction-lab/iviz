/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/Touch")]
    public sealed class Touch : IDeserializable<Touch>, IMessage
    {
        // true means touched
        // [FRONT_LEFT, LEFT, REAR_LEFT, CENTER, FRONT, REAR_RIGHT, RIGHT, FRONT_RIGHT]
        [DataMember (Name = "electrodes")] public bool[] Electrodes { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Touch()
        {
            Electrodes = System.Array.Empty<bool>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public Touch(bool[] Electrodes)
        {
            this.Electrodes = Electrodes;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Touch(ref Buffer b)
        {
            Electrodes = b.DeserializeStructArray<bool>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Touch(ref b);
        }
        
        Touch IDeserializable<Touch>.RosDeserialize(ref Buffer b)
        {
            return new Touch(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.SerializeStructArray(Electrodes, 0);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Electrodes is null) throw new System.NullReferenceException(nameof(Electrodes));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += 1 * Electrodes.Length;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/Touch";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "45f8d1c4c44dcc7ee376d119a02375bb";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAClNWKCkqTVXITU3MK1YoyS9NzkhN4VJWiHYL8vcLifdxdQvRUYCQQa6OQVABZ1e/ENcg" +
                "HQWwIqhMkKe7B4gNoSDawZxYrqT8/JzoWIXUnNTkkqL8lNRiLl4uAD1SM014AAAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
