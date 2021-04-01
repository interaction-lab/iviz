/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver {
    [Preserve, DataContract(Name = "mobile_base_driver/Stall")]
    public sealed class Stall : IDeserializable<Stall>, IMessage {
        // Motor Stall state published at a fixed frequency by the driver
        [DataMember(Name = "header")] public StdMsgs.Header Header { get; set; }
        // XXX: wheel indices in their respective arrays does not necessarily
        // reflect what wheel it actually represents
        // Each of these messages has its own internal field for that purpose.
        // Example: check motor[0].motor == Motor.RIGHTWHEEL and do not rely on the 0
        [DataMember(Name = "motor")] public Motor[/*5*/] Motor { get; set; }

        /// <summary> Constructor for empty message. </summary>
        public Stall() {
            Motor = new Motor[5];
        }

        /// <summary> Explicit constructor. </summary>
        public Stall(in StdMsgs.Header Header, Motor[] Motor) {
            this.Header = Header;
            this.Motor = Motor;
        }

        /// <summary> Constructor with buffer. </summary>
        public Stall(ref Buffer b) {
            Header = new StdMsgs.Header(ref b);
            Motor = b.DeserializeArray<Motor>();
            for (int i = 0; i < 5; i++) {
                Motor[i] = new Motor(ref b);
            }
        }

        public ISerializable RosDeserialize(ref Buffer b) {
            return new Stall(ref b);
        }

        Stall IDeserializable<Stall>.RosDeserialize(ref Buffer b) {
            return new Stall(ref b);
        }

        public void RosSerialize(ref Buffer b) {
            Header.RosSerialize(ref b);
            b.SerializeArray(Motor, 5);
        }

        public void Dispose() {
        }

        public void RosValidate() {
            if (Motor is null) throw new System.NullReferenceException(nameof(Motor));
            if (Motor.Length != 5) throw new System.IndexOutOfRangeException();
            for (int i = 0; i < Motor.Length; i++) {
                if (Motor[i] is null) throw new System.NullReferenceException($"{nameof(Motor)}[{i}]");
                Motor[i].RosValidate();
            }
        }

        public int RosMessageLength {
            get {
                int size = 0;
                size += Header.RosMessageLength;
                size += 2 * Motor.Length;
                return size;
            }
        }

        public string RosType => RosMessageType;

        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/Stall";

        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "6519e11145a7e7fc40fd5a90d611dcc9";

        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve]
        public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACrVUTWsbMRC9C/wfBnxIUoiTJi0Ugw+FOh+QlNAYmhKC0Upjr6hW2kpaO/vv+7RyUufW" +
                "Q7ssaFcz8+bNvJHGdOuTD3SfpLUUk0xMbVdZE2vWJBNJWplnfK4C/+rYqZ6qnlLNpIPZcBDiiqXmQPWw" +
                "CDGmh4eHKW1rZkvGaaM4Ys0hJlDg2LJKiCQZguwjaQ+784kcwzPKYGwPkMArC0fggMMODGRU6sCzh7kF" +
                "FLsU4TuXqia/yikiU5NR1gCtJRKnSH7rQCBxcNKiGLYoBhWnjNx2ofWRJxnlWTat5SmpmtVPanJbHk+f" +
                "JsMHzWalUZNv15dXi+9X8/kNSadBfyAfGKT8UCWdCjG4Pn58KihiJGb/+BmJ2/vLKfTSyyau40kRYYQy" +
                "IKTTMmj0IUktE/QD/dqsaw7Hljc8qNy0kHSwpr7lmOtf1Ab9irRmx2FochfhlDwp3zSdMyrPRjLo7348" +
                "IqGupFaGZFRnZYC/D9q47L4Kshm6izeWAWK6/oImexdZdXkSkMk4FVhG49Ywkugg1/lZDhDjxdYfZ/XW" +
                "mLHX5EU8kOXnPAeZp4xT5HhXipsAG91hZNGRDoe9JX7jESEJKHDrMTOHYH7Xp3on3AbDJyvLGVihA0A9" +
                "yEEHR3vImfaUnHT+Bb4g/snxN7DuFTfXdFxDM5urj90aDYRjG/zGaLjuTpuyBtNO1lRBhl7kqJJSjC9y" +
                "j+GEqEERrDJGrwwE0LQ1qRYxhYw+qLE0+v8NZOMrY3lZycjLckGcDGchT+ZdKQnsyrEot02+Mcopyap/" +
                "or3zlZ8ZjlMx3Mwv9vZheL8z3H3+WrZeDGc7w+L6ZvHGcL4zzH/M798YPghReW8pU8oC7f7aLt+CI/Eb" +
                "xG7N/yUFAAA=";

        public override string ToString() => Extensions.ToString(this);
    }
}
