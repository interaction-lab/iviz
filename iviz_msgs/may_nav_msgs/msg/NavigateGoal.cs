/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [Preserve, DataContract (Name = "may_nav_msgs/NavigateGoal")]
    public sealed class NavigateGoal : IDeserializable<NavigateGoal>, IGoal<NavigateActionGoal>
    {
        public const byte GO_TO_WAYPOINT = 0;
        public const byte DRIVE_TO_POINT_IN_IMAGE = 1;
        public const byte FOLLOW_ME = 2;
        [DataMember (Name = "nav_type")] public byte NavType { get; set; }
        [DataMember (Name = "pose")] public GeometryMsgs.Pose Pose { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public NavigateGoal()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public NavigateGoal(byte NavType, in GeometryMsgs.Pose Pose)
        {
            this.NavType = NavType;
            this.Pose = Pose;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public NavigateGoal(ref Buffer b)
        {
            NavType = b.Deserialize<byte>();
            Pose = new GeometryMsgs.Pose(ref b);
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new NavigateGoal(ref b);
        }
        
        NavigateGoal IDeserializable<NavigateGoal>.RosDeserialize(ref Buffer b)
        {
            return new NavigateGoal(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(NavType);
            Pose.RosSerialize(ref b);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 57;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "may_nav_msgs/NavigateGoal";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "a0717defd8a80a12c8f217581c7cb9ad";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACr2RTUvDMBjH7w/0OzzgVeYU8SD0ULCWwrpULQ5PIduebgGb1CS+1E9v0rnW4cGLLIfw" +
                "vCX5//5Zdo4wY7xifJE8lSyfV/EUlqF6c58/pqHRV3k+53mRZGl8vmvfstmMLXiRxhewqyjxxl3XEmxI" +
                "N+RMxxu7sWeltoSt3yKI/3lFUDxk1/j7vQhOMEFDrSFLygkntUJd9zJQKqwNEdpWrOgUV7oJ5fV3X/az" +
                "QvncyP3ZCUKppXLDANy9CkdG9feOc3A0Ri8mQFZbaT2Bf14qi25LI4LHET4Lqg+IoX7Wwl1d4scQdUP0" +
                "eSyC0b8BY/gu6+3/6eqh/pC9jO7X2jQT+ANqH717vC9s+Q7k8wIAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
