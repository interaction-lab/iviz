/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [Preserve, DataContract (Name = "may_nav_msgs/NavigateActionGoal")]
    public sealed class NavigateActionGoal : IDeserializable<NavigateActionGoal>, IActionGoal<NavigateGoal>
    {
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        [DataMember (Name = "goal_id")] public ActionlibMsgs.GoalID GoalId { get; set; }
        [DataMember (Name = "goal")] public NavigateGoal Goal { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public NavigateActionGoal()
        {
            GoalId = new ActionlibMsgs.GoalID();
            Goal = new NavigateGoal();
        }
        
        /// <summary> Explicit constructor. </summary>
        public NavigateActionGoal(in StdMsgs.Header Header, ActionlibMsgs.GoalID GoalId, NavigateGoal Goal)
        {
            this.Header = Header;
            this.GoalId = GoalId;
            this.Goal = Goal;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public NavigateActionGoal(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            GoalId = new ActionlibMsgs.GoalID(ref b);
            Goal = new NavigateGoal(ref b);
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new NavigateActionGoal(ref b);
        }
        
        NavigateActionGoal IDeserializable<NavigateActionGoal>.RosDeserialize(ref Buffer b)
        {
            return new NavigateActionGoal(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            Header.RosSerialize(ref b);
            GoalId.RosSerialize(ref b);
            Goal.RosSerialize(ref b);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (GoalId is null) throw new System.NullReferenceException(nameof(GoalId));
            GoalId.RosValidate();
            if (Goal is null) throw new System.NullReferenceException(nameof(Goal));
            Goal.RosValidate();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 57;
                size += Header.RosMessageLength;
                size += GoalId.RosMessageLength;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "may_nav_msgs/NavigateActionGoal";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "5bf8324d0bae9b462bce419378541d81";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACr1UTW/bOBC9E8h/GCCHfmDjbbvFHgLkECBpaqCJs63RYk/CWBpLxEqkSlJ21V/fN5Rj" +
                "J9gC7aFpYEQSOR/vzZuZt8KVBGryw3CZrHetXRVdrOOfV57b+QXVeBS2Mje8sTUn0eN8eGTOfvHfkbn+" +
                "cHVKMVUTgrcZ15E5pg+JXcWhok4SV5yY1h64bd1IOGllIy28uOulonybxl7iDI7LxkbCrxYngdt2pCHC" +
                "KHkqfdcNzpagRMl28sAfntYRU88h2XJoOcDeh8o6NV8H7kSj4xfl8yCuFJpfnMLGRSmHZAFoRIQyCEfr" +
                "alySGaxLf71SB3O83PoTfEqN6u+TU2o4KVj50geJipPjKXI8n8jNEBvVEWSpIj3NZwU+4zNCEkCQ3pcN" +
                "PQXy2zE13iGg0IaD5VUrGrhEBRD1iTo9eXYvssI+JcfO34WfIh5y/ExYt4+rnE4aaNYq+zjUKCAM++A3" +
                "toLpasxBytaKS4SWCxxGo15TSnP8RmsMI3hlRfDkGH1pIUBFW5saE1PQ6FkN7dBHa8jvDoa25RIcJuli" +
                "44e2wocPinpqKYKc28ZCk8xDh4a2HCloz0Tw0B6aZ8lzV6Iq7HbZoHPYoDu2jTiyicBVovYtWkO6PhFq" +
                "Dm+NGafG2QpS70PTSjAigEClhMQQTxHdL/EOv63uZEGFAQ/K+EOpaS1Srbj8D8gqeKAvhzZhDGPkWrIO" +
                "FHsp7dqWE8EdgjjbRdcZmQwAqhtiAjLC4MFqdichrB5PvY7HwvFm0u7+FjsyqxEMrxbFclF8Ov/3djG/" +
                "WZ69mE4v3s8/XupFPi3mN8X8+vzq8uzldP1m8e7d4lNxfXn2ykwnmkLXjqnFY0uFcUp4i4miHv8ejd//" +
                "82lrnkMI3SKYL8795NcZhu61NVoIonApf+ga1ONqd2+zLbQmj4bb+c7I3Hqsq72B+WdADYPLcQ925rdx" +
                "BJhp/nT7eKS3TqdADhRAB+s7o37A2Kxbz+nv1/Rl/zbu377+LgaH+u1p7OXCGD6o6kP8+vX5UH3MeDcz" +
                "PyB197YFvW+s5dl/8wcAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
