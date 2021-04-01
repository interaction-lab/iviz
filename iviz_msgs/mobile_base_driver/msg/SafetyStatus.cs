/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/SafetyStatus")]
    public sealed class SafetyStatus : IDeserializable<SafetyStatus>, IMessage
    {
        // bit positions, same as in iris_comm
        public const sbyte HB_bp = 0; // Heartbeat
        public const sbyte CFHW_bp = 1; // Cliff to Motor Control HW
        public const sbyte CF0_bp = 2; // Cliff 0
        public const sbyte CF1_bp = 3; // Cliff 1
        public const sbyte CF2_bp = 4; // Cliff 2
        public const sbyte CF3_bp = 5; // Cliff 3
        public const sbyte CF4_bp = 6; // Cliff 4
        public const sbyte CF5_bp = 7; // Cliff 5
        public const sbyte DP_bp = 8; // Drop Right and Left
        public const sbyte BPR_bp = 10; // Bump Right
        public const sbyte BPM_bp = 11; // Bump Middle
        public const sbyte BPL_bp = 12; // Bump Left
        public const sbyte CLL_bp = 13; // Clothesline
        [DataMember (Name = "status")] public uint Status { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public SafetyStatus()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public SafetyStatus(uint Status)
        {
            this.Status = Status;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public SafetyStatus(ref Buffer b)
        {
            Status = b.Deserialize<uint>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new SafetyStatus(ref b);
        }
        
        SafetyStatus IDeserializable<SafetyStatus>.RosDeserialize(ref Buffer b)
        {
            return new SafetyStatus(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Status);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 4;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/SafetyStatus";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "d125b2e4a510271c37ef066dc9d6c0de";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACk3QPW+DMBSF4Rmk/ocjZe3AZ5uFBaKKAaQoS8bIFNNYAhvhy/9va3xbz8+re6VzwqAI" +
                "q7GKlNH2FVYsEsJCaahN2cenWZZYaTqjrR/DCqBCAkRRdEIrxUaDFHQEzUd7/00qpI6bWU0TyKA3ZDY0" +
                "RtNmZrR3zhN3sEIW5Alj6jEPMGXMPBYBZoy5xzLAnLHw+BZgwVh6fA+wPPBy9XZ2dtnMipv6ehKEHtHJ" +
                "yY9QX28+TBNX1vviSw56Do6ZXNCrcZwlFx0XxzKu+H/RdH/O4xh6SjsrLeN4/2nyDJYE7TZ+ib8BzLha" +
                "4eIBAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
