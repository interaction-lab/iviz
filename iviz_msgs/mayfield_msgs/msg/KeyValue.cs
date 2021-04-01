/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayfieldMsgs
{
    [Preserve, DataContract (Name = "mayfield_msgs/KeyValue")]
    public sealed class KeyValue : IDeserializable<KeyValue>, IMessage
    {
        // Key value pair, with values represented as strings
        [DataMember (Name = "k")] public string K { get; set; }
        [DataMember (Name = "v")] public string V { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public KeyValue()
        {
            K = string.Empty;
            V = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public KeyValue(string K, string V)
        {
            this.K = K;
            this.V = V;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public KeyValue(ref Buffer b)
        {
            K = b.DeserializeString();
            V = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new KeyValue(ref b);
        }
        
        KeyValue IDeserializable<KeyValue>.RosDeserialize(ref Buffer b)
        {
            return new KeyValue(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(K);
            b.Serialize(V);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (K is null) throw new System.NullReferenceException(nameof(K));
            if (V is null) throw new System.NullReferenceException(nameof(V));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 8;
                size += BuiltIns.UTF8.GetByteCount(K);
                size += BuiltIns.UTF8.GetByteCount(V);
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mayfield_msgs/KeyValue";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "ecd078d493bbb685fc79824134b47497";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAClNW8E6tVChLzClNVShIzCzSUSjPLMmACBQrFKUWFKUWp+aVpKYoJBYrFJcUZealF3NB" +
                "aIVsGKOMi5cLAOchAmtJAAAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
