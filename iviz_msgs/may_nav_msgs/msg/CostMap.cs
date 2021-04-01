/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [Preserve, DataContract (Name = "may_nav_msgs/CostMap")]
    public sealed class CostMap : IDeserializable<CostMap>, IMessage
    {
        // This represents a 2-D cost map, in which each
        // cell represents the cost of each position
        // as a float
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        // MetaData for the map
        [DataMember (Name = "info")] public NavMsgs.MapMetaData Info { get; set; }
        // The cost map data, in row-major order, starting with (0,0).
        // The costs are represented as floats from [0, inf)
        [DataMember (Name = "data")] public double[] Data { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public CostMap()
        {
            Info = new NavMsgs.MapMetaData();
            Data = System.Array.Empty<double>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public CostMap(in StdMsgs.Header Header, NavMsgs.MapMetaData Info, double[] Data)
        {
            this.Header = Header;
            this.Info = Info;
            this.Data = Data;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public CostMap(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            Info = new NavMsgs.MapMetaData(ref b);
            Data = b.DeserializeStructArray<double>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new CostMap(ref b);
        }
        
        CostMap IDeserializable<CostMap>.RosDeserialize(ref Buffer b)
        {
            return new CostMap(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            Header.RosSerialize(ref b);
            Info.RosSerialize(ref b);
            b.SerializeStructArray(Data, 0);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Info is null) throw new System.NullReferenceException(nameof(Info));
            Info.RosValidate();
            if (Data is null) throw new System.NullReferenceException(nameof(Data));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 80;
                size += Header.RosMessageLength;
                size += 8 * Data.Length;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "may_nav_msgs/CostMap";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "928772a4fd242ce392b6f2fbccdd0b78";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACr1VTWvcSBC9N/g/FPgQO8xMTBL2YNjDgtkkBxMv8W0wQ7lVM+pF6la6W55of31etTQa" +
                "exNIDnEGwUitqlfv1ZdO6bZ2iaJ0UZL4nIjp9fKKbEiZWu4W5Dzta2drEra1OSUrTfPYPtcyWodtMaEu" +
                "JJdd8LBlhds2gbMx74UriVSXP4OX15L5ijMMQiwoCGc8P2zatEuvrrmbDZzfBvW4PYSCJVV4U9jFsF+2" +
                "/C9AQgT0glLmmJ3f0d7lms4uFhfnq0fe4BTlqEAqpVlI4i+GltYXirs9N+Xwj7fruxLsxPz5i38n5vrT" +
                "u0vwrUbNY4pOwPVTZl9xrKhFDqpDkmq3qyUuG3mQRlW2HciXt3noJI0iUU1cO/ESuWkG6hOMcoD0tu29" +
                "s5yFsmvliT88kUmmTjNn+4Yj7JFO59V8G7kVRceV5HMv3gp9uLqEjU9i++xAaACCjcJJM//hikzvfH7z" +
                "Wh3M6e0+LPEoO3TAHBxF56xk5YvWQnlyukSMl6O4FbCRHUGUKtFZOdvgMZ0TgoCCdAH9dgbmN0Ougy9d" +
                "9MDR8X0jCmyRAaC+UKcX54+QlfYlefbhAD8iHmP8DKyfcVXTskbNGlWf+h0SCMMuhgdXwfR+GOekceg4" +
                "atx95DgY9RpDmtO/NccwglepCP45pWAdClCVTjYpR0Uv1di4yjxbQ35vCE8OzVWHBnpQZlvmMrasw058" +
                "H/o8iqw5ss0Snc4atoIefrS279jb4V0E82kai360wLhfphVAe4wjBg9pGxOEs40+b/Rp8lQ7tExo+hJ8" +
                "3b7StXQ3Tiya7vhOF42Cugq7YK1W6e7QmuVwMqgFw5X/bzGeTkFDdDs0xaRIKazbBeGKXN2taJ49fYtB" +
                "aJb7EJEr7EOZnA7rs+wknbgJaGV2EjDqcRjzflNcSrhnK/K3EbXEfx0X41hXEC8CQHYbBe3asZWFbhM9" +
                "rqb3ZeET+l9ZH3xXZG4C8nj8IvzTo5ujL7hHO/PbNILM3McY+8zOj+WaJUAOtmBh/USxmb4F9GW+G+a7" +
                "/36XgmP+ZhmPv9xPsvqUvz59PmZf53ZlfiDqcLeHvK8DW/YsKAgAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
