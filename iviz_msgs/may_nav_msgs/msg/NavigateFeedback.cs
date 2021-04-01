/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [Preserve, DataContract (Name = "may_nav_msgs/NavigateFeedback")]
    public sealed class NavigateFeedback : IDeserializable<NavigateFeedback>, IFeedback<NavigateActionFeedback>
    {
        //State fed back to ios (Controlling, Planning, etc)
        [DataMember (Name = "state")] public string State { get; set; }
        //Current state of may_nav's state machine
        [DataMember (Name = "state_machine_state")] public string StateMachineState { get; set; }
        //target pose is the target_pose set by the local planner
        [DataMember (Name = "target_pose")] public GeometryMsgs.Pose2D TargetPose { get; set; }
        [DataMember (Name = "cmd_vel")] public GeometryMsgs.Pose2D CmdVel { get; set; }
        //has_bumped is set to true when the bump sensor message has been received by may_nav
        [DataMember (Name = "has_bumped")] public bool HasBumped { get; set; }
        [DataMember (Name = "num_replans")] public uint NumReplans { get; set; }
        [DataMember (Name = "replan_failure_occurred")] public bool ReplanFailureOccurred { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public NavigateFeedback()
        {
            State = string.Empty;
            StateMachineState = string.Empty;
            TargetPose = new GeometryMsgs.Pose2D();
            CmdVel = new GeometryMsgs.Pose2D();
        }
        
        /// <summary> Explicit constructor. </summary>
        public NavigateFeedback(string State, string StateMachineState, GeometryMsgs.Pose2D TargetPose, GeometryMsgs.Pose2D CmdVel, bool HasBumped, uint NumReplans, bool ReplanFailureOccurred)
        {
            this.State = State;
            this.StateMachineState = StateMachineState;
            this.TargetPose = TargetPose;
            this.CmdVel = CmdVel;
            this.HasBumped = HasBumped;
            this.NumReplans = NumReplans;
            this.ReplanFailureOccurred = ReplanFailureOccurred;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public NavigateFeedback(ref Buffer b)
        {
            State = b.DeserializeString();
            StateMachineState = b.DeserializeString();
            TargetPose = new GeometryMsgs.Pose2D(ref b);
            CmdVel = new GeometryMsgs.Pose2D(ref b);
            HasBumped = b.Deserialize<bool>();
            NumReplans = b.Deserialize<uint>();
            ReplanFailureOccurred = b.Deserialize<bool>();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new NavigateFeedback(ref b);
        }
        
        NavigateFeedback IDeserializable<NavigateFeedback>.RosDeserialize(ref Buffer b)
        {
            return new NavigateFeedback(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(State);
            b.Serialize(StateMachineState);
            TargetPose.RosSerialize(ref b);
            CmdVel.RosSerialize(ref b);
            b.Serialize(HasBumped);
            b.Serialize(NumReplans);
            b.Serialize(ReplanFailureOccurred);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (State is null) throw new System.NullReferenceException(nameof(State));
            if (StateMachineState is null) throw new System.NullReferenceException(nameof(StateMachineState));
            if (TargetPose is null) throw new System.NullReferenceException(nameof(TargetPose));
            TargetPose.RosValidate();
            if (CmdVel is null) throw new System.NullReferenceException(nameof(CmdVel));
            CmdVel.RosValidate();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 62;
                size += BuiltIns.UTF8.GetByteCount(State);
                size += BuiltIns.UTF8.GetByteCount(StateMachineState);
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "may_nav_msgs/NavigateFeedback";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "93b607f29b90c517db4c9c6c8eb188e9";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACq1SO2scMRDuF+4/DKRwExywQ4pAioAhuAgYktTLnDR7p0QvpNGd99/nk/Z8OOAyCwvS" +
                "aB7fY6aqxcUDVWWVaXp9mwObo4syX96mg6QgWtY51EP98JSq3D2QcjmIzhm3txNMsPNJ/DTtU/J05Drv" +
                "W8hip+ai3t9RbGEukj3HuqVsl3lh51uRORnTShG7m7785283ff/x7TO9hXo3vaMHyUUMqFtcnrxwFWr4" +
                "9Si0NO/p/oE67dsJ748RfaIU9pRaAQeTQpBoWV2K5CppGsV8LQXNIlWibilpITlJWRWSH4ijpSUVgn41" +
                "i3GLM8Q5e2dGdqXAfzYkiJaUiwNOwum3mC0B4qaR0MWU0Qw3V8iwN81f2uybUsrqAnu/0tkB2kBVTlt3" +
                "4HQRtWEDadtYD8wxUiuOG/eFzgJnUZMZCnjxZFJ2UjsrUIAKrGvGfVCkX4+DYMKEQtll8VizbToko5Yp" +
                "itg+CRxGX9sgLChJWRijezz7pK8ku6WvKF1T+6fP2emRIhL3MmTde3lxAtQU61ZfdO4xA48HSFi2dAHW" +
                "m4JoCtmLChQ6sXf2PXHtk27sBg4Ni7ieA8eVnG5jrVsWKSMSc9O6cW7az7f0qDd1IINk6rojBf2PXOyV" +
                "XDcAwPqOETB2GA0u9/DKZ5JSEL0YS31vKcAVPmApMKmLi1P/fRG264Vuf/NuX7h0g/TICtqwtm8L9rT3" +
                "AzcYC2d/9og895XownDH4sYmDC7ocF1fhDrYwNEtyVvULz6xfvpIz9fTej0BnPK0m/4CosjDon8EAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
