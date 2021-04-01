/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [Preserve, DataContract (Name = "may_nav_msgs/NavigateActionFeedback")]
    public sealed class NavigateActionFeedback : IDeserializable<NavigateActionFeedback>, IActionFeedback<NavigateFeedback>
    {
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        [DataMember (Name = "status")] public ActionlibMsgs.GoalStatus Status { get; set; }
        [DataMember (Name = "feedback")] public NavigateFeedback Feedback { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public NavigateActionFeedback()
        {
            Status = new ActionlibMsgs.GoalStatus();
            Feedback = new NavigateFeedback();
        }
        
        /// <summary> Explicit constructor. </summary>
        public NavigateActionFeedback(in StdMsgs.Header Header, ActionlibMsgs.GoalStatus Status, NavigateFeedback Feedback)
        {
            this.Header = Header;
            this.Status = Status;
            this.Feedback = Feedback;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public NavigateActionFeedback(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            Status = new ActionlibMsgs.GoalStatus(ref b);
            Feedback = new NavigateFeedback(ref b);
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new NavigateActionFeedback(ref b);
        }
        
        NavigateActionFeedback IDeserializable<NavigateActionFeedback>.RosDeserialize(ref Buffer b)
        {
            return new NavigateActionFeedback(ref b);
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
                size += Feedback.RosMessageLength;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "may_nav_msgs/NavigateActionFeedback";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "9254b32a38c4ad78d46b53c9082e11de";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACr1X23LbNhB954z/ATN+cNKJ1TZJ09QzfnAtJVEmF0/s9FUDkUsKDQiwACiZf9+zAElJ" +
                "sTzxQxKNbPEC7J7dPXvBG5IFObGKP5nMg7JGq+Wi9pX/9bWV+jrI0Hrh40/2Qa5VJQO9IiqWMv8iyv7i" +
                "KDv/zp+j7P316zMoLhKYNxHiUXYsAMkU0hWipiALGaQoLUxQ1YrcqaY1aYZbN1SI+DZ0DfkJNt6slBf4" +
                "VmTISa070XosClbktq5bo3KYJoKqaW8/diojpGikCypvtXRYb12hDC8vnayJpePr6b+WTE5iPj3DGuMp" +
                "b4MCoA4SckfSK1PhpchaZcKzp7whO77Z2FPcUoVAjMpFWMnAYOm2ceQZp/Rn0PFLMm4C2fAOQUvhxaP4" +
                "bIFb/1hACSBQY/OVeATkV11YWQOBJNbSKbnUxIJzeABST3jTyeMdyQz7TBhp7CA+SdzqeIhYM8plm05X" +
                "iJlm631bwYFY2Di7VgWWLrsoJNeKTBBgn5Ouy3hXUpkdv2IfYxF2xYjgV3pvc4UAFGKjwirzwbH0GI2F" +
                "KrIfRsh7c+Qo42sEt8IPQ+AYvxwyJ91czT5M5x9ei+FzLn7Df2YmxW1iJb3oKDAnl8QuylPsex8l5Qi7" +
                "WyNdk8yLy5v5PzOxI/P3fZkclNY5OBc8XBK76UGCrz7NZu+vbmbTUfDTfcGOcgK7wUxEHQzhJ0gAH4Qs" +
                "A8isAlvvOEZ0G1PBVNkW6N3PMf7Ak+iFxDkkZqOJJajgBykA+uiGXI0E1FwNAj3uIV9/vryczaY7kJ/t" +
                "Q95AssxXClWiABVz9kLZcik45Ij71Fz8/fHT1i+s5vkBNUsbTS/ayMwt9oOaipa+6RpmhbfIhFIq3Tq6" +
                "D96n2dvZ5Q6+c/HHXXiO/qWc8R2Ewzll2/A1XZ58G+OScomyGmWOylqUyiCBlIsEirUya6lVcZ8BPfPG" +
                "TDkXL34C80bqGRtiEm7JNwZv9PDlxbt320w+F38+FOCS0K3oIMKHeBcxuRutfdCmVK7mvsYdZAxDLM2M" +
                "hIo9I3Zp8vI7GPEwNzMp9tIvKeDOcQ8n3n28vtkVdS7+igIvzOCMvoFAkigQNRZCyQlydAFLmaRBwIPg" +
                "uoh+Wz4g9zzLtuxtdulGwXxkDnTtl87s+EJru4kjCS9EKuDCbvsVwPS9inNM7MxYvKWgZVtV7MZ+UaDb" +
                "kP3Ubjaf8pDFJEiDSO8nHzjibFLszPDqZqUwYcSuvFNVIkGo4IloHgeYOGMdcBX2k2EKwVDy7CMMOlQ3" +
                "CJfW2M0yfYrfhqB6FD2wD6wkx1UlItodGHr8KDD9kIFqDHjdfiCG2ZUJiR2YslodMFR6LytK0fEN5apU" +
                "+ZAPEYGf9NJ54ksLAKpuY16g1Cmsmgzxw6ofF71adgsj1yl2X8/mR9mAgUcQ2r9b1NwFDS36d1lFaCzB" +
                "dUnWFUa/p1OB3K4oLBrcHV6Q18UC422WLa2Nw8ti2fLgPMy3pq0XjhotjU9L0s2ib2ALm8fJpPhhHjqE" +
                "muk9JZCNx30O4pXGZB5TNfKbC5J4NhVs9oS5NDfDkUHY1nFZxHGBcAaJbAbFQSveLMetMBN0QsVIS2wp" +
                "MHA4DMwcAK5/nOvw38gv2TSajx9Y7RHWLwkJnjrbuMhWXHHDjgvgXBsXsDNpqDUK5xKp+YCSVnGvsA3S" +
                "Ih51NgrQIiokX9wMnMpgb51A9nNK3+txmWwvkX2ILPbg/MOzvUaLaThjYRVM4IE8nrCSieLzPBpoocGJ" +
                "RjWEqZ+SdrhMtI0wIGgsbTbJLVquzTgAuVLmfSXQqMpbl01Q5QvR2XZPTszQVL6jW3m26CMB0wLolmoq" +
                "QPKzHDGOIBGykh3QnaCIDD0eHoojyRMUCNZ0wqMAO8oimIrXIOKoZyGpLVRZoijxE9O0GE2jzW3g6wkK" +
                "30lqyNsjI+Sv+Mw6GMcBADDmGA9EDKPlwyced3IjyDk8HZoI83YsTKyJnYsr/tM4VhZc2dhcfpcOULGk" +
                "cu2M7ZDZAp6yPNiGwA6n4eF0yQUSWFRkQrQFEkb68ukXYGtpVGk1antWaivDi+fidrzqxiuACxJF73/l" +
                "Uxa6XBAAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
