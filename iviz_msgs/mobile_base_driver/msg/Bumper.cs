/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/Bumper")]
    public sealed class Bumper : IDeserializable<Bumper>, IMessage
    {
        // Provides a bumper stae
        // bumper
        public const byte RIGHT = 0;
        public const byte CENTER = 1;
        public const byte LEFT = 2;
        // bumper state
        public const byte RELEASED = 0;
        public const byte PRESSED = 1;
        [DataMember (Name = "bumper")] public byte Bumper_ { get; set; }
        [DataMember (Name = "state")] public byte State { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Bumper()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public Bumper(byte Bumper_, byte State)
        {
            this.Bumper_ = Bumper_;
            this.State = State;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Bumper(ref Buffer b)
        {
            Bumper_ = b.Deserialize<byte>();
            State = b.Deserialize<byte>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Bumper(ref b);
        }
        
        Bumper IDeserializable<Bumper>.RosDeserialize(ref Buffer b)
        {
            return new Bumper(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Bumper_);
            b.Serialize(State);
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
        [Preserve] public const string RosMessageType = "mobile_base_driver/Bumper";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "96ae89263ef90e8520c31ccfe1d3540a";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAClNWCCjKL8tMSS1WSFRIKs0tSC1SKC5JTOXiUoZyuUoz80osFII83T1CFEDAVsEAKubs" +
                "6hfiGgQRM4SK+bi6QZQBxYwQpoAMLUmFmeXq4+oY7OqCZFRAkGswRMSQCyqEYj1EOy8XAPBUJsywAAAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
