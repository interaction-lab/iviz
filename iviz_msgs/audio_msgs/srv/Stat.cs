using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [DataContract (Name = "audio_msgs/Stat")]
    public sealed class Stat : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public StatRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public StatResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public Stat()
        {
            Request = StatRequest.Singleton;
            Response = new StatResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public Stat(StatRequest request)
        {
            Request = request;
            Response = new StatResponse();
        }
        
        IService IService.Create() => new Stat();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (StatRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (StatResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "audio_msgs/Stat";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "6efbcf0c9bde4f3c542705ddc8687d07";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class StatRequest : IRequest<Stat, StatResponse>, IDeserializable<StatRequest>
    {
    
        /// <summary> Constructor for empty message. </summary>
        public StatRequest()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public StatRequest(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        StatRequest IDeserializable<StatRequest>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly StatRequest Singleton = new StatRequest();
    
        public void RosSerialize(ref Buffer b)
        {
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 0;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class StatResponse : IResponse, IDeserializable<StatResponse>
    {
        [DataMember (Name = "state")] public string State { get; set; }
        [DataMember (Name = "direction")] public string Direction { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public StatResponse()
        {
            State = string.Empty;
            Direction = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public StatResponse(string State, string Direction)
        {
            this.State = State;
            this.Direction = Direction;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public StatResponse(ref Buffer b)
        {
            State = b.DeserializeString();
            Direction = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new StatResponse(ref b);
        }
        
        StatResponse IDeserializable<StatResponse>.RosDeserialize(ref Buffer b)
        {
            return new StatResponse(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(State);
            b.Serialize(Direction);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (State is null) throw new System.NullReferenceException(nameof(State));
            if (Direction is null) throw new System.NullReferenceException(nameof(Direction));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 8;
                size += BuiltIns.UTF8.GetByteCount(State);
                size += BuiltIns.UTF8.GetByteCount(Direction);
                return size;
            }
        }
    
        public override string ToString() => Extensions.ToString(this);
    }
}
