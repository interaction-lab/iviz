
namespace Iviz.Msgs.trajectory_msgs
{
    public sealed class JointTrajectoryPoint : IMessage 
    {
        // Each trajectory point specifies either positions[, velocities[, accelerations]]
        // or positions[, effort] for the trajectory to be executed.
        // All specified values are in the same order as the joint names in JointTrajectory.msg
        
        public double[] positions;
        public double[] velocities;
        public double[] accelerations;
        public double[] effort;
        public duration time_from_start;

        /// <summary> Full ROS name of this message. </summary>
        public const string MessageType = "trajectory_msgs/JointTrajectoryPoint";

        public IMessage Create() => new JointTrajectoryPoint();

        public int GetLength()
        {
            int size = 24;
            size += 8 * positions.Length;
            size += 8 * velocities.Length;
            size += 8 * accelerations.Length;
            size += 8 * effort.Length;
            return size;
        }

        /// <summary> Constructor for empty message. </summary>
        public JointTrajectoryPoint()
        {
            positions = new double[0];
            velocities = new double[0];
            accelerations = new double[0];
            effort = new double[0];
        }
        
        public unsafe void Deserialize(ref byte* ptr, byte* end)
        {
            BuiltIns.Deserialize(out positions, ref ptr, end, 0);
            BuiltIns.Deserialize(out velocities, ref ptr, end, 0);
            BuiltIns.Deserialize(out accelerations, ref ptr, end, 0);
            BuiltIns.Deserialize(out effort, ref ptr, end, 0);
            BuiltIns.Deserialize(out time_from_start, ref ptr, end);
        }

        public unsafe void Serialize(ref byte* ptr, byte* end)
        {
            BuiltIns.Serialize(positions, ref ptr, end, 0);
            BuiltIns.Serialize(velocities, ref ptr, end, 0);
            BuiltIns.Serialize(accelerations, ref ptr, end, 0);
            BuiltIns.Serialize(effort, ref ptr, end, 0);
            BuiltIns.Serialize(time_from_start, ref ptr, end);
        }

        /// <summary> MD5 hash of a compact representation of the message. </summary>
        public const string Md5Sum = "f3cd1e1c4d320c79d6985c904ae5dcd3";

        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        public const string DependenciesBase64 =
            "H4sIAAAAAAAAE1WPsQ7CMAxE93yFJVbEhNgZWJjZUIVMeoGgtEaxi+DvcYsEZYl07+zceUE7jleyyjdE" +
            "k/qiu+TeSO+IOWUoIdsV1bFmy9LrcUkPFImuMAqOEQWVJ7NpwoLkfxopSbWG/CX/ap5lQmcQnoiDoV35" +
            "7raUb3ZLDy6DV+AKyv20rNzBA1pvxDqR29S3d67j0H6Uh2/EqtNLCKkI22Z9bH7FZux3zgz+nTXjn2tC" +
            "O3wsstzhlKp0JzV2I7wBGsNsNFIBAAA=";

    }
}
