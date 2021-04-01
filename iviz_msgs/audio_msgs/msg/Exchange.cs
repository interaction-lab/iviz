/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [Preserve, DataContract (Name = "audio_msgs/Exchange")]
    public sealed class Exchange : IDeserializable<Exchange>, IMessage
    {
        [DataMember (Name = "commands")] public SoundHoundCommand[] Commands { get; set; }
        [DataMember (Name = "error")] public string Error { get; set; }
        [DataMember (Name = "transcription")] public string Transcription { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Exchange()
        {
            Commands = System.Array.Empty<SoundHoundCommand>();
            Error = string.Empty;
            Transcription = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public Exchange(SoundHoundCommand[] Commands, string Error, string Transcription)
        {
            this.Commands = Commands;
            this.Error = Error;
            this.Transcription = Transcription;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Exchange(ref Buffer b)
        {
            Commands = b.DeserializeArray<SoundHoundCommand>();
            for (int i = 0; i < Commands.Length; i++)
            {
                Commands[i] = new SoundHoundCommand(ref b);
            }
            Error = b.DeserializeString();
            Transcription = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Exchange(ref b);
        }
        
        Exchange IDeserializable<Exchange>.RosDeserialize(ref Buffer b)
        {
            return new Exchange(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.SerializeArray(Commands, 0);
            b.Serialize(Error);
            b.Serialize(Transcription);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Commands is null) throw new System.NullReferenceException(nameof(Commands));
            for (int i = 0; i < Commands.Length; i++)
            {
                if (Commands[i] is null) throw new System.NullReferenceException($"{nameof(Commands)}[{i}]");
                Commands[i].RosValidate();
            }
            if (Error is null) throw new System.NullReferenceException(nameof(Error));
            if (Transcription is null) throw new System.NullReferenceException(nameof(Transcription));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 12;
                foreach (var i in Commands)
                {
                    size += i.RosMessageLength;
                }
                size += BuiltIns.UTF8.GetByteCount(Error);
                size += BuiltIns.UTF8.GetByteCount(Transcription);
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "audio_msgs/Exchange";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "d6f8a41761adaba28718c4d86c1aaad1";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACrWQMQvCQAyF94P7DwFXwV1wclAQp4KLiIRerIe9XEmulf57rxx1EEfNEN4LgXwvVezZ" +
                "7ae2jSEgu/MF6qLUaBLPDZBIlNkkQdZafJd8ZGPN5sdlzbHarQF75+M1aKOr6hPRziyMgUzA8eapdWX5" +
                "QOMJ255yjA4Fg/4P8fthaxaQNQyTyQxelvD06V4GCkKdkBIncoAKJcn71Y9ZDJn7BXFkY6GcAQAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
