/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [Preserve, DataContract (Name = "may_nav_msgs/Trajectory")]
    public sealed class Trajectory : IDeserializable<Trajectory>, IMessage
    {
        [DataMember (Name = "poses")] public GeometryMsgs.Pose2D[] Poses { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Trajectory()
        {
            Poses = System.Array.Empty<GeometryMsgs.Pose2D>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public Trajectory(GeometryMsgs.Pose2D[] Poses)
        {
            this.Poses = Poses;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Trajectory(ref Buffer b)
        {
            Poses = b.DeserializeArray<GeometryMsgs.Pose2D>();
            for (int i = 0; i < Poses.Length; i++)
            {
                Poses[i] = new GeometryMsgs.Pose2D(ref b);
            }
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Trajectory(ref b);
        }
        
        Trajectory IDeserializable<Trajectory>.RosDeserialize(ref Buffer b)
        {
            return new Trajectory(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.SerializeArray(Poses, 0);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Poses is null) throw new System.NullReferenceException(nameof(Poses));
            for (int i = 0; i < Poses.Length; i++)
            {
                if (Poses[i] is null) throw new System.NullReferenceException($"{nameof(Poses)}[{i}]");
                Poses[i].RosValidate();
            }
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += 24 * Poses.Length;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "may_nav_msgs/Trajectory";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "31a710d661541413a823a4591402c488";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACq1Ty6oTQRDdB/IPBS6ykQhXcSG4EAKShXBBXYlIZbomU9rT3fQjufP3nurJDQouDQzU" +
                "1NTjPCpnibPUvPyYy7m8eoxFHg7fvlNCUDbbzfv//NtuPn3++I7O/9i63bygg6QsA1dxeHn0wkWo4amT" +
                "0Ni8p9eHDm2/wfdjwJwgmT3FlgmNcZ4lOK4aA2mhGnsz31uzjS8S6loSR5KL5KVOGs7EwdEYMz0cqCQZ" +
                "dNSBOCWvQ68uNPOvFQmyOaaswEmIfsqwFmjARitInoP0YXjTTAP7ofnbmFOrFFPVmb1f6KqA1lHlyzod" +
                "ODWgd15BupYNHfYMUgrClftIV6GJ0ZMYCnjxNMSkUowVKEAFrkvCe6dIX4+dYMSGTEmTeAXEvh2SUUsU" +
                "RJxtAoc+1zUIC0qSR8Zqyycf6x+S7ekDWpfY/ppz1TpRQOFJuqwnL89OgFqN0ZdnnS03wOMOEpaNJsCy" +
                "y8jGOXmpAoUu7NW9JC62aedWcBiYRa0GjlfSuq51Oo6SeyakVsvKuVWL93Ssu9KRQbKq5kjG/Imzu5Mz" +
                "AwDMboyA0WA0uGzpha8kOSN7M5bsbmmGK3zGUWCTiYvIHp+F3XKja9+8njJnM6hOXEEb1tq14E5tHrjB" +
                "WDj7xTLyZCdhwrBh0X4JnQsm3M8XKQM7c9Axeof+0Ueub9/Q0z1a7hHAVcZf+jcCwgw28gMAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
