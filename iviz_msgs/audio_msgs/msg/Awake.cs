/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [Preserve, DataContract (Name = "audio_msgs/Awake")]
    public sealed class Awake : IDeserializable<Awake>, IMessage
    {
        [DataMember (Name = "direction")] public GeometryMsgs.Vector3 Direction { get; set; }
        [DataMember (Name = "relative_angle")] public ushort RelativeAngle { get; set; }
        [DataMember (Name = "score")] public float Score { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Awake()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public Awake(in GeometryMsgs.Vector3 Direction, ushort RelativeAngle, float Score)
        {
            this.Direction = Direction;
            this.RelativeAngle = RelativeAngle;
            this.Score = Score;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Awake(ref Buffer b)
        {
            Direction = new GeometryMsgs.Vector3(ref b);
            RelativeAngle = b.Deserialize<ushort>();
            Score = b.Deserialize<float>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Awake(ref b);
        }
        
        Awake IDeserializable<Awake>.RosDeserialize(ref Buffer b)
        {
            return new Awake(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            Direction.RosSerialize(ref b);
            b.Serialize(RelativeAngle);
            b.Serialize(Score);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 30;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "audio_msgs/Awake";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "b67c4c1f2cbb59c79b9f56d85e60a268";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACq1RwUrDQBS8L+QfBrwolIit9CB4lh4EQfFaXpOX7WKyL+y+tsav96UpEcGjexp2Z+bN" +
                "vPUsHWsatl32+fadK5W0Qh2SoSDRHULUuzUSt6ThyFuKvmXXtEK6WiJXktgV7vGfT+GeX58e4P8KV7gr" +
                "vO1Dtkx94sxRMwjH8yNCRJOYkXuquIRRNwrjSmwHdExRofKjNOFctTRXTtxYowWCohbOiKLm0dGHWXLM" +
                "PKqp782MoIliHtcicbw2yTWXvlzgtOc4sUL0RjQHz5FTqJCCD/WktEHdLCZc2i2gzRKn0LZT5mmY7tlM" +
                "kuhZcFNi02CQA05jIQMJNaklEuws4iUX7doxryxwGIOfLX5v9EXsd20tOZNn211Wprp00/eu7/E5o2FG" +
                "X4X7Bn0iwVk0AgAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
