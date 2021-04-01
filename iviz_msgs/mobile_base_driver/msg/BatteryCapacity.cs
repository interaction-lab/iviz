/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/BatteryCapacity")]
    public sealed class BatteryCapacity : IDeserializable<BatteryCapacity>, IMessage
    {
        [DataMember (Name = "mAh")] public short MAh { get; set; }
        [DataMember (Name = "pct")] public sbyte Pct { get; set; }
        [DataMember (Name = "rounded_pct")] public sbyte RoundedPct { get; set; } // capacity percentage estimate, rounded to the nearest 5 and
        // subjected to hysteresis so it can only change if the value has
        // changed by at least 5
    
        /// <summary> Constructor for empty message. </summary>
        public BatteryCapacity()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public BatteryCapacity(short MAh, sbyte Pct, sbyte RoundedPct)
        {
            this.MAh = MAh;
            this.Pct = Pct;
            this.RoundedPct = RoundedPct;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public BatteryCapacity(ref Buffer b)
        {
            MAh = b.Deserialize<short>();
            Pct = b.Deserialize<sbyte>();
            RoundedPct = b.Deserialize<sbyte>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new BatteryCapacity(ref b);
        }
        
        BatteryCapacity IDeserializable<BatteryCapacity>.RosDeserialize(ref Buffer b)
        {
            return new BatteryCapacity(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(MAh);
            b.Serialize(Pct);
            b.Serialize(RoundedPct);
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
        [Preserve] public const string RosMessageType = "mobile_base_driver/BatteryCapacity";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "44e1b0249db4fca04e974c31a68c58b0";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACm2NQQoCMQxF9wXv8GG2blwobj2JZNpoI520TDNCb2+1uBGzCvkv/4na4YTlEp2onVG8" +
                "jWXNmwYO137ABE+FvFhD4dWzGt0ZXE0WMt5/WViGRYYyrT3EEaTB4Xcm1G1+sLfxEVs17rxU1Ayx7lJk" +
                "TQ0+knaP3D6tT0obI1L91zjQgLmBDInprXc79wK4ikdK3gAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
