/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/Clothesline")]
    public sealed class Clothesline : IDeserializable<Clothesline>, IMessage
    {
        // clothesline sensor state
        public const byte NOTHING = 0;
        public const byte SOMETHING = 1;
        [DataMember (Name = "state")] public byte State { get; set; }
        [DataMember (Name = "distance")] public float Distance { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Clothesline()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public Clothesline(byte State, float Distance)
        {
            this.State = State;
            this.Distance = Distance;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Clothesline(ref Buffer b)
        {
            State = b.Deserialize<byte>();
            Distance = b.Deserialize<float>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Clothesline(ref b);
        }
        
        Clothesline IDeserializable<Clothesline>.RosDeserialize(ref Buffer b)
        {
            return new Clothesline(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(State);
            b.Serialize(Distance);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 5;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/Clothesline";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "86c594a65048cb5ab786bd284ae19bfc";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAClNWSM7JL8lILc7JzEtVKE7NK84vUiguSSxJ5eIqzcwrsVDw8w/x8PRzV1BQsFUwgIoF" +
                "+/u6QkRtFQxhChWg+tJy8hNLjI0UUjKB/LzkVC5eLgDHw2oJZgAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
