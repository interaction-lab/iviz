using System.Text;
using System.Runtime.Serialization;

namespace Iviz.Msgs.sensor_msgs
{
    public sealed class TimeReference : IMessage
    {
        // Measurement from an external time source not actively synchronized with the system clock.
        
        public std_msgs.Header header; // stamp is system time for which measurement was valid
        // frame_id is not used 
        
        public time time_ref; // corresponding time from this external source
        public string source; // (optional) name of time source
    
        /// <summary> Constructor for empty message. </summary>
        public TimeReference()
        {
            header = new std_msgs.Header();
            source = "";
        }
        
        public unsafe void Deserialize(ref byte* ptr, byte* end)
        {
            header.Deserialize(ref ptr, end);
            BuiltIns.Deserialize(out time_ref, ref ptr, end);
            BuiltIns.Deserialize(out source, ref ptr, end);
        }
    
        public unsafe void Serialize(ref byte* ptr, byte* end)
        {
            header.Serialize(ref ptr, end);
            BuiltIns.Serialize(time_ref, ref ptr, end);
            BuiltIns.Serialize(source, ref ptr, end);
        }
    
        [IgnoreDataMember]
        public int RosMessageLength
        {
            get {
                int size = 12;
                size += header.RosMessageLength;
                size += Encoding.UTF8.GetByteCount(source);
                return size;
            }
        }
    
        public IMessage Create() => new TimeReference();
    
        [IgnoreDataMember]
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        public const string RosMessageType = "sensor_msgs/TimeReference";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        public const string RosMd5Sum = "fded64a0265108ba86c3d38fb11c0c16";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAE61TwYrbMBC96ysGfNikkBTaW6C3Zds9LBR272EiTSxReeRK46Tu13ckJ2naUw8VBmP7" +
                "zXsz7407eCEsU6aBWOCY0wDIQD+EMmMECQNBSVO2BJwE0Eo4UZyhzGx9Thx+koNzEA/iFTkXoQFsTPbb" +
                "1pgvhI4y+OWmp4MiOIwQyhXaBI4pw9kH62G4a+aMBU4YgzPw9+m0UxxoH1ylqo1NRfswptFBY91nOlak" +
                "TTlTGRO7wP1Fr44pXktvgy4zmiK5oi4TN6VVGiUkxayBVRPS8d4VYz7952NeXj/v1Ce3H0pf3i8emg5e" +
                "BdlhduqRoEPBZpsPvae8iaSpLOaqD+2rzCOVrRa+1UH16okpY9TwmlmS1JphmDhYFGoz/VGvlYEBYcQs" +
                "wU4Rs+JTVhcrvPlf2fUq9H0iVr+eH3eK4UJ2uqxJYJs10urp8yOYKbB8/FALTPd2Tht9pF5X4yauqaBA" +
                "C2bU1GqfWHaq8W4Zbqvcag6piiuwau/2+ljWoCLaAo1J12ilnX+dxSdua3nCHPAQqRJbdUBZH2rRw/qO" +
                "mRs1I6cr/cL4W+NfaPnGW2faeM0sto2aejVQgWNOp+AUepgbiY2hLnsMh4x5Xha4SZruqXq87GlLRO9Y" +
                "SrJBA1h+uuu+Xv8GY34B7F3gx9ADAAA=";
                
    }
}
