/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayfieldMsgs
{
    [Preserve, DataContract (Name = "mayfield_msgs/KeyValueArray")]
    public sealed class KeyValueArray : IDeserializable<KeyValueArray>, IMessage
    {
        [DataMember (Name = "key_values")] public KeyValue[] KeyValues { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public KeyValueArray()
        {
            KeyValues = System.Array.Empty<KeyValue>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public KeyValueArray(KeyValue[] KeyValues)
        {
            this.KeyValues = KeyValues;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public KeyValueArray(ref Buffer b)
        {
            KeyValues = b.DeserializeArray<KeyValue>();
            for (int i = 0; i < KeyValues.Length; i++)
            {
                KeyValues[i] = new KeyValue(ref b);
            }
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new KeyValueArray(ref b);
        }
        
        KeyValueArray IDeserializable<KeyValueArray>.RosDeserialize(ref Buffer b)
        {
            return new KeyValueArray(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.SerializeArray(KeyValues, 0);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (KeyValues is null) throw new System.NullReferenceException(nameof(KeyValues));
            for (int i = 0; i < KeyValues.Length; i++)
            {
                if (KeyValues[i] is null) throw new System.NullReferenceException($"{nameof(KeyValues)}[{i}]");
                KeyValues[i].RosValidate();
            }
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                foreach (var i in KeyValues)
                {
                    size += i.RosMessageLength;
                }
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mayfield_msgs/KeyValueArray";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "cefc47b26ef37767a965df2b47d24771";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACvNOrQxLzClNjY5VyE6tjC8DsYt5uWypDHi5fIPdrRRyEyvTMlNzUuJzi9OL9b2hdvNy" +
                "KSsA2QpgyxUKEjOLdBTKM0syIALFCkWpBUWpxal5JakpConFCsUlRZl56cVcEFohG8Yo4+LlAgAcsWbZ" +
                "zwAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
