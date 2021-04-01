/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/WheelDrop")]
    public sealed class WheelDrop : IDeserializable<WheelDrop>, IMessage
    {
        // Provides a wheeldrop sensor stae
        // wheel
        public const byte RIGHT = 0;
        public const byte LEFT = 1;
        // wheel state
        public const byte RAISED = 0;
        public const byte DROPPED = 1;
        [DataMember (Name = "wheel")] public byte Wheel { get; set; }
        [DataMember (Name = "state")] public byte State { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public WheelDrop()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public WheelDrop(byte Wheel, byte State)
        {
            this.Wheel = Wheel;
            this.State = State;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public WheelDrop(ref Buffer b)
        {
            Wheel = b.Deserialize<byte>();
            State = b.Deserialize<byte>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new WheelDrop(ref b);
        }
        
        WheelDrop IDeserializable<WheelDrop>.RosDeserialize(ref Buffer b)
        {
            return new WheelDrop(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Wheel);
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
        [Preserve] public const string RosMessageType = "mobile_base_driver/WheelDrop";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "fb4521cb4dace44ce1858348261dd098";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAClNWCCjKL8tMSS1WSFQoz0hNzUkpyi9QKE7NK84vUiguSUzl4lKGSHCVZuaVWCgEebp7" +
                "hCjYKhhA+T6ubiEKQL4hXCFIW0kqTLmjZ7CrC0gBTINLkH9AAFAIrAUihGw+RDMvFwALHT1EmgAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
