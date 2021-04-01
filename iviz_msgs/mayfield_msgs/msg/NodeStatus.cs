/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayfieldMsgs
{
    [Preserve, DataContract (Name = "mayfield_msgs/NodeStatus")]
    public sealed class NodeStatus : IDeserializable<NodeStatus>, IMessage
    {
        [DataMember (Name = "node_name")] public string NodeName { get; set; }
        [DataMember (Name = "online")] public bool Online { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public NodeStatus()
        {
            NodeName = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public NodeStatus(string NodeName, bool Online)
        {
            this.NodeName = NodeName;
            this.Online = Online;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public NodeStatus(ref Buffer b)
        {
            NodeName = b.DeserializeString();
            Online = b.Deserialize<bool>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new NodeStatus(ref b);
        }
        
        NodeStatus IDeserializable<NodeStatus>.RosDeserialize(ref Buffer b)
        {
            return new NodeStatus(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(NodeName);
            b.Serialize(Online);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (NodeName is null) throw new System.NullReferenceException(nameof(NodeName));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 5;
                size += BuiltIns.UTF8.GetByteCount(NodeName);
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mayfield_msgs/NodeStatus";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "2938585155f971aea1e199f84d3637b6";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACisuKcrMS1fIy09Jjc9LzE3lSsrPz1HIz8vJzEvl4uUCAASrTWwfAAAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
