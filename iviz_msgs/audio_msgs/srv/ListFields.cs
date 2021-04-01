using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [DataContract (Name = "audio_msgs/ListFields")]
    public sealed class ListFields : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public ListFieldsRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public ListFieldsResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public ListFields()
        {
            Request = ListFieldsRequest.Singleton;
            Response = new ListFieldsResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public ListFields(ListFieldsRequest request)
        {
            Request = request;
            Response = new ListFieldsResponse();
        }
        
        IService IService.Create() => new ListFields();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (ListFieldsRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (ListFieldsResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "audio_msgs/ListFields";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "83d03de94261ba4e29b909e51c50d482";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class ListFieldsRequest : IRequest<ListFields, ListFieldsResponse>, IDeserializable<ListFieldsRequest>
    {
    
        /// <summary> Constructor for empty message. </summary>
        public ListFieldsRequest()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public ListFieldsRequest(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        ListFieldsRequest IDeserializable<ListFieldsRequest>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly ListFieldsRequest Singleton = new ListFieldsRequest();
    
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
    public sealed class ListFieldsResponse : IResponse, IDeserializable<ListFieldsResponse>
    {
        [DataMember (Name = "fields")] public AudioMsgs.Field[] Fields { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public ListFieldsResponse()
        {
            Fields = System.Array.Empty<AudioMsgs.Field>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public ListFieldsResponse(AudioMsgs.Field[] Fields)
        {
            this.Fields = Fields;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public ListFieldsResponse(ref Buffer b)
        {
            Fields = b.DeserializeArray<AudioMsgs.Field>();
            for (int i = 0; i < Fields.Length; i++)
            {
                Fields[i] = new AudioMsgs.Field(ref b);
            }
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new ListFieldsResponse(ref b);
        }
        
        ListFieldsResponse IDeserializable<ListFieldsResponse>.RosDeserialize(ref Buffer b)
        {
            return new ListFieldsResponse(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.SerializeArray(Fields, 0);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Fields is null) throw new System.NullReferenceException(nameof(Fields));
            for (int i = 0; i < Fields.Length; i++)
            {
                if (Fields[i] is null) throw new System.NullReferenceException($"{nameof(Fields)}[{i}]");
                Fields[i].RosValidate();
            }
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                foreach (var i in Fields)
                {
                    size += i.RosMessageLength;
                }
                return size;
            }
        }
    
        public override string ToString() => Extensions.ToString(this);
    }
}
