/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/ArcMoveActionFeedback")]
    public sealed class ArcMoveActionFeedback : IDeserializable<ArcMoveActionFeedback>, IActionFeedback<ArcMoveFeedback>
    {
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        [DataMember (Name = "status")] public ActionlibMsgs.GoalStatus Status { get; set; }
        [DataMember (Name = "feedback")] public ArcMoveFeedback Feedback { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public ArcMoveActionFeedback()
        {
            Status = new ActionlibMsgs.GoalStatus();
            Feedback = ArcMoveFeedback.Singleton;
        }
        
        /// <summary> Explicit constructor. </summary>
        public ArcMoveActionFeedback(in StdMsgs.Header Header, ActionlibMsgs.GoalStatus Status, ArcMoveFeedback Feedback)
        {
            this.Header = Header;
            this.Status = Status;
            this.Feedback = Feedback;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public ArcMoveActionFeedback(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            Status = new ActionlibMsgs.GoalStatus(ref b);
            Feedback = ArcMoveFeedback.Singleton;
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new ArcMoveActionFeedback(ref b);
        }
        
        ArcMoveActionFeedback IDeserializable<ArcMoveActionFeedback>.RosDeserialize(ref Buffer b)
        {
            return new ArcMoveActionFeedback(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            Header.RosSerialize(ref b);
            Status.RosSerialize(ref b);
            Feedback.RosSerialize(ref b);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Status is null) throw new System.NullReferenceException(nameof(Status));
            Status.RosValidate();
            if (Feedback is null) throw new System.NullReferenceException(nameof(Feedback));
            Feedback.RosValidate();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 0;
                size += Header.RosMessageLength;
                size += Status.RosMessageLength;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/ArcMoveActionFeedback";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "aae20e09065c3809e8a8e87c4c8953fd";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACr1WTW8bNxC9L+D/QECH2EHttEnTpgZ0UG3FUWAnhq32anDJ0S5bLlcluZL17/uGK61W" +
                "sYzokESQrS/yzeObN8P5QFKTF2V6yaSKpnbW5A9VKMKrq1ra+yhjE0RIL9nIq5t6Qe+JdC7Vv2K2fnOU" +
                "Db/x4yi7ub86R1zdcvmQGB5lAwFGTkuvRUVRahmlmNU4gSlK8qeWFmSZbTUnLdKvcTWncIaN09IEgWdB" +
                "jry0diWagEWxFqquqsYZJSOJaCra2Y+dxgkp5tJHoxorPdbXXhvHy2deVsToeAb6ryGnSEwuz7HGBVJN" +
                "NCC0AoLyJINxBX4UWWNcfPOaN2SD6bI+xUcqkIcuuIiljEyWHueeAvOU4RwxXraHOwM21CFE0UEcp+8e" +
                "8DGcCAQBBZrXqhTHYH67imXtAEhiIb2RuSUGVlAAqC9404uTHjLTPhdOunoD3yJuYxwC6zpcPtNpiZxZ" +
                "Pn1oCgiIhXNfL4zG0nyVQJQ15KKA+bz0q4x3tSGzwXvWGIuwK2UErzKEWhkkQIuliWUWomf0lI0Ho7Pv" +
                "ZshnS+Qo4/dIboEXpsA5frcpnPbD7fjT5eTTldg8huJn/GdnUtomShnEiiJ7MieWSLW5X2vUBkfa/QLV" +
                "2mKOLqaTv8eih/nLLiYnpfEe4sKHObFMBwHf3o3HN7fT8WUH/HoX2JMiuBvORNbhEP4GBRCikLMIM5vI" +
                "p/ecI3pMpeCKbEv06WOAP/gkqdB6DoU5t8QIJoYNCogeT8lXKEDL3SDSyZry/V8XF+PxZY/ym13KSyBL" +
                "VRp0CQ0rKlZh1nAr2CfEc2FGf36+2+rCYX7dEyav09F1k5y55b43km7oq9KwK0KNSphJYxtPz9G7G38c" +
                "X/T4DcXbp/Q8/UOK+e2lwzVVN/FLu/z0dY45KYm2mjC7YA1aZZRgyk0Czdq4hbRGP3eAtfO6ShmK336A" +
                "8zrruTqmItyar0tep/DF6Pp6W8lD8fuhBHPCbUV7GR6iLnLyNFu7pN3M+IrvNb5BujSk1sxMSO8com+T" +
                "d9/gEIfJzKbYKb82AN8cz3ji+vP9tA81FH8kwJHbiLG+QIAkNLLGINSKIDsJGOWsHQQCDG510i0/oPYC" +
                "Y2P0wR0NfZYGx0flINZu68wGI2vrZRpJeCFKAW/q7X0FMuu7imtM9EYs3qIpb4qCZVwvivQYsx96m00u" +
                "echiE7SDyFqnEDnjfKR0M0PVZWkwYaRbuddVkkFI80Q0SQNMmrH2SIX95NhCOCgF1giDDlVzpMta7GbM" +
                "0OZvSQjdQW/cB1eS566SGPUHhjV/NJh5O2SgG4MeGl0/EZvZlQ2JHZiyGhsxVIYgC84wshPmpMzMqE09" +
                "JAaBDcToPPG1C0CqalJdoNUZrDrb5A+rvl/2qjo3lh5yGehBe5Sqf/XFgH6E4P8DdKDsn+MLAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
