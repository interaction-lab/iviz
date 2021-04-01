/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [Preserve, DataContract (Name = "may_nav_msgs/ScoredTrajectories")]
    public sealed class ScoredTrajectories : IDeserializable<ScoredTrajectories>, IMessage
    {
        [DataMember (Name = "trajectories")] public MayNavMsgs.Trajectory[] Trajectories { get; set; }
        [DataMember (Name = "scores")] public float[] Scores { get; set; }
        [DataMember (Name = "plan_distance_scores")] public float[] PlanDistanceScores { get; set; }
        [DataMember (Name = "target_distance_scores")] public float[] TargetDistanceScores { get; set; }
        [DataMember (Name = "plan_angle_difference_scores")] public float[] PlanAngleDifferenceScores { get; set; }
        [DataMember (Name = "target_angle_difference_scores")] public float[] TargetAngleDifferenceScores { get; set; }
        [DataMember (Name = "obstacle_scores")] public float[] ObstacleScores { get; set; }
        [DataMember (Name = "heading_angle_difference_scores")] public float[] HeadingAngleDifferenceScores { get; set; }
        [DataMember (Name = "chosen_trajectory_index")] public int ChosenTrajectoryIndex { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public ScoredTrajectories()
        {
            Trajectories = System.Array.Empty<MayNavMsgs.Trajectory>();
            Scores = System.Array.Empty<float>();
            PlanDistanceScores = System.Array.Empty<float>();
            TargetDistanceScores = System.Array.Empty<float>();
            PlanAngleDifferenceScores = System.Array.Empty<float>();
            TargetAngleDifferenceScores = System.Array.Empty<float>();
            ObstacleScores = System.Array.Empty<float>();
            HeadingAngleDifferenceScores = System.Array.Empty<float>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public ScoredTrajectories(MayNavMsgs.Trajectory[] Trajectories, float[] Scores, float[] PlanDistanceScores, float[] TargetDistanceScores, float[] PlanAngleDifferenceScores, float[] TargetAngleDifferenceScores, float[] ObstacleScores, float[] HeadingAngleDifferenceScores, int ChosenTrajectoryIndex)
        {
            this.Trajectories = Trajectories;
            this.Scores = Scores;
            this.PlanDistanceScores = PlanDistanceScores;
            this.TargetDistanceScores = TargetDistanceScores;
            this.PlanAngleDifferenceScores = PlanAngleDifferenceScores;
            this.TargetAngleDifferenceScores = TargetAngleDifferenceScores;
            this.ObstacleScores = ObstacleScores;
            this.HeadingAngleDifferenceScores = HeadingAngleDifferenceScores;
            this.ChosenTrajectoryIndex = ChosenTrajectoryIndex;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public ScoredTrajectories(ref Buffer b)
        {
            Trajectories = b.DeserializeArray<MayNavMsgs.Trajectory>();
            for (int i = 0; i < Trajectories.Length; i++)
            {
                Trajectories[i] = new MayNavMsgs.Trajectory(ref b);
            }
            Scores = b.DeserializeStructArray<float>();
            PlanDistanceScores = b.DeserializeStructArray<float>();
            TargetDistanceScores = b.DeserializeStructArray<float>();
            PlanAngleDifferenceScores = b.DeserializeStructArray<float>();
            TargetAngleDifferenceScores = b.DeserializeStructArray<float>();
            ObstacleScores = b.DeserializeStructArray<float>();
            HeadingAngleDifferenceScores = b.DeserializeStructArray<float>();
            ChosenTrajectoryIndex = b.Deserialize<int>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new ScoredTrajectories(ref b);
        }
        
        ScoredTrajectories IDeserializable<ScoredTrajectories>.RosDeserialize(ref Buffer b)
        {
            return new ScoredTrajectories(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.SerializeArray(Trajectories, 0);
            b.SerializeStructArray(Scores, 0);
            b.SerializeStructArray(PlanDistanceScores, 0);
            b.SerializeStructArray(TargetDistanceScores, 0);
            b.SerializeStructArray(PlanAngleDifferenceScores, 0);
            b.SerializeStructArray(TargetAngleDifferenceScores, 0);
            b.SerializeStructArray(ObstacleScores, 0);
            b.SerializeStructArray(HeadingAngleDifferenceScores, 0);
            b.Serialize(ChosenTrajectoryIndex);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Trajectories is null) throw new System.NullReferenceException(nameof(Trajectories));
            for (int i = 0; i < Trajectories.Length; i++)
            {
                if (Trajectories[i] is null) throw new System.NullReferenceException($"{nameof(Trajectories)}[{i}]");
                Trajectories[i].RosValidate();
            }
            if (Scores is null) throw new System.NullReferenceException(nameof(Scores));
            if (PlanDistanceScores is null) throw new System.NullReferenceException(nameof(PlanDistanceScores));
            if (TargetDistanceScores is null) throw new System.NullReferenceException(nameof(TargetDistanceScores));
            if (PlanAngleDifferenceScores is null) throw new System.NullReferenceException(nameof(PlanAngleDifferenceScores));
            if (TargetAngleDifferenceScores is null) throw new System.NullReferenceException(nameof(TargetAngleDifferenceScores));
            if (ObstacleScores is null) throw new System.NullReferenceException(nameof(ObstacleScores));
            if (HeadingAngleDifferenceScores is null) throw new System.NullReferenceException(nameof(HeadingAngleDifferenceScores));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 36;
                foreach (var i in Trajectories)
                {
                    size += i.RosMessageLength;
                }
                size += 4 * Scores.Length;
                size += 4 * PlanDistanceScores.Length;
                size += 4 * TargetDistanceScores.Length;
                size += 4 * PlanAngleDifferenceScores.Length;
                size += 4 * TargetAngleDifferenceScores.Length;
                size += 4 * ObstacleScores.Length;
                size += 4 * HeadingAngleDifferenceScores.Length;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "may_nav_msgs/ScoredTrajectories";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "f5c548ba9491b852a98720ee47439e25";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACrVUTWvcMBC9L+x/GOghl5JCUnoo9FBYKDkUAk1PpSyz8nitVpaENN6N/33fyNmloWly" +
                "aQ2G0Wg+3rw39sjzNvJhO9Z9fXNX+Ic4TWX+9p30dPBSV31IrNdXcFeXyiNHDhy3na/K0cn2j2vlshd9" +
                "JqDlc9wHQVDfS5Hn6rwcmHbo5MITN4Nw5+P+rzV8RBy5IVWJ2/P489bHTu5X69WHf/ysV5+/fHpP49MS" +
                "rFd7SaMoALSbW8C62hhhMOr/g/NU1/XqFW0kF3Gs0uFwG4Sr0IRXB6F+CoGuNw3a5Qr3NxF1ohQOlKZC" +
                "SEzjKLFj9SmSr6SpJfM5tVh5EK9LSOpJDlJmHaAYceyoT4WuNlSzON97R5xz8K5FV3D4c0ECb0m5eOAk" +
                "WMZlC4C2qQXYukkrhpMv5Di4KTyU2U1KKasfOYSZjh7QGqpyWKoDp4/IHReQ3VQMHfo4qRXmMntPR6GB" +
                "kZMZDAQJ5FLGZ2RTYQSwwDpnnNuI9PWmDZjQoVD2WYIHxNYdlNGUKYrY5hprrW43gViMJKVntDZ/Dkl/" +
                "o+ySPiJ1TtOjOkevA0UE7qTRugtyUgKjaUqhnng2n4PGDSQk642A+aLAm8YcRAUMHTj47jVxtU4X3QIO" +
                "BYt4i4HiSl6XtqfvDZ6YJ63LzJOafUk3elEbMlCm3hQpqD9w6c7DmQAAZjtGwGgwJqhs7pmPJKXA+yAs" +
                "2d7SCFV4j6VAJyMXlr2h4EcwP4xrd8HvCtt/DlGsGBvS2rZgT60eZoOwUPbOPHJvK2HEsGHxbRPaLKhw" +
                "Xl+4DOzI0fcpdMhv/6F3b+n+bM1nC+CU8Un/AqA5jiqOBQAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
