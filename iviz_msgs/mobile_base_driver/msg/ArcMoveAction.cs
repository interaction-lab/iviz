/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/ArcMoveAction")]
    public sealed class ArcMoveAction : IDeserializable<ArcMoveAction>,
		IAction<ArcMoveActionGoal, ArcMoveActionFeedback, ArcMoveActionResult>
    {
        [DataMember (Name = "action_goal")] public ArcMoveActionGoal ActionGoal { get; set; }
        [DataMember (Name = "action_result")] public ArcMoveActionResult ActionResult { get; set; }
        [DataMember (Name = "action_feedback")] public ArcMoveActionFeedback ActionFeedback { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public ArcMoveAction()
        {
            ActionGoal = new ArcMoveActionGoal();
            ActionResult = new ArcMoveActionResult();
            ActionFeedback = new ArcMoveActionFeedback();
        }
        
        /// <summary> Explicit constructor. </summary>
        public ArcMoveAction(ArcMoveActionGoal ActionGoal, ArcMoveActionResult ActionResult, ArcMoveActionFeedback ActionFeedback)
        {
            this.ActionGoal = ActionGoal;
            this.ActionResult = ActionResult;
            this.ActionFeedback = ActionFeedback;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public ArcMoveAction(ref Buffer b)
        {
            ActionGoal = new ArcMoveActionGoal(ref b);
            ActionResult = new ArcMoveActionResult(ref b);
            ActionFeedback = new ArcMoveActionFeedback(ref b);
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new ArcMoveAction(ref b);
        }
        
        ArcMoveAction IDeserializable<ArcMoveAction>.RosDeserialize(ref Buffer b)
        {
            return new ArcMoveAction(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            ActionGoal.RosSerialize(ref b);
            ActionResult.RosSerialize(ref b);
            ActionFeedback.RosSerialize(ref b);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (ActionGoal is null) throw new System.NullReferenceException(nameof(ActionGoal));
            ActionGoal.RosValidate();
            if (ActionResult is null) throw new System.NullReferenceException(nameof(ActionResult));
            ActionResult.RosValidate();
            if (ActionFeedback is null) throw new System.NullReferenceException(nameof(ActionFeedback));
            ActionFeedback.RosValidate();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 0;
                size += ActionGoal.RosMessageLength;
                size += ActionResult.RosMessageLength;
                size += ActionFeedback.RosMessageLength;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/ArcMoveAction";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "08832ee4c8dbe58674e2b13f37b7db66";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACsVX224bNxB9X0D/QMAPsYvaaZNeUgN6UG3ZUWEnhq32VeDujnbZckmV5ErW3/cM9yIp" +
                "lhGhSGLBtkTtcObM7cx45LJbu6RRFpQ111ZqIePHWYHPyWj76T35WofuuYunXYkrojyV2T+dzLw9D5Lh" +
                "F34NktuH63NR2VRpmqXS0yx3aknu9ROHBsl7kjk5Uca3pMGmVTqrfOFfs8jkUrC7M5V3/sRI8HdfDboP" +
                "eQOgQTdIjsRDkCaXLhcVBZnLIMXcArYqSnKnmpakcUtWC8pFfBrWC/JnuDgtlRf4KciQk1qvRe0hFKzI" +
                "bFXVRmUykAiqop37uKmMkGIhXVBZraWDvHW5Miw+d7Ii1o4fT//WZDISk8tzyBhPWR0QblhSJnMkvTIF" +
                "HoqkVia8fcMXkqPpyp7iSAWC3xsXoZSBwdLjAjXEOKU/h43vGufOoBvRIVjJvTiO381w9CcCRgCBFjYr" +
                "xTGQ361DaQ0UklhKp2SqiRVniAC0vuJLr062NDPsc2GksZ36RuPGxiFqTa+XfTotkTPN3vu6QAAhuHB2" +
                "qXKIpuuoJNOKTBCoOCfdOuFbjcnk6IpjDCHcihnBu/TeZgoJyMVKhTLxwbH2mA0u0K9WkHv7gstyCh+a" +
                "1PnS1jrHwTpG3ZSUQDpXpUJOoh/cNGIlvXBcMx5+cA1NYspjVSIq0rTWkGeHpsV9MkIFAV/Jc92iNKha" +
                "gGy0xm3W6ZvCWRFM96pFSmgRQBAZuSCRPEa0HeIWv8q7tCDCgIfM2E2oRUdUQJbjRsNtaEPvZUExD8Iv" +
                "KFNzlTUOtgj8Waude6QRAKiq9gHIBBoPUmddCiGVvAATNhw411ZyY0qXzTSZ/ozSJelmaGWEIqw3cqbQ" +
                "tH1iengqltdOciJfjOGboXQAx4NcQ42Oj28dzbcjrcn3t+ysBs0g+WT6MHu+6zA2h7vxh8vJh2vRvYbi" +
                "B/xtqjqWYoleWxN6x3LNocqzhlVb9tlptFbn6GI6+WsstnT+uKuT6a52DrQFhk+Jq/cgxXf34/Ht3XR8" +
                "2St+s6vYUUZIIjgffAru7TtJyHlA/sAB8N5xa9NjHDKmSDZAn76O8IumjVFo2Bwjb6GJNajgOy0Aejwl" +
                "V2G0aZ6zgU5ayA9/XlyMx5dbkN/uQmYuk1mpMH9BfXXGUZjXPGT3BeI5M6PfP95v4sJmftpjJrXRdXQV" +
                "h3yDfa+lvKbPhoarwluw4VwqXYMpn4F3P/5jfLGFbyh+fgrP0d+URdbdB4dZ0tbh03L5/vMYU8okRkPU" +
                "2RursYQwo8fxizVImaXUoPFnHGgrr++UofjlG1ReX3rGhtiEm+Lrk9dH+GJ0c7Pp5KH49VCA7ZDbh/CQ" +
                "6CInT7O1C9rMlat4Y+QR26chLj2MhPIdJ7bL5N0XcOKwMHNR7LRfY4B3smdq4ubjw3Rb1VD8FhWO+vWj" +
                "Xc2gSeTIGiuhJgiyDwFr4TGPj+3+w3FLD+g9z7oxZbD9Ij4rBff3LD9YUUZa21Vc9lkQreB21xOJmEVG" +
                "iJvI1jTjKzmldVFwGFuhQI/hRTaNbha/2DJw1f+/+f/Wge5+vw++gCcbHwbJfw1Q/IidDwAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
