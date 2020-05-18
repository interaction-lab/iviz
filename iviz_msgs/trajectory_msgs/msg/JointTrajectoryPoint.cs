using System.Runtime.Serialization;

namespace Iviz.Msgs.TrajectoryMsgs
{
    [DataContract (Name = "trajectory_msgs/JointTrajectoryPoint")]
    public sealed class JointTrajectoryPoint : IMessage
    {
        // Each trajectory point specifies either positions[, velocities[, accelerations]]
        // or positions[, effort] for the trajectory to be executed.
        // All specified values are in the same order as the joint names in JointTrajectory.msg
        [DataMember (Name = "positions")] public double[] Positions { get; set; }
        [DataMember (Name = "velocities")] public double[] Velocities { get; set; }
        [DataMember (Name = "accelerations")] public double[] Accelerations { get; set; }
        [DataMember (Name = "effort")] public double[] Effort { get; set; }
        [DataMember (Name = "time_from_start")] public duration TimeFromStart { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public JointTrajectoryPoint()
        {
            Positions = System.Array.Empty<double>();
            Velocities = System.Array.Empty<double>();
            Accelerations = System.Array.Empty<double>();
            Effort = System.Array.Empty<double>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public JointTrajectoryPoint(double[] Positions, double[] Velocities, double[] Accelerations, double[] Effort, duration TimeFromStart)
        {
            this.Positions = Positions;
            this.Velocities = Velocities;
            this.Accelerations = Accelerations;
            this.Effort = Effort;
            this.TimeFromStart = TimeFromStart;
        }
        
        /// <summary> Constructor with buffer. </summary>
        internal JointTrajectoryPoint(Buffer b)
        {
            Positions = b.DeserializeStructArray<double>();
            Velocities = b.DeserializeStructArray<double>();
            Accelerations = b.DeserializeStructArray<double>();
            Effort = b.DeserializeStructArray<double>();
            TimeFromStart = b.Deserialize<duration>();
        }
        
        ISerializable ISerializable.Deserialize(Buffer b)
        {
            return new JointTrajectoryPoint(b ?? throw new System.ArgumentNullException(nameof(b)));
        }
    
        void ISerializable.Serialize(Buffer b)
        {
            if (b is null) throw new System.ArgumentNullException(nameof(b));
            b.SerializeStructArray(Positions, 0);
            b.SerializeStructArray(Velocities, 0);
            b.SerializeStructArray(Accelerations, 0);
            b.SerializeStructArray(Effort, 0);
            b.Serialize(this.TimeFromStart);
        }
        
        public void Validate()
        {
            if (Positions is null) throw new System.NullReferenceException();
            if (Velocities is null) throw new System.NullReferenceException();
            if (Accelerations is null) throw new System.NullReferenceException();
            if (Effort is null) throw new System.NullReferenceException();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 24;
                size += 8 * Positions.Length;
                size += 8 * Velocities.Length;
                size += 8 * Accelerations.Length;
                size += 8 * Effort.Length;
                return size;
            }
        }
    
        string IMessage.RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "trajectory_msgs/JointTrajectoryPoint";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "f3cd1e1c4d320c79d6985c904ae5dcd3";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAE1WPsQ7CMAxE93yFJVbEhNgZWJjZUIVMeoGgtEaxi+DvcYsEZYl07+zceUE7jleyyjdE" +
                "k/qiu+TeSO+IOWUoIdsV1bFmy9LrcUkPFImuMAqOEQWVJ7NpwoLkfxopSbWG/CX/ap5lQmcQnoiDoV35" +
                "7raUb3ZLDy6DV+AKyv20rNzBA1pvxDqR29S3d67j0H6Uh2/EqtNLCKkI22Z9bH7FZux3zgz+nTXjn2tC" +
                "O3wsstzhlKp0JzV2I7wBGsNsNFIBAAA=";
                
    }
}
