/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MobileBaseDriver
{
    [Preserve, DataContract (Name = "mobile_base_driver/Power")]
    public sealed class Power : IDeserializable<Power>, IMessage
    {
        [DataMember (Name = "adc_channels")] public ushort[] AdcChannels { get; set; }
        [DataMember (Name = "v_dock")] public float VDock { get; set; }
        [DataMember (Name = "v_batt")] public float VBatt { get; set; }
        [DataMember (Name = "i_batt")] public float IBatt { get; set; }
        [DataMember (Name = "t_batt")] public float TBatt { get; set; }
        [DataMember (Name = "dock_present")] public bool DockPresent { get; set; }
        [DataMember (Name = "is_charging")] public bool IsCharging { get; set; }
        [DataMember (Name = "power_button_pressed")] public bool PowerButtonPressed { get; set; }
        [DataMember (Name = "battery")] public BatteryCapacity Battery { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Power()
        {
            AdcChannels = System.Array.Empty<ushort>();
            Battery = new BatteryCapacity();
        }
        
        /// <summary> Explicit constructor. </summary>
        public Power(ushort[] AdcChannels, float VDock, float VBatt, float IBatt, float TBatt, bool DockPresent, bool IsCharging, bool PowerButtonPressed, BatteryCapacity Battery)
        {
            this.AdcChannels = AdcChannels;
            this.VDock = VDock;
            this.VBatt = VBatt;
            this.IBatt = IBatt;
            this.TBatt = TBatt;
            this.DockPresent = DockPresent;
            this.IsCharging = IsCharging;
            this.PowerButtonPressed = PowerButtonPressed;
            this.Battery = Battery;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public Power(ref Buffer b)
        {
            AdcChannels = b.DeserializeStructArray<ushort>();
            VDock = b.Deserialize<float>();
            VBatt = b.Deserialize<float>();
            IBatt = b.Deserialize<float>();
            TBatt = b.Deserialize<float>();
            DockPresent = b.Deserialize<bool>();
            IsCharging = b.Deserialize<bool>();
            PowerButtonPressed = b.Deserialize<bool>();
            Battery = new BatteryCapacity(ref b);
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new Power(ref b);
        }
        
        Power IDeserializable<Power>.RosDeserialize(ref Buffer b)
        {
            return new Power(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            b.SerializeStructArray(AdcChannels, 0);
            b.Serialize(VDock);
            b.Serialize(VBatt);
            b.Serialize(IBatt);
            b.Serialize(TBatt);
            b.Serialize(DockPresent);
            b.Serialize(IsCharging);
            b.Serialize(PowerButtonPressed);
            Battery.RosSerialize(ref b);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (AdcChannels is null) throw new System.NullReferenceException(nameof(AdcChannels));
            if (Battery is null) throw new System.NullReferenceException(nameof(Battery));
            Battery.RosValidate();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 27;
                size += 2 * AdcChannels.Length;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "mobile_base_driver/Power";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "64de407003b036b2169e0188bd020101";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACq1RsU7FMAzcI/UfTnorEgIEQkgMwMDExIhQ5CR+bSBNqsQt6t+TtjwET4x48ln23dke" +
                "fZSzq5dXkLPadhQjh6L2IZFcnGPSLtn3H9CQyDf0v6Fs0KQUsIzpIXPh+FXxZaHPrY/tVhjSB2dtRpEU" +
                "19bCTt1XBs7zAw1kvcwwG1aNuv3naNTT8+MN+mR84Oq8sHbZT5xPjzw0aj0R+rtuya4xWNmSnMbo2Ola" +
                "wA724HngbOva1DK4iO9J+OTQC0mQjhGZ6saCS1B0CsexQxnNG1vZJrq5VEdcfEFJ8FK1IlIMM5aPVR2/" +
                "X1knCiOjo/IX49bqYGaQIDAt8vWwn1OukocCAgAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
