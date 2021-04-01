/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver {
    [Preserve, DataContract(Name = "mobile_base_driver/ChestLeds")]
    public sealed class ChestLeds : IDeserializable<ChestLeds>, IMessage {
        // Provide chest LEDs frame
        // Index 0 is the center LED
        // With 0 degrees straight up increasing clockwise
        // Inner ring
        // Index 1 : 150 degrees
        // Index 2 : 210 degrees
        // Index 3 : 270 degrees
        // Index 4 : 330 degrees
        // Index 5 : 30 degrees
        // Index 6 : 90 degrees
        // Outter ring
        // Index 13 : 22 degrees
        // Index 14 : 67 degrees
        // Index 7  : 112 degrees
        // Index 8  : 157 degrees
        // Index 9  : 202 degrees
        // Index 10 : 247 degrees
        // Index 11 : 292 degrees
        // Index 12 : 337 degrees
        [DataMember(Name = "leds")] public Led[/*15*/] Leds { get; set; }

        /// <summary> Constructor for empty message. </summary>
        public ChestLeds() {
            Leds = new Led[15];
        }

        /// <summary> Explicit constructor. </summary>
        public ChestLeds(Led[] Leds) {
            this.Leds = Leds;
        }

        /// <summary> Constructor with buffer. </summary>
        public ChestLeds(ref Buffer b) {
            Leds = b.DeserializeArray<Led>();
            for (int i = 0; i < 15; i++) {
                Leds[i] = new Led(ref b);
            }
        }

        public ISerializable RosDeserialize(ref Buffer b) {
            return new ChestLeds(ref b);
        }

        ChestLeds IDeserializable<ChestLeds>.RosDeserialize(ref Buffer b) {
            return new ChestLeds(ref b);
        }

        public void RosSerialize(ref Buffer b) {
            b.SerializeArray(Leds, 15);
        }

        public void Dispose() {
        }

        public void RosValidate() {
            if (Leds is null) throw new System.NullReferenceException(nameof(Leds));
            if (Leds.Length != 15) throw new System.IndexOutOfRangeException();
            for (int i = 0; i < Leds.Length; i++) {
                if (Leds[i] is null) throw new System.NullReferenceException($"{nameof(Leds)}[{i}]");
                Leds[i].RosValidate();
            }
        }

        /// <summary> Constant size of this message. </summary>
        [Preserve] public const int RosFixedMessageLength = 0;

        public int RosMessageLength {
            get {
                int size = 4;
                foreach (Led l in Leds) {
                    size += l.RosMessageLength;
                }
                return size;
            }
        }
        public string RosType => RosMessageType;

        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/ChestLeds";

        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "ef09340f131b3099106bbb45d67c5ff0";

        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve]
        public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACq2SQWrDMBBF9wLfYSAHqGXFcRzoriUUUlroootSgmxNbRFFLpKc9vgdGeMslGW1Eu/P" +
                "nxmJv4JXN1y0Qmh79AEOjw8evpw8I1vBk1X4CzloD6GnCrQBXSwh7V2HniSFnUP04IOTuusDjN+gbetQ" +
                "em07aM3Qnn60Rza1s2R3xJfeHHbAy6XNwgviBU+5iLxK+Zq4ECkvI0/xhnB9xcRfxhCS5aZpReLmcdqm" +
                "SngF8TU8NWwnoUwddRSK/MaIPArr1MHjjxX1DUf8MiGuDnZA9cHLT6BjUHmWsft/Phl7ftvv4Dw02uCx" +
                "kR6PyukLujuandFqc7Y8SAoQbQXtYIYpQRQYGSgVo7ZhCw7VfIu72/nemBEz9geWWGOwogIAAA==";

        public override string ToString() => Extensions.ToString(this);
    }
}
