/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/Led")]
    public sealed class Led : IDeserializable<Led>, IMessage
    {
        // Provides a three color LED state
        [DataMember (Name = "red")] public byte Red { get; set; }
        [DataMember (Name = "green")] public byte Green { get; set; }
        [DataMember (Name = "blue")] public byte Blue { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Led()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public Led(byte Red, byte Green, byte Blue)
        {
            this.Red = Red;
            this.Green = Green;
            this.Blue = Blue;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Led(ref Buffer b)
        {
            Red = b.Deserialize<byte>();
            Green = b.Deserialize<byte>();
            Blue = b.Deserialize<byte>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Led(ref b);
        }
        
        Led IDeserializable<Led>.RosDeserialize(ref Buffer b)
        {
            return new Led(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Red);
            b.Serialize(Green);
            b.Serialize(Blue);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 3;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/Led";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "6c2dad1f01296e5a2060415602019877";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAClNWCCjKL8tMSS1WSFQoyShKTVVIzs/JL1LwcXVRKC5JLEnl4irNzCuxUChKTYGy0oGq" +
                "8qDspJzSVF4uAPwcXlBGAAAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
