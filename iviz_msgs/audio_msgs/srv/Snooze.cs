using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [DataContract (Name = "audio_msgs/Snooze")]
    public sealed class Snooze : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public SnoozeRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public SnoozeResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public Snooze()
        {
            Request = SnoozeRequest.Singleton;
            Response = new SnoozeResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public Snooze(SnoozeRequest request)
        {
            Request = request;
            Response = new SnoozeResponse();
        }
        
        IService IService.Create() => new Snooze();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (SnoozeRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (SnoozeResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "audio_msgs/Snooze";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "af6d3a99f0fbeb66d3248fa4b3e675fb";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class SnoozeRequest : IRequest<Snooze, SnoozeResponse>, IDeserializable<SnoozeRequest>
    {
    
        /// <summary> Constructor for empty message. </summary>
        public SnoozeRequest()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public SnoozeRequest(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        SnoozeRequest IDeserializable<SnoozeRequest>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly SnoozeRequest Singleton = new SnoozeRequest();
    
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
    public sealed class SnoozeResponse : IResponse, IDeserializable<SnoozeResponse>
    {
        [DataMember (Name = "state")] public string State { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public SnoozeResponse()
        {
            State = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public SnoozeResponse(string State)
        {
            this.State = State;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public SnoozeResponse(ref Buffer b)
        {
            State = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new SnoozeResponse(ref b);
        }
        
        SnoozeResponse IDeserializable<SnoozeResponse>.RosDeserialize(ref Buffer b)
        {
            return new SnoozeResponse(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(State);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (State is null) throw new System.NullReferenceException(nameof(State));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += BuiltIns.UTF8.GetByteCount(State);
                return size;
            }
        }
    
        public override string ToString() => Extensions.ToString(this);
    }
}
