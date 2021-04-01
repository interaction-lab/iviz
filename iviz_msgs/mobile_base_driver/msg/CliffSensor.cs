/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/CliffSensor")]
    public sealed class CliffSensor : IDeserializable<CliffSensor>, IMessage
    {
        // Provides a cliff sensor reading
        // This message is generated whenever a particular cliff sensor signals that the
        // robot approaches or moves away from a cliff.
        // cliff sensor
        public const byte RIGHT = 0;
        public const byte MIDRIGHT = 1;
        public const byte MIDLEFT = 2;
        public const byte LEFT = 3;
        public const byte BACKLEFT = 4;
        public const byte BACKRIGHT = 5;
        // cliff sensor state
        public const byte FLOOR = 0;
        public const byte CLIFF = 1;
        [DataMember (Name = "sensor")] public byte Sensor { get; set; }
        [DataMember (Name = "state")] public byte State { get; set; }
        // distance to floor when cliff was detected
        [DataMember (Name = "distance")] public float Distance { get; set; }
        // return rate from the vl6180x, rear cliff sensors only
        [DataMember (Name = "return_rate")] public float ReturnRate { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public CliffSensor()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public CliffSensor(byte Sensor, byte State, float Distance, float ReturnRate)
        {
            this.Sensor = Sensor;
            this.State = State;
            this.Distance = Distance;
            this.ReturnRate = ReturnRate;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public CliffSensor(ref Buffer b)
        {
            Sensor = b.Deserialize<byte>();
            State = b.Deserialize<byte>();
            Distance = b.Deserialize<float>();
            ReturnRate = b.Deserialize<float>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new CliffSensor(ref b);
        }
        
        CliffSensor IDeserializable<CliffSensor>.RosDeserialize(ref Buffer b)
        {
            return new CliffSensor(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Sensor);
            b.Serialize(State);
            b.Serialize(Distance);
            b.Serialize(ReturnRate);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 10;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/CliffSensor";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "df8e935c1e6098b4bc39e9a6c6ab00d2";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACl2RzU7DMBCE75F4h5F6Rag/gHrJAQqBiKKiqne0JJvEUmpXtpPSt2fdmNKSQ2R93hmP" +
                "Zkf4sKZXJTsQilZVFRxrZywsU6l0nYywaZTDlp2jmiHHmjVb8lxi38ixZyvaHVmviq4le2njVK2pdfAN" +
                "efmx+FnzZTxot7OGikZelrGt6UOEPR1QWbP9DXOTyPy5X9Ip7edY5y+vG4QvxTiy9/wp4hSTP7Z8zsJk" +
                "imlkERzZLLLHh8XbwFPcnrHBMMXd/xxwXhqIk9lytVqfJVks8yw7pojgIvugFL9SyVEXDG9QtUZMQ5/x" +
                "mT05lOy5kJ4TuSU/m54UQW3Zd1YjLGKoTMpF395P5uPv67C9y0VIy7o9nJwG9WdQXyU/B6gjrAUCAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
