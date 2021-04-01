/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/ArcMoveFeedback")]
    public sealed class ArcMoveFeedback : IDeserializable<ArcMoveFeedback>, IFeedback<ArcMoveActionFeedback>
    {
        /// <summary> Constructor for empty message. </summary>
        public ArcMoveFeedback()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public ArcMoveFeedback(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        ArcMoveFeedback IDeserializable<ArcMoveFeedback>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly ArcMoveFeedback Singleton = new ArcMoveFeedback();
    
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
        [Preserve] public const string RosMessageType = "mobile_base_driver/ArcMoveFeedback";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "d41d8cd98f00b204e9800998ecf8427e";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACuPlAgCshaIUAgAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
