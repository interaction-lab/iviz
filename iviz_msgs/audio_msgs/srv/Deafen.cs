using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [DataContract (Name = "audio_msgs/Deafen")]
    public sealed class Deafen : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public DeafenRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public DeafenResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public Deafen()
        {
            Request = DeafenRequest.Singleton;
            Response = new DeafenResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public Deafen(DeafenRequest request)
        {
            Request = request;
            Response = new DeafenResponse();
        }
        
        IService IService.Create() => new Deafen();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (DeafenRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (DeafenResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "audio_msgs/Deafen";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "af6d3a99f0fbeb66d3248fa4b3e675fb";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class DeafenRequest : IRequest<Deafen, DeafenResponse>, IDeserializable<DeafenRequest>
    {
    
        /// <summary> Constructor for empty message. </summary>
        public DeafenRequest()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public DeafenRequest(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        DeafenRequest IDeserializable<DeafenRequest>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly DeafenRequest Singleton = new DeafenRequest();
    
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
    public sealed class DeafenResponse : IResponse, IDeserializable<DeafenResponse>
    {
        [DataMember (Name = "state")] public string State { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public DeafenResponse()
        {
            State = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public DeafenResponse(string State)
        {
            this.State = State;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public DeafenResponse(ref Buffer b)
        {
            State = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new DeafenResponse(ref b);
        }
        
        DeafenResponse IDeserializable<DeafenResponse>.RosDeserialize(ref Buffer b)
        {
            return new DeafenResponse(ref b);
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
