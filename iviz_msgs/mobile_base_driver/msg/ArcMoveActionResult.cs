/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/ArcMoveActionResult")]
    public sealed class ArcMoveActionResult : IDeserializable<ArcMoveActionResult>, IActionResult<ArcMoveResult>
    {
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        [DataMember (Name = "status")] public ActionlibMsgs.GoalStatus Status { get; set; }
        [DataMember (Name = "result")] public ArcMoveResult Result { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public ArcMoveActionResult()
        {
            Status = new ActionlibMsgs.GoalStatus();
            Result = ArcMoveResult.Singleton;
        }
        
        /// <summary> Explicit constructor. </summary>
        public ArcMoveActionResult(in StdMsgs.Header Header, ActionlibMsgs.GoalStatus Status, ArcMoveResult Result)
        {
            this.Header = Header;
            this.Status = Status;
            this.Result = Result;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public ArcMoveActionResult(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            Status = new ActionlibMsgs.GoalStatus(ref b);
            Result = ArcMoveResult.Singleton;
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new ArcMoveActionResult(ref b);
        }
        
        ArcMoveActionResult IDeserializable<ArcMoveActionResult>.RosDeserialize(ref Buffer b)
        {
            return new ArcMoveActionResult(ref b);
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
        [Preserve] public const string RosMessageType = "mobile_base_driver/ArcMoveActionResult";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "1eb06eeff08fa7ea874431638cb52332";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACr1WTW8bNxC9L+D/QMCH2EXttEk/UgM6qJbqKLATw1Z7FbjkaJctl6uSXMn6933DlVar" +
                "WkZ0SCLIXskm3zy+eTOc9yQ1eVGmRyZVNLWzJp9VoQivb2ppH6OMTRAhPbKhV3f1kh4oNDYKnx4n2eAL" +
                "v06yu8ebK8TULY/3id1JdirAxmnptagoSi2jFPMa7E1Rkr+wtCTLTKsFaZH+G9cLCpfYOC1NEHgX5MhL" +
                "a9eiCVgUa6HqqmqcUTKSiKaivf3YaZyQYiF9NKqx0mN97bVxvHzuZUWMjnegfxtyisRkdIU1LpBqogGh" +
                "NRCUJxmMK/BPkTXGxbdveEN2Ol3VF/hKBXLQBRexlJHJ0tMCEjNPGa4Q47v2cJfAhjqEKDqIs/S3Gb6G" +
                "c4EgoECLWpXiDMzv17GsHQBJLKU3MrfEwAoKAPUVb3p13kNm2lfCSVdv4VvEXYxjYF2Hy2e6KJEzy6cP" +
                "TQEBsXDh66XRWJqvE4iyhlwUMJ6Xfp3xrjZkdvoHa4xF2JUygqcMoVYGCdBiZWKZhegZPWVjZnT21Qz5" +
                "YnmcZPwZyS3wYAqc43fbomm/3I8/jiYfb8T2NRA/4Dc7k9I2Ucog1hTZkzmxRKrN/UajNjjS7peo1BZz" +
                "eD2d/DUWPcwf9zE5KY33EBc+zIllOgr4/mE8vrufjkcd8Jt9YE+K4G44E1mHQ/gvKIAQhZxHmNlEPr3n" +
                "HNFTKgVXZDuiz1+n+IFPkgqt51CYC0uMYGLYooDo2ZR8hQK03A0inW8oP/55fT0ej3qU3+5TXgFZqtKg" +
                "S2hYUbEK84ZbwSEhXgoz/P3Tw04XDvPTgTB5nY6um+TMHfeDkXRDn5WGXRFqVMJcGtt4eonew/jD+LrH" +
                "byB+fk7P09+kmN9BOlxTdRP/b5fvP88xJyXRVhNmF6xBq4wSTLlJoFkbt5TW6JcOsHFeVykD8cs3cF5n" +
                "PVfHVIQ783XJ6xS+Ht7e7ip5IH49lmBOuK3oIMNj1EVOnmdrn7SbG1/xvcY3SJeG1JqZCem9Q/Rt8u4L" +
                "HOI4mdkUe+XXBuCb4wVP3H56nPahBuK3BDh0WzE2FwiQhEbWGIRaEWQnAaNctoNAgMGtTrrlR9ReYGyM" +
                "Pbijoc/K4PioHMTab53Z6dDaepVGEl6IUsCHendfgczmruIaE73xirdoypuiYBk3iyI9xeyb3maTEQ9Z" +
                "bIJ2ENnoFCJnnI+UbmaouioNJox0K/e6SjIIaZ6IJmmASTPWAamwnxxbCAelwBph0KFqgXRZi92MGdr8" +
                "rQihO+it++BK8txVEqP+wLDhb/R2yEA3Bj00un4i5kQ6l+ofNiR2tIMshsoQZMEZRnbCgpSZG7Wth8Qg" +
                "sIEYnSe+dgFIVU2qC7Q6g1WX2/xh1dfLXlXnxtIsl4Fm2qNU/eu94fwEof8DyHntR90LAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
