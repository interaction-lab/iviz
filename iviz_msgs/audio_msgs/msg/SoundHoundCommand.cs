/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [Preserve, DataContract (Name = "audio_msgs/SoundHoundCommand")]
    public sealed class SoundHoundCommand : IDeserializable<SoundHoundCommand>, IMessage
    {
        [DataMember (Name = "name")] public string Name { get; set; }
        [DataMember (Name = "params")] public MayfieldMsgs.KeyValue[] Params { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public SoundHoundCommand()
        {
            Name = string.Empty;
            Params = System.Array.Empty<MayfieldMsgs.KeyValue>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public SoundHoundCommand(string Name, MayfieldMsgs.KeyValue[] Params)
        {
            this.Name = Name;
            this.Params = Params;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public SoundHoundCommand(ref Buffer b)
        {
            Name = b.DeserializeString();
            Params = b.DeserializeArray<MayfieldMsgs.KeyValue>();
            for (int i = 0; i < Params.Length; i++)
            {
                Params[i] = new MayfieldMsgs.KeyValue(ref b);
            }
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new SoundHoundCommand(ref b);
        }
        
        SoundHoundCommand IDeserializable<SoundHoundCommand>.RosDeserialize(ref Buffer b)
        {
            return new SoundHoundCommand(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Name);
            b.SerializeArray(Params, 0);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Name is null) throw new System.NullReferenceException(nameof(Name));
            if (Params is null) throw new System.NullReferenceException(nameof(Params));
            for (int i = 0; i < Params.Length; i++)
            {
                if (Params[i] is null) throw new System.NullReferenceException($"{nameof(Params)}[{i}]");
                Params[i].RosValidate();
            }
        }
    
        public int RosMessageLength
        {
            get {
                int size = 8;
                size += BuiltIns.UTF8.GetByteCount(Name);
                foreach (var i in Params)
                {
                    size += i.RosMessageLength;
                }
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "audio_msgs/SoundHoundCommand";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "390c1250bfe4c9f56e75739bb0b6475f";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACisuKcrMS1fIS8xN5cpNrEzLTM1Jic8tTi/W906tDEvMKU2NjlUoSCxKzC3m4uWypTLg" +
                "5fINdrdSwG4xL5eyApCtUAbiAN2QWaSjUJ5ZkgERKFYoSi0oSi1OzStJTVFILFYoBvukmAtCK2TDGGVA" +
                "dwMAIO/ateYAAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
