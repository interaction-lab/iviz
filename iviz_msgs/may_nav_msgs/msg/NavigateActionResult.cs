/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [Preserve, DataContract (Name = "may_nav_msgs/NavigateActionResult")]
    public sealed class NavigateActionResult : IDeserializable<NavigateActionResult>, IActionResult<NavigateResult>
    {
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        [DataMember (Name = "status")] public ActionlibMsgs.GoalStatus Status { get; set; }
        [DataMember (Name = "result")] public NavigateResult Result { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public NavigateActionResult()
        {
            Status = new ActionlibMsgs.GoalStatus();
            Result = NavigateResult.Singleton;
        }
        
        /// <summary> Explicit constructor. </summary>
        public NavigateActionResult(in StdMsgs.Header Header, ActionlibMsgs.GoalStatus Status, NavigateResult Result)
        {
            this.Header = Header;
            this.Status = Status;
            this.Result = Result;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public NavigateActionResult(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            Status = new ActionlibMsgs.GoalStatus(ref b);
            Result = NavigateResult.Singleton;
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new NavigateActionResult(ref b);
        }
        
        NavigateActionResult IDeserializable<NavigateActionResult>.RosDeserialize(ref Buffer b)
        {
            return new NavigateActionResult(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            Header.RosSerialize(ref b);
            Status.RosSerialize(ref b);
            Result.RosSerialize(ref b);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Status is null) throw new System.NullReferenceException(nameof(Status));
            Status.RosValidate();
            if (Result is null) throw new System.NullReferenceException(nameof(Result));
            Result.RosValidate();
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
        [Preserve] public const string RosMessageType = "may_nav_msgs/NavigateActionResult";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "1eb06eeff08fa7ea874431638cb52332";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACr1WXXMaNxR93xn/B83wELsTu23Sj9QzPFCgDh3H8di0rx6tdNlVq9VSSQvm3/dcLSwQ" +
                "w4SHJAz2gi2de3TuuVf3PUlNXpTpkUkVTe2syZ+qUITvb2ppH6OMTRAhPbI7uTCFjPRAobFR+PQ4y/pf" +
                "+HWWfXi8uUZQ3RJ5n+idZT0BOk5Lr0VFUWoZpZjVoG+KkvylpQVZplrNSYv037iaU7jCxmlpgsC7IEde" +
                "WrsSTcCiWAtVV1XjjMKxRDQV7e3HTuOEFHPpo1GNlR7ra6+N4+UzLytidLwD/deQUyQmo2uscYFUEw0I" +
                "rYCgPMlgXIF/iqwxLr59wxuy3nRZX+IrFUhCF1zEUkYmS89zSMw8ZbhGjO/aw10BG+oQouggztPfnvA1" +
                "XAgEAQWa16oU52B+v4pl7QBIYiG9kbklBlZQAKiveNOrix1kpn0tnHT1Br5F3MY4BdZ1uHymyxI5s3z6" +
                "0BQQEAvnvl4YjaX5KoEoa8hFAed56VcZ72pDZr0/WGMswq6UETxlCLUySIAWSxPLLETP6CkbT0ZnX82Q" +
                "R+vjLOPPSG6BB1PgHL/bVE375X58N5rc3YjNqy9+wG92JqVtopRBrCiyJ3NiiVSb+7VGbXCk3S9Qqi3m" +
                "YDid/D0WO5g/7mNyUhrvIS58mBPLdBLw/cN4/OF+Oh51wG/2gT0pgrvhTGQdDuG/oABCFHIWYWYT+fSe" +
                "c0TPqRRckW2Jvnz18AOfJBVaz6Ew55YYwcSwQQHR8yn5CgVouRtEulhTfvxrOByPRzuU3+5TXgJZqtKg" +
                "S2hYUbEKs4ZbwSEhjoUZ/P7xYasLh/npQJi8TkfXTXLmlvvBSLqhz0rDrgg1KmEmjW08HaP3MP5zPNzh" +
                "1xc/v6Tn6R9SzO8gHa6puomf2uX15znmpCTaasLsgjVolVGCKTcJNGvjFtIafewAa+d1ldIXv3wD53XW" +
                "c3VMRbg1X5e8TuHh4PZ2W8l98eupBHPCbUUHGZ6iLnLyMlv7pN3M+IrvNb5BujSk1sxMSO8dYtcm777A" +
                "IU6TmU2xV35tAL45jnji9uPjdBeqL35LgAO3EWN9gQBJaGSNQagVQXYSMMpVOwgEGNzqpFt+Qu0Fxq5Z" +
                "bZZ0aXB8VA5i7bfOrDewtl6mkYQXohTwod7eVyCzvqu4xsTOfMVbNOVNUbCM60WRnmP2TW+zyYiHLDZB" +
                "O4isdQqRM85HSjczVF2WBhNGupV3ukoyCGmeiCZpgEkz1gGpsJ8cWwgHpcAaYdChao50WYvdjBna/C0J" +
                "oTvojfvgSvLcVRKj3YFhzd/ozZCBbgx6aHS7iZgR6Vyqf9mQ2NEOshgqQ5AFZxjZCXNSZmbUph4Sg8AG" +
                "YnSe+NoFIFU1qS7Q6gxWXW3yh1VfL3uVXD05uWhztz+XnyHq/zBXZnLZCwAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
