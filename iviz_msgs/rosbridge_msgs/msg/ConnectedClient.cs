using System.Runtime.Serialization;

namespace Iviz.Msgs.RosbridgeMsgs
{
    [DataContract (Name = "rosbridge_msgs/ConnectedClient")]
    public sealed class ConnectedClient : IMessage
    {
        [DataMember (Name = "ip_address")] public string IpAddress { get; set; }
        [DataMember (Name = "connection_time")] public time ConnectionTime { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public ConnectedClient()
        {
            IpAddress = "";
        }
        
        /// <summary> Explicit constructor. </summary>
        public ConnectedClient(string IpAddress, time ConnectionTime)
        {
            this.IpAddress = IpAddress;
            this.ConnectionTime = ConnectionTime;
        }
        
        /// <summary> Constructor with buffer. </summary>
        internal ConnectedClient(Buffer b)
        {
            IpAddress = b.DeserializeString();
            ConnectionTime = b.Deserialize<time>();
        }
        
        public ISerializable RosDeserialize(Buffer b)
        {
            return new ConnectedClient(b ?? throw new System.ArgumentNullException(nameof(b)));
        }
    
        public void RosSerialize(Buffer b)
        {
            if (b is null) throw new System.ArgumentNullException(nameof(b));
            b.Serialize(IpAddress);
            b.Serialize(ConnectionTime);
        }
        
        public void RosValidate()
        {
            if (IpAddress is null) throw new System.NullReferenceException(nameof(IpAddress));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 12;
                size += BuiltIns.UTF8.GetByteCount(IpAddress);
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "rosbridge_msgs/ConnectedClient";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "7f2187ce389b39b2b3bb2a3957e54c04";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAEysuKcrMS1fILIhPTEkpSi0u5irJzE1VSM7Py0tNLsnMz4sH8bm4AFvLoaQoAAAA";
                
    }
}
