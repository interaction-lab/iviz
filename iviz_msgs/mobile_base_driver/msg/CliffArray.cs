/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/CliffArray")]
    public sealed class CliffArray : IDeserializable<CliffArray>, IMessage
    {
        [DataMember (Name = "header")] public StdMsgs.Header Header { get; set; }
        // XXX: sensor indices in their respective arrays does not necessarily
        // reflect what sensor it actually represents
        // Each of these messages has its own internal field for that purpose.
        // Example: check wheeldrop[0].wheel == WheelDrop.RIGHT and do not rely on the 0
        [DataMember (Name = "cliff")] public CliffSensor[] Cliff { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public CliffArray()
        {
            Cliff = System.Array.Empty<CliffSensor>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public CliffArray(in StdMsgs.Header Header, CliffSensor[] Cliff)
        {
            this.Header = Header;
            this.Cliff = Cliff;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public CliffArray(ref Buffer b)
        {
            Header = new StdMsgs.Header(ref b);
            Cliff = b.DeserializeArray<CliffSensor>();
            for (int i = 0; i < Cliff.Length; i++)
            {
                Cliff[i] = new CliffSensor(ref b);
            }
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new CliffArray(ref b);
        }
        
        CliffArray IDeserializable<CliffArray>.RosDeserialize(ref Buffer b)
        {
            return new CliffArray(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            Header.RosSerialize(ref b);
            b.SerializeArray(Cliff, 0);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (Cliff is null) throw new System.NullReferenceException(nameof(Cliff));
            for (int i = 0; i < Cliff.Length; i++)
            {
                if (Cliff[i] is null) throw new System.NullReferenceException($"{nameof(Cliff)}[{i}]");
                Cliff[i].RosValidate();
            }
        }
    
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += Header.RosMessageLength;
                size += 10 * Cliff.Length;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/CliffArray";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "6fd810cb276829214052d0f48967ff86";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACrVUTU/bQBC9W8p/GIkDtCrhq60QUg4tEEAFgQCpSAhFG+/EXtXedXfXCfn3fbN2IHDq" +
                "oY0i2Z6deTPz5s2es9LsqUyPLNugh4eHIwpsg/NkrDY5Bzwplmw8eQ4N59HMmZT3ahlIO5xbF8kyPIPy" +
                "ploCxfOsgiMtShVf0CKpPLaqqpY4b4DFNgY4n6q8JDeTHIGpFpgCqKVC5hjILSwqiOytqmhmuNI0A1wU" +
                "6Kb1jQs8FJRnVTcVH1Fecv4LmRme3jWPu0/D9EGjEf2UlxNYh7cXZ+f3pKxGC6kBz6jLpU5pNzuuzGx2" +
                "lwp/fKJcvrJBNvrHv0F2dXcGuqOe1KEIO+dpDAN0cxdRmvIadESlVVSp59IUJfvtiudoJ0Q0zKhfTuOy" +
                "4SA03JcGtAUq2LJPXLcBTtFR7uq6tSZXkSka0Lwej0hMWVGjfDR5WykPf+e1seI+86pOJOMf+HfLNme6" +
                "OAHXzgbOW1EEMhmbe1bB2AKHlLWY2sG+BGQb9wu3LUMsILaX5N0MUSw/ixykThWOkONj19wQ2CJGZNGB" +
                "tpJtgs/wgZAEJXDjIJ0tVH6zjGU/vDlEqKYVC3AOBoC6KUGbH9aQpewjssq6FXyH+Jrjb2DtC670tF1i" +
                "ZpV0H9oCBMKx8W5uNFynywQCIUH0VJmpV36ZSVSXMtsYC8dwQlSaCJ4qBJcbDEDTwsQyC9ELeprGxOj/" +
                "J8jaTU3Fk6kKPNEew/U7awsh+rzpGkON3XKslhzzh2aKlRD7ZX4VZOqlxCsw38ltHSaYAtseOoGAOLlS" +
                "3BRbqhpQivsCmeFWu7mUsFBLkOLqVTFDucjW8ZIUD6nbefmNsOKd7eripDePaO/Vdnk6Fs8R7fe23pBs" +
                "B73t+7fjH519RJ/XbB3giL68r0NmHbn3HF9eX9+uVXJ8eTEepyp6w5vau0jgaYNXkSpWelZhRxOffZoF" +
                "7kzNEVcv6wynShZwFSHRnmPrLckgOsqStKuve4e7z59kem8HAZYtLvQVUhc9kehB9gfAKZpUOwYAAA==";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
