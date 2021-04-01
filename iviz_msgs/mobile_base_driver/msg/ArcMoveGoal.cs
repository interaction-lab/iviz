/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/ArcMoveGoal")]
    public sealed class ArcMoveGoal : IDeserializable<ArcMoveGoal>, IGoal<ArcMoveActionGoal>
    {
        [DataMember (Name = "arc_len")] public float ArcLen { get; set; }
        [DataMember (Name = "linear_velocity")] public float LinearVelocity { get; set; }
        [DataMember (Name = "angle")] public float Angle { get; set; }
        [DataMember (Name = "angular_velocity")] public float AngularVelocity { get; set; }
        [DataMember (Name = "duration")] public float Duration { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public ArcMoveGoal()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public ArcMoveGoal(float ArcLen, float LinearVelocity, float Angle, float AngularVelocity, float Duration)
        {
            this.ArcLen = ArcLen;
            this.LinearVelocity = LinearVelocity;
            this.Angle = Angle;
            this.AngularVelocity = AngularVelocity;
            this.Duration = Duration;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public ArcMoveGoal(ref Buffer b)
        {
            ArcLen = b.Deserialize<float>();
            LinearVelocity = b.Deserialize<float>();
            Angle = b.Deserialize<float>();
            AngularVelocity = b.Deserialize<float>();
            Duration = b.Deserialize<float>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new ArcMoveGoal(ref b);
        }
        
        ArcMoveGoal IDeserializable<ArcMoveGoal>.RosDeserialize(ref Buffer b)
        {
            return new ArcMoveGoal(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(ArcLen);
            b.Serialize(LinearVelocity);
            b.Serialize(Angle);
            b.Serialize(AngularVelocity);
            b.Serialize(Duration);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 20;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/ArcMoveGoal";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "49b394402086123603ca274f830ff69c";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACkvLyU8sMTZSSCxKjs9JzeNKg/JzMvNSE4viy1Jz8pMzSyrh4ol56TmpyLzSHGzKUkqL" +
                "Eksy8/N4uQCiqsKaYQAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
