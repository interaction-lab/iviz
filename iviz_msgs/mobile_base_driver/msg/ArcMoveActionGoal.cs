/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/ArcMoveActionGoal")]
    public sealed class ArcMoveActionGoal : IDeserializable<ArcMoveActionGoal>, IActionGoal<ArcMoveGoal>
    {
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        [DataMember (Name = "goal_id")] public ActionlibMsgs.GoalID GoalId { get; set; }
        [DataMember (Name = "goal")] public ArcMoveGoal Goal { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public ArcMoveActionGoal()
        {
            GoalId = new ActionlibMsgs.GoalID();
            Goal = new ArcMoveGoal();
        }
        
        /// <summary> Explicit constructor. </summary>
        public ArcMoveActionGoal(in StdMsgs.Header Header, ActionlibMsgs.GoalID GoalId, ArcMoveGoal Goal)
        {
            this.Header = Header;
            this.GoalId = GoalId;
            this.Goal = Goal;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public ArcMoveActionGoal(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            GoalId = new ActionlibMsgs.GoalID(ref b);
            Goal = new ArcMoveGoal(ref b);
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new ArcMoveActionGoal(ref b);
        }
        
        ArcMoveActionGoal IDeserializable<ArcMoveActionGoal>.RosDeserialize(ref Buffer b)
        {
            return new ArcMoveActionGoal(ref b);
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
                int size = 20;
                size += Header.RosMessageLength;
                size += GoalId.RosMessageLength;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/ArcMoveActionGoal";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "9fc0c564c7c8bed37a61433bcde56914";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACrVUwWrbQBC9C/wPAzkkKcSB9mbooRCa+BAoxHcx2h1LS1e76s7Krv6+byXHcWkPPTRC" +
                "IFaaefNm3hs9CVtJ1M2Pik12MXjX1L22ev8Y2W8fqMWjdrb6ksxzPEh5O79bVZ//87Wqnl8eN6TZLgSe" +
                "Zlqr6opeMgfLyVIvmS1npn0Ebdd2ku68HMQji/tBLM1f8zSIrpG465wS7laCJPZ+olERlCOZ2PdjcIaz" +
                "UHa9/JaPTBeIaeCUnRk9J8THZF0o4fvEvRR03Co/RglGaPuwQUxQMWN2IDQBwSRhdaHFR6pGF/KnjyWh" +
                "utod4x2O0mL45+KUO86FrPwckmjhybpBjQ9Lc2tgYzqCKlbpZn5X46i3hCKgIEM0Hd2A+bcpdzEAUOjA" +
                "yXHjpQAbTACo1yXp+vYCudDeUOAQX+EXxLca/wIbzrilp7sOmvnSvY4tBojAIcWDswhtphnEeCchExyX" +
                "OE1VyVpKVldfy4wRhKxZETxZNRoHASwdXe4qzamgz2oUg76bIf+6F8WWO/SwSKddHL3FIabCerEUQc5j" +
                "56DJ3EdZGjqyUiqeUfRRPLSdJZ9dialwOFWDzukAdxw7CeQyoVfR4ltYQ/ohE2aO7IKpi3GOgtJnaGoE" +
                "KwIKZCRlhniF0eWIT/ydfZUFEwY9KBPfRk17Eduw+Q5mFhnw5egz1lCVW5l1IB3EuL0zS4MnBro+oVfY" +
                "kSUApPpRM5gRFg9R61cJEfV+6vWxcV7qhlVqm7Ca6f7iV7aq9j5yWUxOpvYSzmdYVzjVWGWMIk9vcaH1" +
                "cnkqv4c/w+yYuAi5qn4BipYL5WUFAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
