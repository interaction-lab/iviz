/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/WheelTrajPoint")]
    public sealed class WheelTrajPoint : IDeserializable<WheelTrajPoint>, IMessage
    {
        [DataMember (Name = "time_from_start")] public duration TimeFromStart { get; set; }
        [DataMember (Name = "linear_vel")] public double LinearVel { get; set; }
        [DataMember (Name = "angular_vel")] public double AngularVel { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public WheelTrajPoint()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public WheelTrajPoint(duration TimeFromStart, double LinearVel, double AngularVel)
        {
            this.TimeFromStart = TimeFromStart;
            this.LinearVel = LinearVel;
            this.AngularVel = AngularVel;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public WheelTrajPoint(ref Buffer b)
        {
            TimeFromStart = b.Deserialize<duration>();
            LinearVel = b.Deserialize<double>();
            AngularVel = b.Deserialize<double>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new WheelTrajPoint(ref b);
        }
        
        WheelTrajPoint IDeserializable<WheelTrajPoint>.RosDeserialize(ref Buffer b)
        {
            return new WheelTrajPoint(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(TimeFromStart);
            b.Serialize(LinearVel);
            b.Serialize(AngularVel);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 24;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/WheelTrajPoint";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "83f621b6e10790ea4ea291815a52bf4a";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACkspLUosyczPUyjJzE2NTyvKz40vLkksKuFKy8lPLDEzUcjJzEtNLIovS82BCyXmpZfm" +
                "QMV4uQAZyjjlQgAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
