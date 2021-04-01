using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [DataContract (Name = "audio_msgs/GetDirection")]
    public sealed class GetDirection : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public GetDirectionRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public GetDirectionResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public GetDirection()
        {
            Request = new GetDirectionRequest();
            Response = new GetDirectionResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public GetDirection(GetDirectionRequest request)
        {
            Request = request;
            Response = new GetDirectionResponse();
        }
        
        IService IService.Create() => new GetDirection();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (GetDirectionRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (GetDirectionResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "audio_msgs/GetDirection";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "18df3bbfde541a22f50d99a6830ed9b3";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class GetDirectionRequest : IRequest<GetDirection, GetDirectionResponse>, IDeserializable<GetDirectionRequest>
    {
        [DataMember (Name = "threshold")] public byte Threshold { get; set; }
        [DataMember (Name = "ms_duration")] public ushort MsDuration { get; set; }
        [DataMember (Name = "ms_delay")] public ushort MsDelay { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public GetDirectionRequest()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public GetDirectionRequest(byte Threshold, ushort MsDuration, ushort MsDelay)
        {
            this.Threshold = Threshold;
            this.MsDuration = MsDuration;
            this.MsDelay = MsDelay;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public GetDirectionRequest(ref Buffer b)
        {
            Threshold = b.Deserialize<byte>();
            MsDuration = b.Deserialize<ushort>();
            MsDelay = b.Deserialize<ushort>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new GetDirectionRequest(ref b);
        }
        
        GetDirectionRequest IDeserializable<GetDirectionRequest>.RosDeserialize(ref Buffer b)
        {
            return new GetDirectionRequest(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Threshold);
            b.Serialize(MsDuration);
            b.Serialize(MsDelay);
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
    
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class GetDirectionResponse : IResponse, IDeserializable<GetDirectionResponse>
    {
        [DataMember (Name = "direction")] public GeometryMsgs.Vector3 Direction { get; set; }
        [DataMember (Name = "relative_angle")] public ushort RelativeAngle { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public GetDirectionResponse()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public GetDirectionResponse(in GeometryMsgs.Vector3 Direction, ushort RelativeAngle)
        {
            this.Direction = Direction;
            this.RelativeAngle = RelativeAngle;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public GetDirectionResponse(ref Buffer b)
        {
            Direction = new GeometryMsgs.Vector3(ref b);
            RelativeAngle = b.Deserialize<ushort>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new GetDirectionResponse(ref b);
        }
        
        GetDirectionResponse IDeserializable<GetDirectionResponse>.RosDeserialize(ref Buffer b)
        {
            return new GetDirectionResponse(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            Direction.RosSerialize(ref b);
            b.Serialize(RelativeAngle);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 26;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public override string ToString() => Extensions.ToString(this);
    }
}
