using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [DataContract (Name = "may_nav_msgs/GetObstacleDist")]
    public sealed class GetObstacleDist : IService
    {
        /// <summary> Request message. </summary>
        [DataMember] public GetObstacleDistRequest Request { get; set; }
        
        /// <summary> Response message. </summary>
        [DataMember] public GetObstacleDistResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public GetObstacleDist()
        {
            Request = GetObstacleDistRequest.Singleton;
            Response = new GetObstacleDistResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public GetObstacleDist(GetObstacleDistRequest request)
        {
            Request = request;
            Response = new GetObstacleDistResponse();
        }
        
        IService IService.Create() => new GetObstacleDist();
        
        IRequest IService.Request
        {
            get => Request;
            set => Request = (GetObstacleDistRequest)value;
        }
        
        IResponse IService.Response
        {
            get => Response;
            set => Response = (GetObstacleDistResponse)value;
        }
        
        public void Dispose()
        {
            Request.Dispose();
            Response.Dispose();
        }
        
        string IService.RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve] public const string RosServiceType = "may_nav_msgs/GetObstacleDist";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve] public const string RosMd5Sum = "444b488bceb285c64c25be6c2269d8db";
        
        public override string ToString() => Extensions.ToString(this);
    }

    [DataContract]
    public sealed class GetObstacleDistRequest : IRequest<GetObstacleDist, GetObstacleDistResponse>, IDeserializable<GetObstacleDistRequest>
    {
    
        /// <summary> Constructor for empty message. </summary>
        public GetObstacleDistRequest()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public GetObstacleDistRequest(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        GetObstacleDistRequest IDeserializable<GetObstacleDistRequest>.RosDeserialize(ref Buffer b)
        {
            return Singleton;
        }
        
        public static readonly GetObstacleDistRequest Singleton = new GetObstacleDistRequest();
    
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
    public sealed class GetObstacleDistResponse : IResponse, IDeserializable<GetObstacleDistResponse>
    {
        [DataMember (Name = "obstacle_dist")] public double ObstacleDist { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public GetObstacleDistResponse()
        {
        }
        
        /// <summary> Explicit constructor. </summary>
        public GetObstacleDistResponse(double ObstacleDist)
        {
            this.ObstacleDist = ObstacleDist;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public GetObstacleDistResponse(ref Buffer b)
        {
            ObstacleDist = b.Deserialize<double>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new GetObstacleDistResponse(ref b);
        }
        
        GetObstacleDistResponse IDeserializable<GetObstacleDistResponse>.RosDeserialize(ref Buffer b)
        {
            return new GetObstacleDistResponse(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(ObstacleDist);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 8;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public override string ToString() => Extensions.ToString(this);
    }
}
