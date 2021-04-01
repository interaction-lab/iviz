using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [DataContract (Name = "audio_msgs/SetField")]
    public sealed class SetField : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public SetFieldRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public SetFieldResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public SetField()
        {
            Request = new SetFieldRequest();
            Response = SetFieldResponse.Singleton;
        }
        
        /// <summary> Setter constructor. </summary>
        public SetField(SetFieldRequest request)
        {
            Request = request;
            Response = SetFieldResponse.Singleton;
        }
        
        IService IService.Create() => new SetField();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (SetFieldRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (SetFieldResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "audio_msgs/SetField";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "bed64f0c585e577c90cce651a3e4553f";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class SetFieldRequest : IRequest<SetField, SetFieldResponse>, IDeserializable<SetFieldRequest>
    {
        [DataMember (Name = "name")] public string Name { get; set; }
        [DataMember (Name = "json_value")] public string JsonValue { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public SetFieldRequest()
        {
            Name = string.Empty;
            JsonValue = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public SetFieldRequest(string Name, string JsonValue)
        {
            this.Name = Name;
            this.JsonValue = JsonValue;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public SetFieldRequest(ref Buffer b)
        {
            Name = b.DeserializeString();
            JsonValue = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new SetFieldRequest(ref b);
        }
        
        SetFieldRequest IDeserializable<SetFieldRequest>.RosDeserialize(ref Buffer b)
        {
            return new SetFieldRequest(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Name);
            b.Serialize(JsonValue);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Name is null) throw new System.NullReferenceException(nameof(Name));
            if (JsonValue is null) throw new System.NullReferenceException(nameof(JsonValue));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 8;
                size += BuiltIns.UTF8.GetByteCount(Name);
                size += BuiltIns.UTF8.GetByteCount(JsonValue);
                return size;
            }
        }
    
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class SetFieldResponse : IResponse, IDeserializable<SetFieldResponse>
    {
    
        /// <summary> Constructor for empty message. </summary>
        public SetFieldResponse()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public SetFieldResponse(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        SetFieldResponse IDeserializable<SetFieldResponse>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly SetFieldResponse Singleton = new SetFieldResponse();
    
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
