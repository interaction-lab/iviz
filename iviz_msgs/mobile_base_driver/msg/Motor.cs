/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/Motor")]
    public sealed class Motor : IDeserializable<Motor>, IMessage
    {
        // Provides a motor state
        // motor
        public const byte RIGHTWHEEL = 0;
        public const byte LEFTWHEEL = 1;
        public const byte PAN = 2;
        public const byte TILT = 3;
        public const byte EYES = 4;
        [DataMember (Name = "stalled")] public bool Stalled { get; set; }
        [DataMember (Name = "pushed")] public bool Pushed { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Motor()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public Motor(bool Stalled, bool Pushed)
        {
            this.Stalled = Stalled;
            this.Pushed = Pushed;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Motor(ref Buffer b)
        {
            Stalled = b.Deserialize<bool>();
            Pushed = b.Deserialize<bool>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Motor(ref b);
        }
        
        Motor IDeserializable<Motor>.RosDeserialize(ref Buffer b)
        {
            return new Motor(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Stalled);
            b.Serialize(Pushed);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 2;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/Motor";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "474302a9ee5ae83e0d6191474935a690";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAClNWCCjKL8tMSS1WSFTIzS/JL1IoLkksSeXiUoZwuUoz80osFII83T1Cwj1cXX0UQMBW" +
                "wQAq4ePqhiQOlDCESgQ4+kGEYBJGUIkQT58QFAljqIRrpGswioQJF1dSfn6OAshJOTmpKVBeQWlxRmoK" +
                "LxcAk4Nf9LwAAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
