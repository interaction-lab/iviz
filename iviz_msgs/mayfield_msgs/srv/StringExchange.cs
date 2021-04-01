using System.Runtime.Serialization;

namespace Iviz.Msgs.MayfieldMsgs
{
    [DataContract (Name = "mayfield_msgs/StringExchange")]
    public sealed class StringExchange : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public StringExchangeRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public StringExchangeResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public StringExchange()
        {
            Request = new StringExchangeRequest();
            Response = new StringExchangeResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public StringExchange(StringExchangeRequest request)
        {
            Request = request;
            Response = new StringExchangeResponse();
        }
        
        IService IService.Create() => new StringExchange();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (StringExchangeRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (StringExchangeResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "mayfield_msgs/StringExchange";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "8b07386faeaa10fd20f5d838aa59f460";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class StringExchangeRequest : IRequest<StringExchange, StringExchangeResponse>, IDeserializable<StringExchangeRequest>
    {
        [DataMember (Name = "in_str")] public string InStr { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public StringExchangeRequest()
        {
            InStr = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public StringExchangeRequest(string InStr)
        {
            this.InStr = InStr;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public StringExchangeRequest(ref Buffer b)
        {
            InStr = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new StringExchangeRequest(ref b);
        }
        
        StringExchangeRequest IDeserializable<StringExchangeRequest>.RosDeserialize(ref Buffer b)
        {
            return new StringExchangeRequest(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(InStr);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (InStr is null) throw new System.NullReferenceException(nameof(InStr));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += BuiltIns.UTF8.GetByteCount(InStr);
                return size;
            }
        }
    
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class StringExchangeResponse : IResponse, IDeserializable<StringExchangeResponse>
    {
        [DataMember (Name = "out_str")] public string OutStr { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public StringExchangeResponse()
        {
            OutStr = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public StringExchangeResponse(string OutStr)
        {
            this.OutStr = OutStr;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public StringExchangeResponse(ref Buffer b)
        {
            OutStr = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new StringExchangeResponse(ref b);
        }
        
        StringExchangeResponse IDeserializable<StringExchangeResponse>.RosDeserialize(ref Buffer b)
        {
            return new StringExchangeResponse(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(OutStr);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (OutStr is null) throw new System.NullReferenceException(nameof(OutStr));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += BuiltIns.UTF8.GetByteCount(OutStr);
                return size;
            }
        }
    
        public override string ToString() => Extensions.ToString(this);
    }
}
