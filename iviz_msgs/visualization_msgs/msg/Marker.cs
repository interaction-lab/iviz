using System.Runtime.Serialization;

namespace Iviz.Msgs.visualization_msgs
{
    [DataContract]
    public sealed class Marker : IMessage
    {
        // See http://www.ros.org/wiki/rviz/DisplayTypes/Marker and http://www.ros.org/wiki/rviz/Tutorials/Markers%3A%20Basic%20Shapes for more information on using this message with rviz
        
        public const byte ARROW = 0;
        public const byte CUBE = 1;
        public const byte SPHERE = 2;
        public const byte CYLINDER = 3;
        public const byte LINE_STRIP = 4;
        public const byte LINE_LIST = 5;
        public const byte CUBE_LIST = 6;
        public const byte SPHERE_LIST = 7;
        public const byte POINTS = 8;
        public const byte TEXT_VIEW_FACING = 9;
        public const byte MESH_RESOURCE = 10;
        public const byte TRIANGLE_LIST = 11;
        
        public const byte ADD = 0;
        public const byte MODIFY = 0;
        public const byte DELETE = 2;
        public const byte DELETEALL = 3;
        
        [DataMember] public std_msgs.Header header { get; set; } // header for time/frame information
        [DataMember] public string ns { get; set; } // Namespace to place this object in... used in conjunction with id to create a unique name for the object
        [DataMember] public int id { get; set; } // object ID useful in conjunction with the namespace for manipulating and deleting the object later
        [DataMember] public int type { get; set; } // Type of object
        [DataMember] public int action { get; set; } // 0 add/modify an object, 1 (deprecated), 2 deletes an object, 3 deletes all objects
        [DataMember] public geometry_msgs.Pose pose { get; set; } // Pose of the object
        [DataMember] public geometry_msgs.Vector3 scale { get; set; } // Scale of the object 1,1,1 means default (usually 1 meter square)
        [DataMember] public std_msgs.ColorRGBA color { get; set; } // Color [0.0-1.0]
        [DataMember] public duration lifetime { get; set; } // How long the object should last before being automatically deleted.  0 means forever
        [DataMember] public bool frame_locked { get; set; } // If this marker should be frame-locked, i.e. retransformed into its frame every timestep
        
        //Only used if the type specified has some use for them (eg. POINTS, LINE_STRIP, ...)
        [DataMember] public geometry_msgs.Point[] points { get; set; }
        //Only used if the type specified has some use for them (eg. POINTS, LINE_STRIP, ...)
        //number of colors must either be 0 or equal to the number of points
        //NOTE: alpha is not yet used
        [DataMember] public std_msgs.ColorRGBA[] colors { get; set; }
        
        // NOTE: only used for text markers
        [DataMember] public string text { get; set; }
        
        // NOTE: only used for MESH_RESOURCE markers
        [DataMember] public string mesh_resource { get; set; }
        [DataMember] public bool mesh_use_embedded_materials { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public Marker()
        {
            header = new std_msgs.Header();
            ns = "";
            points = System.Array.Empty<geometry_msgs.Point>();
            colors = System.Array.Empty<std_msgs.ColorRGBA>();
            text = "";
            mesh_resource = "";
        }
        
        /// <summary> Explicit constructor. </summary>
        public Marker(std_msgs.Header header, string ns, int id, int type, int action, geometry_msgs.Pose pose, geometry_msgs.Vector3 scale, std_msgs.ColorRGBA color, duration lifetime, bool frame_locked, geometry_msgs.Point[] points, std_msgs.ColorRGBA[] colors, string text, string mesh_resource, bool mesh_use_embedded_materials)
        {
            this.header = header ?? throw new System.ArgumentNullException(nameof(header));
            this.ns = ns ?? throw new System.ArgumentNullException(nameof(ns));
            this.id = id;
            this.type = type;
            this.action = action;
            this.pose = pose;
            this.scale = scale;
            this.color = color;
            this.lifetime = lifetime;
            this.frame_locked = frame_locked;
            this.points = points ?? throw new System.ArgumentNullException(nameof(points));
            this.colors = colors ?? throw new System.ArgumentNullException(nameof(colors));
            this.text = text ?? throw new System.ArgumentNullException(nameof(text));
            this.mesh_resource = mesh_resource ?? throw new System.ArgumentNullException(nameof(mesh_resource));
            this.mesh_use_embedded_materials = mesh_use_embedded_materials;
        }
        
        /// <summary> Constructor with buffer. </summary>
        internal Marker(Buffer b)
        {
            this.header = new std_msgs.Header(b);
            this.ns = b.DeserializeString();
            this.id = b.Deserialize<int>();
            this.type = b.Deserialize<int>();
            this.action = b.Deserialize<int>();
            this.pose = new geometry_msgs.Pose(b);
            this.scale = new geometry_msgs.Vector3(b);
            this.color = new std_msgs.ColorRGBA(b);
            this.lifetime = b.Deserialize<duration>();
            this.frame_locked = b.Deserialize<bool>();
            this.points = b.DeserializeStructArray<geometry_msgs.Point>();
            this.colors = b.DeserializeStructArray<std_msgs.ColorRGBA>();
            this.text = b.DeserializeString();
            this.mesh_resource = b.DeserializeString();
            this.mesh_use_embedded_materials = b.Deserialize<bool>();
        }
        
        ISerializable ISerializable.Deserialize(Buffer b)
        {
            return new Marker(b ?? throw new System.ArgumentNullException(nameof(b)));
        }
    
        void ISerializable.Serialize(Buffer b)
        {
            if (b is null) throw new System.ArgumentNullException(nameof(b));
            b.Serialize(this.header);
            b.Serialize(this.ns);
            b.Serialize(this.id);
            b.Serialize(this.type);
            b.Serialize(this.action);
            b.Serialize(this.pose);
            b.Serialize(this.scale);
            b.Serialize(this.color);
            b.Serialize(this.lifetime);
            b.Serialize(this.frame_locked);
            b.SerializeStructArray(this.points, 0);
            b.SerializeStructArray(this.colors, 0);
            b.Serialize(this.text);
            b.Serialize(this.mesh_resource);
            b.Serialize(this.mesh_use_embedded_materials);
        }
        
        public void Validate()
        {
            if (header is null) throw new System.NullReferenceException();
            header.Validate();
            if (ns is null) throw new System.NullReferenceException();
            if (points is null) throw new System.NullReferenceException();
            if (colors is null) throw new System.NullReferenceException();
            if (text is null) throw new System.NullReferenceException();
            if (mesh_resource is null) throw new System.NullReferenceException();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 138;
                size += header.RosMessageLength;
                size += BuiltIns.UTF8.GetByteCount(ns);
                size += 24 * points.Length;
                size += 16 * colors.Length;
                size += BuiltIns.UTF8.GetByteCount(text);
                size += BuiltIns.UTF8.GetByteCount(mesh_resource);
                return size;
            }
        }
    
        string IMessage.RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "visualization_msgs/Marker";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "4048c9de2a16f4ae8e0538085ebf1b97";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAE71X227bOBB9rr5igKBosnDkXLrdbgA/pLGbGMhtbbfdoigMWqJtNrKoklRc9+t7hpTk" +
                "uEnafdg2MWKK4sycuZ1htmgoJc2dK47a7eVyGRttY21m7aW6UW1zq762u8oWmViNVoW07QthbqQhkac/" +
                "FhqVThslslrCPj08fnqw90pYleB7OBfQRlNtaKGNJJVjuRBO6ZzwKa3KZ+TmytJCWitmkpbKzYlVR1Gp" +
                "cveSjgeDq3edverp5M2rXme/ehhen/UGvc5B/e79ef+y2xt0DqsNPPbGw9Ggf915fnfrvD8cdf68ozHs" +
                "vNhQG/b+qvaur/qXo2HnZfU46v07Gr/t996NXx+f9C9PO39XLy56w7PxoDe8ejM4AdAaNjAcX56eV0r3" +
                "9xvnut3GtYurbv/1++ax2zvvjdbOhcfj83N4F51JkSI78/D1yM9W/Z6j79RCtqdGLDZyEFlnOAO5fUxJ" +
                "UHQJOVuIRJLThCLhBSdNTz7JxEFjHMdIpkyxpETnn8o88Tn22VQpiyVGCidJUJmrz6WknLF4aHNZKYrg" +
                "6eEBn3/y5AdoKqv9LpucltmDRllr3sD2BShyVZQZHIfHXNipzKQLBVgjILyWpsLh0AmPI9ki7hTS003w" +
                "ImB4XGqPRJq2FzpV0xVgVNIt2qftVBZGJkCQ7rToIOBD99w5dLjezLJq10YzqRfSmdV4YWe2fa2tpIL/" +
                "3Dfu3wHynZhvCr/FljaHZBORye+Eh35vQ5r2W/hF8wqUUCqnoswcbZe2BLwV8QuEk+znUhi5g2pLg5UT" +
                "nWkzOH11jLxh9Z0d/5Y+7MV7u/vx3scoLU1gjExNJRfyw4E900vK9GY67VyXWYqsWkcTOWUKmkiff/AW" +
                "90DigYagpjEhO8EXPnqLSphonZHvm3GmkxtU+IO2+9OKxQJtVmYnMojuBtEWqVjGZBBtmOAm9A2D3lDO" +
                "hpPERle+W62TRRRtXeXAF1orBN5XpS1koqYKu3NhySKDfKZupwVty1lccVbrDg22CI26c69egOHDR5QM" +
                "vu2vsbiVl4sJAoPi8RlHpEqkRKJTsYs47REUSdRJxlzhm7eRqIFdXo16Ryj8Yi4Isc61o5V0HuoDpQWP" +
                "gikEkYKobjzzsOUXVyXM1kTIe4+d36D27wWRr/nYSKtLk8hQNX4L0mMJR9JUAiCTCw/LKOr8zz/RxfD0" +
                "iJoohAEBR4YOTCdMyp0oUuGEd2WuZoj7boZqyyAkFgV89G851zaG4IjLGZ+ZzKXxTeIDwUSuFwtwOPNU" +
                "Vah35CEJNhZUCIPmAtsanNcmVTkf9zXO2vGxyLbMwc397hHTt5VJ6RQAraCBh4W/G4Dk/QAEs0Ig2hot" +
                "9S4e5UyatXHUi3AMVn4BgVrGKewRbPwRnIuhG8GRsJJa2vZ7YzzaHYIRQJCFTua0DeTXKzcH03AB3grk" +
                "agLGg2KmCWh9xkLPdu5ozr3qXOS6Vh80rm38F7V5o5d92p0jZxl7b8sZAoiDhdG3CiVEk5VXkmRK5phW" +
                "amKEWUWeFL3JaOu15xHPRj4j+BbW6kTxXPGzsa7ZQGsq/VXVeH8swcFj8B8nCfCra+A0DCtEaWokEw0G" +
                "dourjLfT6r3yZ3lq47pZy8YUefJqDkT/lNxiude7Pve7HASUunNQC04oDBLOVoMfvohAZ5vuRtNMC/fi" +
                "OX1pVqtm9fX3wF+HrvahSVS4gqzjuQmenz6v485zLY5+4lG9Wv4e36pbzUOO0a1/t+lSzATV95TiZwDf" +
                "CRxzXyMJwVThshbKcAQ29bcLjHhHqZZ+OkHHQtxApUR/s7QoCigDyfL8z0Io/fTH9IxncYuWc5mHU/6O" +
                "wig8/6qEjJrxPbq+OTTCgirnWuSmB+hvvhcy5mAM5QclRofE7cR8U1npkpbsEBamon3NQ7jG5enJad3y" +
                "Iz6oeKDWm//ZUOcOA+enWf81qb4/+oNJjAzTrGbNatKsRBR9A8qKJhkXDwAA";
                
    }
}
