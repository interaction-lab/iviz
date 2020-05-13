using System.Runtime.Serialization;

namespace Iviz.Msgs.geometry_msgs
{
    [DataContract]
    public sealed class InertiaStamped : IMessage
    {
        [DataMember] public std_msgs.Header header { get; set; }
        [DataMember] public Inertia inertia { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public InertiaStamped()
        {
            header = new std_msgs.Header();
            inertia = new Inertia();
        }
        
        /// <summary> Explicit constructor. </summary>
        public InertiaStamped(std_msgs.Header header, Inertia inertia)
        {
            this.header = header ?? throw new System.ArgumentNullException(nameof(header));
            this.inertia = inertia ?? throw new System.ArgumentNullException(nameof(inertia));
        }
        
        /// <summary> Constructor with buffer. </summary>
        internal InertiaStamped(Buffer b)
        {
            this.header = new std_msgs.Header(b);
            this.inertia = new Inertia(b);
        }
        
        ISerializable ISerializable.Deserialize(Buffer b)
        {
            return new InertiaStamped(b ?? throw new System.ArgumentNullException(nameof(b)));
        }
    
        void ISerializable.Serialize(Buffer b)
        {
            if (b is null) throw new System.ArgumentNullException(nameof(b));
            b.Serialize(this.header);
            b.Serialize(this.inertia);
        }
        
        public void Validate()
        {
            if (header is null) throw new System.NullReferenceException();
            header.Validate();
            if (inertia is null) throw new System.NullReferenceException();
            inertia.Validate();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 80;
                size += header.RosMessageLength;
                return size;
            }
        }
    
        string IMessage.RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "geometry_msgs/InertiaStamped";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "ddee48caeab5a966c5e8d166654a9ac7";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAE71UTWvcMBC961cM5JCk7LqQlB4CObW02UMgkNBLScOsPbZFLMmV5N310h/fJ3m/cuuh" +
                "rbGxPZr35nvuhCvx1OaXWljxUTPp6a3U7V++1P3j1xsKsXoxoQnv7yazZ/QY2VbsKzISueLIVDt4pZtW" +
                "/LyTlXQAsemlonwax15CAeBTqwPhbgQuc9eNNAQoRUelM2awuuQoFLWRN3ggtSWmnhFnOXTsoe98pW1S" +
                "rz0bSey4g/wcxJZCi8830LFByiFqODSCofTCQdsGh6QGbeP1VQKos6e1m+NXGuT2YJxiyzE5K5veS0h+" +
                "criBjXdTcAW4kRyBlSrQRZa94DdcEozABeld2dIFPH8YY+ssCIVW7DUvO0nEJTIA1vMEOr88YbaZ2rJ1" +
                "e/qJ8WjjT2jtgTfFNG9Rsy5FH4YGCYRi791KV1Bdjpmk7LTYSJ1eevajSqjJpDr7knIMJaByRfDmEFyp" +
                "UYCK1jq2KkSf2HM1XnT1r7qxEYeu8+PUkrsRQIz38Ie+vzbPqu4cx48fyCiIPyEiVNXVZLKCeVZvGb5J" +
                "GZ2/Tg2Y9Pcz9SQ2oKdBODc/rp5xkq5fpDcbPOimzZZ+JX26zVJIxvRM0r3uNkv0Nkn3boHh5Hs8+d4e" +
                "v8cT+Xgi327/T153WdmPrJc0Akglyk6rfJYmsvaCDum5lCIN3yKPi7MYNiOMTsJcH5AAVtoDqp0twCpe" +
                "sDRkRjpS5SSQdREchl9BieRLQnPfgwwLxLMNHSdsEgNyIUVTzGjdip20Uu/lTZF3iy7J60ZXExKGzAHM" +
                "tAtuRrG+Qu923eTzZAyDABLvYgZcFrSoaXQDrVNA+PC7leZoKQe/8uhF52Zpn+0o3ib0wWHBIC0hcIMp" +
                "tSFimRbqUNljTxwrv1W/AR0LqHLwBQAA";
                
    }
}
