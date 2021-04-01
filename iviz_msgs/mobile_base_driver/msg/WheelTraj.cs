/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/WheelTraj")]
    public sealed class WheelTraj : IDeserializable<WheelTraj>, IMessage
    {
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        [DataMember (Name = "points")] public WheelTrajPoint[] Points { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public WheelTraj()
        {
            Points = System.Array.Empty<WheelTrajPoint>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public WheelTraj(in StdMsgs.Header Header, WheelTrajPoint[] Points)
        {
            this.Header = Header;
            this.Points = Points;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public WheelTraj(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            Points = b.DeserializeArray<WheelTrajPoint>();
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i] = new WheelTrajPoint(ref b);
            }
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new WheelTraj(ref b);
        }
        
        WheelTraj IDeserializable<WheelTraj>.RosDeserialize(ref Buffer b)
        {
            return new WheelTraj(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            Header.RosSerialize(ref b);
            b.SerializeArray(Points, 0);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Points is null) throw new System.NullReferenceException(nameof(Points));
            for (int i = 0; i < Points.Length; i++)
            {
                if (Points[i] is null) throw new System.NullReferenceException($"{nameof(Points)}[{i}]");
                Points[i].RosValidate();
            }
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += Header.RosMessageLength;
                size += 24 * Points.Length;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/WheelTraj";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "184f9008ae215cd8dbb2e259850ca0d4";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACrVTwYoUMRC9B/ofCuawu8LsgoqHAW+i60FY2AEPIk1Np6Y7kk7aSvWs/fe+9ODo3jxo" +
                "EwipvPfqVVX6XtiL0rBu7vMgEvfK3x5ySPblK011L65xb//x17hPjx92VMy3Y+nL3f1qoHEbejROntXT" +
                "KMaejemYYTD0g+g2ykkiWDxO4mm9tWWScgvifgiFsHpJohzjQnMByDJ1eRznFDo2IQujPOODGRIxTawW" +
                "ujmyAp/Vh1ThR+VRqjpWke+zpE7o47sdMKlIN1uAoQUKnQqXkHpckpvRtVcvK8Ft9k95i6P0aPMlOdnA" +
                "Vs3Kj0mlVJ9cdsjx4lzcLbTRHUEWX+h6jbU4lhtCEliQKXcDXcP5w2JDThAUOrEGPkSpwh06ANWrSrq6" +
                "+UO52t5R4pR/yZ8Vf+f4G9l00a01bQfMLNbqy9yjgQBOmk/BA3pYVpEuBklGMRyUdXGVdU7pNu9rjwEC" +
                "a50Idi4ldwED8PQUbHDFtKqv02iD/38PcsyHEKU9cJHWK4ard89/isb5WdlC7Q1qaI+axxaFqLljzGxv" +
                "XqPGJKwtHsYlxKmvL2uNNe4nCtHFT3UDAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
