/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.AudioMsgs
{
    [Preserve, DataContract (Name = "audio_msgs/Field")]
    public sealed class Field : IDeserializable<Field>, IMessage
    {
        [DataMember (Name = "name")] public string Name { get; set; }
        [DataMember (Name = "type")] public string Type { get; set; }
        [DataMember (Name = "length")] public uint Length { get; set; }
        [DataMember (Name = "description")] public string Description { get; set; }
        [DataMember (Name = "mode")] public string Mode { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Field()
        {
            Name = string.Empty;
            Type = string.Empty;
            Description = string.Empty;
            Mode = string.Empty;
        }
        
        /// <summary> Explicit constructor. </summary>
        public Field(string Name, string Type, uint Length, string Description, string Mode)
        {
            this.Name = Name;
            this.Type = Type;
            this.Length = Length;
            this.Description = Description;
            this.Mode = Mode;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Field(ref Buffer b)
        {
            Name = b.DeserializeString();
            Type = b.DeserializeString();
            Length = b.Deserialize<uint>();
            Description = b.DeserializeString();
            Mode = b.DeserializeString();
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Field(ref b);
        }
        
        Field IDeserializable<Field>.RosDeserialize(ref Buffer b)
        {
            return new Field(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.Serialize(Name);
            b.Serialize(Type);
            b.Serialize(Length);
            b.Serialize(Description);
            b.Serialize(Mode);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Name is null) throw new System.NullReferenceException(nameof(Name));
            if (Type is null) throw new System.NullReferenceException(nameof(Type));
            if (Description is null) throw new System.NullReferenceException(nameof(Description));
            if (Mode is null) throw new System.NullReferenceException(nameof(Mode));
        }
    
        public int RosMessageLength
        {
            get {
                int size = 20;
                size += BuiltIns.UTF8.GetByteCount(Name);
                size += BuiltIns.UTF8.GetByteCount(Type);
                size += BuiltIns.UTF8.GetByteCount(Description);
                size += BuiltIns.UTF8.GetByteCount(Mode);
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "audio_msgs/Field";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "c5f99874fbe65807b9f7f41274d5feb1";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACisuKcrMS1fIS8xN5SqGsEsqC1K5SjPzSoyNFHJS89JLMmAyKanFyUWZBSWZ+Xkwodz8" +
                "lFQuXi4A17KBgEcAAAA=";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
