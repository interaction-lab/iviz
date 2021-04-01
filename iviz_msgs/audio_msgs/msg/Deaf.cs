/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [Preserve, DataContract (Name = "audio_msgs/Deaf")]
    public sealed class Deaf : IDeserializable<Deaf>, IMessage
    {
        /// <summary> Constructor for empty message. </summary>
        public Deaf()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Deaf(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        Deaf IDeserializable<Deaf>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly Deaf Singleton = new Deaf();
    
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
        [Preserve] public const string RosMessageType = "audio_msgs/Deaf";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "d41d8cd98f00b204e9800998ecf8427e";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACuPlAgCshaIUAgAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
