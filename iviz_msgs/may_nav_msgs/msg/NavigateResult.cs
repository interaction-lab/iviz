/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [Preserve, DataContract (Name = "may_nav_msgs/NavigateResult")]
    public sealed class NavigateResult : IDeserializable<NavigateResult>, IResult<NavigateActionResult>
    {
        /// <summary> Constructor for empty message. </summary>
        public NavigateResult()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public NavigateResult(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        NavigateResult IDeserializable<NavigateResult>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly NavigateResult Singleton = new NavigateResult();
    
        public void RosSerialize(ref Buffer b)
        {
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 0;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "may_nav_msgs/NavigateResult";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "d41d8cd98f00b204e9800998ecf8427e";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACuPlAgCshaIUAgAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
