using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [DataContract (Name = "audio_msgs/WakeUp")]
    public sealed class WakeUp : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public WakeUpRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public WakeUpResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public WakeUp()
        {
            Request = WakeUpRequest.Singleton;
            Response = new WakeUpResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public WakeUp(WakeUpRequest request)
        {
            Request = request;
            Response = new WakeUpResponse();
        }
        
        IService IService.Create() => new WakeUp();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (WakeUpRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (WakeUpResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "audio_msgs/WakeUp";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "af6d3a99f0fbeb66d3248fa4b3e675fb";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class WakeUpRequest : IRequest<WakeUp, WakeUpResponse>, IDeserializable<WakeUpRequest>
    {
    
        /// <summary> Constructor for empty message. </summary>
        public WakeUpRequest()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public WakeUpRequest(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        WakeUpRequest IDeserializable<WakeUpRequest>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly WakeUpRequest Singleton = new WakeUpRequest();
    
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
    public sealed class WakeUpResponse : IResponse, IDeserializable<WakeUpResponse>
    {
        [DataMember (Name = "state")] public string State { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public WakeUpResponse()
        {
            State = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public WakeUpResponse(string State)
        {
            this.State = State;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public WakeUpResponse(ref Buffer b)
        {
            State = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new WakeUpResponse(ref b);
        }
        
        WakeUpResponse IDeserializable<WakeUpResponse>.RosDeserialize(ref Buffer b)
        {
            return new WakeUpResponse(ref b);
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
