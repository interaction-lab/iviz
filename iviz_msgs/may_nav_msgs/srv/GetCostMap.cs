using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [DataContract (Name = "may_nav_msgs/GetCostMap")]
    public sealed class GetCostMap : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public GetCostMapRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public GetCostMapResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public GetCostMap()
        {
            Request = new GetCostMapRequest();
            Response = new GetCostMapResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public GetCostMap(GetCostMapRequest request)
        {
            Request = request;
            Response = new GetCostMapResponse();
        }
        
        IService IService.Create() => new GetCostMap();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (GetCostMapRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (GetCostMapResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "may_nav_msgs/GetCostMap";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "7c7e6394fa7408b42079b9e56f62c547";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class GetCostMapRequest : IRequest<GetCostMap, GetCostMapResponse>, IDeserializable<GetCostMapRequest>
    {
        [DataMember (Name = "use_dynamic_map")] public bool UseDynamicMap { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public GetCostMapRequest()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public GetCostMapRequest(bool UseDynamicMap)
        {
            this.UseDynamicMap = UseDynamicMap;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public GetCostMapRequest(ref Buffer b)
        {
            UseDynamicMap = b.Deserialize<bool>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new GetCostMapRequest(ref b);
        }
        
        GetCostMapRequest IDeserializable<GetCostMapRequest>.RosDeserialize(ref Buffer b)
        {
            return new GetCostMapRequest(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(UseDynamicMap);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 1;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class GetCostMapResponse : IResponse, IDeserializable<GetCostMapResponse>
    {
        [DataMember (Name = "cost_map")] public MayNavMsgs.CostMap CostMap { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public GetCostMapResponse()
        {
            CostMap = new MayNavMsgs.CostMap();
        }
        
        /// <summary> Explicit constructor. </summary>
        public GetCostMapResponse(MayNavMsgs.CostMap CostMap)
        {
            this.CostMap = CostMap;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public GetCostMapResponse(ref Buffer b)
        {
            CostMap = new MayNavMsgs.CostMap(ref b);
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new GetCostMapResponse(ref b);
        }
        
        GetCostMapResponse IDeserializable<GetCostMapResponse>.RosDeserialize(ref Buffer b)
        {
            return new GetCostMapResponse(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            CostMap.RosSerialize(ref b);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (CostMap is null) throw new System.NullReferenceException(nameof(CostMap));
            CostMap.RosValidate();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 0;
                size += CostMap.RosMessageLength;
                return size;
            }
        }
    
        public override string ToString() => Extensions.ToString(this);
    }
}
