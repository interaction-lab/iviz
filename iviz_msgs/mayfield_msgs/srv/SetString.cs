using System.Runtime.Serialization;

namespace Iviz.Msgs.MayfieldMsgs
{
    [DataContract (Name = "mayfield_msgs/SetString")]
    public sealed class SetString : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public SetStringRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public SetStringResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public SetString()
        {
            Request = new SetStringRequest();
            Response = SetStringResponse.Singleton;
        }
        
        /// <summary> Setter constructor. </summary>
        public SetString(SetStringRequest request)
        {
            Request = request;
            Response = SetStringResponse.Singleton;
        }
        
        IService IService.Create() => new SetString();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (SetStringRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (SetStringResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "mayfield_msgs/SetString";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "992ce8a1687cec8c8bd883ec73ca41d1";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class SetStringRequest : IRequest<SetString, SetStringResponse>, IDeserializable<SetStringRequest>
    {
        [DataMember (Name = "data")] public string Data { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public SetStringRequest()
        {
            Data = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public SetStringRequest(string Data)
        {
            this.Data = Data;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public SetStringRequest(ref Buffer b)
        {
            Data = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new SetStringRequest(ref b);
        }
        
        SetStringRequest IDeserializable<SetStringRequest>.RosDeserialize(ref Buffer b)
        {
            return new SetStringRequest(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Data);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Data is null) throw new System.NullReferenceException(nameof(Data));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += BuiltIns.UTF8.GetByteCount(Data);
                return size;
            }
        }
    
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class SetStringResponse : IResponse, IDeserializable<SetStringResponse>
    {
    
        /// <summary> Constructor for empty message. </summary>
        public SetStringResponse()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public SetStringResponse(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        SetStringResponse IDeserializable<SetStringResponse>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly SetStringResponse Singleton = new SetStringResponse();
    
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
}
