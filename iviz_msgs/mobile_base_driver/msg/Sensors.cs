/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver {
    [Preserve, DataContract(Name = "mobile_base_driver/Sensors")]
    public sealed class Sensors : IDeserializable<Sensors>, IMessage {
        // sensor state published at a fixed frequency by the driver
        [DataMember(Name = "header")] public StdMsgs.Header Header { get; set; }
        // XXX: sensor indices in their respective arrays does not necessarily
        // reflect what sensor it actually represents
        // Each of these messages has its own internal field for that purpose.
        // Example: check wheeldrop[0].wheel == WheelDrop.RIGHT and do not rely on the 0
        [DataMember(Name = "bumper")] public Bumper[/*3*/] Bumper { get; set; }
        [DataMember(Name = "wheeldrop")] public WheelDrop[/*2*/] Wheeldrop { get; set; }
        [DataMember(Name = "touch")] public Touch Touch { get; set; }

        /// <summary> Constructor for empty message. </summary>
        public Sensors() {
            Bumper = new Bumper[3];
            Wheeldrop = new WheelDrop[2];
            Touch = new Touch();
        }

        /// <summary> Explicit constructor. </summary>
        public Sensors(in StdMsgs.Header Header, Bumper[] Bumper, WheelDrop[] Wheeldrop, Touch Touch) {
            this.Header = Header;
            this.Bumper = Bumper;
            this.Wheeldrop = Wheeldrop;
            this.Touch = Touch;
        }

        /// <summary> Constructor with buffer. </summary>
        public Sensors(ref Buffer b) {
            Header = new StdMsgs.Header(ref b);
            Bumper = b.DeserializeArray<Bumper>();
            for (int i = 0; i < 3; i++) {
                Bumper[i] = new Bumper(ref b);
            }
            Wheeldrop = b.DeserializeArray<WheelDrop>();
            for (int i = 0; i < 2; i++) {
                Wheeldrop[i] = new WheelDrop(ref b);
            }
            Touch = new Touch(ref b);
        }

        public ISerializable RosDeserialize(ref Buffer b) {
            return new Sensors(ref b);
        }

        Sensors IDeserializable<Sensors>.RosDeserialize(ref Buffer b) {
            return new Sensors(ref b);
        }

        public void RosSerialize(ref Buffer b) {
            Header.RosSerialize(ref b);
            b.SerializeArray(Bumper, 3);
            b.SerializeArray(Wheeldrop, 2);
            Touch.RosSerialize(ref b);
        }

        public void Dispose() {
        }

        public void RosValidate() {
            if (Bumper is null) throw new System.NullReferenceException(nameof(Bumper));
            if (Bumper.Length != 3) throw new System.IndexOutOfRangeException();
            for (int i = 0; i < Bumper.Length; i++) {
                if (Bumper[i] is null) throw new System.NullReferenceException($"{nameof(Bumper)}[{i}]");
                Bumper[i].RosValidate();
            }
            if (Wheeldrop is null) throw new System.NullReferenceException(nameof(Wheeldrop));
            if (Wheeldrop.Length != 2) throw new System.IndexOutOfRangeException();
            for (int i = 0; i < Wheeldrop.Length; i++) {
                if (Wheeldrop[i] is null) throw new System.NullReferenceException($"{nameof(Wheeldrop)}[{i}]");
                Wheeldrop[i].RosValidate();
            }
            if (Touch is null) throw new System.NullReferenceException(nameof(Touch));
            Touch.RosValidate();
        }

        public int RosMessageLength {
            get {
                int size = 0;
                size += Header.RosMessageLength;
                size += 2 * Bumper.Length;
                size += 2 * Wheeldrop.Length;
                size += Touch.RosMessageLength;
                return size;
            }
        }

        public string RosType => RosMessageType;

        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/Sensors";

        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "62120da0767c5e0efa3534875705e11a";

        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve]
        public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACr1VTWsbMRC9C/IfBnJIW5K0TS8l4EPaOB+QpsYxNGCMkXfHXtG1tJW0cfzv+0ZaO3ZP" +
                "PbQRht0dzbyZ92YkH1JgG5ynEHVkatpZbULFJelImubmGa9zz79atsWaZmuKFVPpzRN7pW5Yl+ypSg+l" +
                "Dunx8fF8A2hsaQoOeEqM8eQ5NFxEhJL2Xq8DlQ771kWyDM+gvanXQPE8r+FIqwpFbNBQThFbXddr7DfA" +
                "YhsDnPu6qMjNJUdgWgrMAqiVRuYYyK0sKojsra5Bh2vQAVwU6Kb1jQt8KijPetnUfE5FxcVPZGZ4eteM" +
                "P0xO0wf1evRDXi5hPR3eXt+MSNsSFBIBz6jLJab0QX1plw378acJbdcsmdQWYny22dzmUiPXgsveimJS" +
                "B6r3j9eB+vZwjVbFcroMi/A+d/IASjxE0NK+hJRRlzrqpFdlFhX7k5qfIAVGBWTAXXbjuuEgEo4qA8kD" +
                "LdiyT31qA5yio8Itl601hQxYNGjRbjwiMSGaGu2jKdpae/g7Xxor7nOvl6lB+IU8hUy3l+iTs4GLVqYJ" +
                "mYwtPOtg7AKbpFp0/NOZBKjD0cqdyAAsMKjb5Ln/KJafZZSkTh3OkeNdJncKbBlkZCkDvUm2KT7DW0IS" +
                "lMCNQ6veoPLBOlZd458wwHpWswAXUACoRxJ09HYHWco+J6ut28BnxJccfwNrt7jC6aRCz2phH9oFBIRj" +
                "492TKeHaHdmiNjgwVJuZ136tJCqnVIdXojGcEJU6gqcOwRUGDShpZWKlQvSCnroxNeX/G8ilm5mapzMd" +
                "eJpvmff5MMloDjInlNcdJ2HAcu90p0v6/pny4ZTVw1nMtq/9+1F/mG0fO9td/yq7wXb2gpJvwg1W/65/" +
                "8dC/3IEaDPsP2fJRdaa99Dn8NRXaXip/iLS9WXbu+CRX2thT64VeViWR6xz3Bbm4FfI7AZfD74PBvh6r" +
                "HfzXlyNdoyJF9K38I2gb8j3KJYzjq+H3+9FUaB4nssdo8sWwM+Q5Oabk1O0khfCeHzk8fUzUzLl6PCGW" +
                "vyvvoDqI/gYkA6xWUgcAAA==";

        public override string ToString() => Extensions.ToString(this);
    }
}
