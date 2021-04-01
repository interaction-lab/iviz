using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [DataContract (Name = "audio_msgs/GetField")]
    public sealed class GetField : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public GetFieldRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public GetFieldResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public GetField()
        {
            Request = new GetFieldRequest();
            Response = new GetFieldResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public GetField(GetFieldRequest request)
        {
            Request = request;
            Response = new GetFieldResponse();
        }
        
        IService IService.Create() => new GetField();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (GetFieldRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (GetFieldResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "audio_msgs/GetField";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "fefc1eaa409232c39ae3f696ddd678d5";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class GetFieldRequest : IRequest<GetField, GetFieldResponse>, IDeserializable<GetFieldRequest>
    {
        [DataMember (Name = "name")] public string Name { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public GetFieldRequest()
        {
            Name = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public GetFieldRequest(string Name)
        {
            this.Name = Name;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public GetFieldRequest(ref Buffer b)
        {
            Name = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new GetFieldRequest(ref b);
        }
        
        GetFieldRequest IDeserializable<GetFieldRequest>.RosDeserialize(ref Buffer b)
        {
            return new GetFieldRequest(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Name);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Name is null) throw new System.NullReferenceException(nameof(Name));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += BuiltIns.UTF8.GetByteCount(Name);
                return size;
            }
        }
    
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class GetFieldResponse : IResponse, IDeserializable<GetFieldResponse>
    {
        [DataMember (Name = "json_value")] public string JsonValue { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public GetFieldResponse()
        {
            JsonValue = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public GetFieldResponse(string JsonValue)
        {
            this.JsonValue = JsonValue;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public GetFieldResponse(ref Buffer b)
        {
            JsonValue = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new GetFieldResponse(ref b);
        }
        
        GetFieldResponse IDeserializable<GetFieldResponse>.RosDeserialize(ref Buffer b)
        {
            return new GetFieldResponse(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(JsonValue);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (JsonValue is null) throw new System.NullReferenceException(nameof(JsonValue));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += BuiltIns.UTF8.GetByteCount(JsonValue);
                return size;
            }
        }
    
        public override string ToString() => Extensions.ToString(this);
    }
}
