/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/Telescope")]
    public sealed class Telescope : IDeserializable<Telescope>, IMessage
    {
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        [DataMember (Name = "front_noise")] public bool FrontNoise { get; set; }
        [DataMember (Name = "front_left")] public bool FrontLeft { get; set; }
        [DataMember (Name = "front_right")] public bool FrontRight { get; set; }
        [DataMember (Name = "front_middle")] public bool FrontMiddle { get; set; }
        [DataMember (Name = "back_noise")] public bool BackNoise { get; set; }
        [DataMember (Name = "back_left")] public bool BackLeft { get; set; }
        [DataMember (Name = "back_right")] public bool BackRight { get; set; }
        [DataMember (Name = "back_middle")] public bool BackMiddle { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Telescope()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public Telescope(in StdMsgs.Header Header, bool FrontNoise, bool FrontLeft, bool FrontRight, bool FrontMiddle, bool BackNoise, bool BackLeft, bool BackRight, bool BackMiddle)
        {
            this.Header = Header;
            this.FrontNoise = FrontNoise;
            this.FrontLeft = FrontLeft;
            this.FrontRight = FrontRight;
            this.FrontMiddle = FrontMiddle;
            this.BackNoise = BackNoise;
            this.BackLeft = BackLeft;
            this.BackRight = BackRight;
            this.BackMiddle = BackMiddle;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Telescope(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            FrontNoise = b.Deserialize<bool>();
            FrontLeft = b.Deserialize<bool>();
            FrontRight = b.Deserialize<bool>();
            FrontMiddle = b.Deserialize<bool>();
            BackNoise = b.Deserialize<bool>();
            BackLeft = b.Deserialize<bool>();
            BackRight = b.Deserialize<bool>();
            BackMiddle = b.Deserialize<bool>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Telescope(ref b);
        }
        
        Telescope IDeserializable<Telescope>.RosDeserialize(ref Buffer b)
        {
            return new Telescope(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            Header.RosSerialize(ref b);
            b.Serialize(FrontNoise);
            b.Serialize(FrontLeft);
            b.Serialize(FrontRight);
            b.Serialize(FrontMiddle);
            b.Serialize(BackNoise);
            b.Serialize(BackLeft);
            b.Serialize(BackRight);
            b.Serialize(BackMiddle);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        public int RosMessageLength
        {
            get {
                int size = 8;
                size += Header.RosMessageLength;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/Telescope";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "d73db4ad7bf87689fa1b86ed4b74ff85";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACq2STWscMQyG74b9D4I9JClsCu1tobeQJodAILkvGls7I+KxJ5Zm0/n3lb1pM7n10MFg" +
                "JOt99DV3hIEKDO1yXc4RjiUnPaTMQmtHpKOu7cL98MkxcgjxXdKhf1kjmv1BaOYK0Ox3/cb9+M/fxj08" +
                "/dyDaDiM0svXu9bsxm3hSTEFLAFGUgyoCMdsw7DCqOwinSiaCseJArRXXSaSaxM+Dyxgp6dEBWNcYBYL" +
                "0gw+j+Oc2KMSKI/0SW9KToAwYVH2c8Ri8bkETjX8WHCkSrcj9DpT8gT3N3uLSUJ+VraCFiP4QiicensE" +
                "N3PS79+qwG2f3/LOTOptpX+Tgw6otVj6NRWSWifK3nJ8OTd3bWybDlmWIHDZfAcz5QosiSegKfsBLq3y" +
                "x0WHnAxIcMLC2EWqYG8TMOpFFV1crci17D0kTPkP/kz8yPEv2Eo5c2tPu8F2Fmv3Mvc2QAucSj5xsNBu" +
                "aRAfmZJC5K5gWVxVnVO67W2dsQWZqm3EbhTJnm0BAd5YBydaKr1t48DBfsjf739Y7CUDAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
