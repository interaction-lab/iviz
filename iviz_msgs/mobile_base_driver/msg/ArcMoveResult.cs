/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/ArcMoveResult")]
    public sealed class ArcMoveResult : IDeserializable<ArcMoveResult>, IResult<ArcMoveActionResult>
    {
        /// <summary> Constructor for empty message. </summary>
        public ArcMoveResult()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public ArcMoveResult(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        ArcMoveResult IDeserializable<ArcMoveResult>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly ArcMoveResult Singleton = new ArcMoveResult();
    
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
        [Preserve] public const string RosMessageType = "mobile_base_driver/ArcMoveResult";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "d41d8cd98f00b204e9800998ecf8427e";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACuPlAgCshaIUAgAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
