/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */

using Newtonsoft.Json;

namespace RosSharp.RosBridgeClient.MessageTypes.Geometry
{
    public struct Transform
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Transform";

        //  This represents the transform between two coordinate frames in free space.
        public Vector3 translation;
        public Quaternion rotation;

        public Transform(Vector3 translation, Quaternion rotation)
        {
            this.translation = translation;
            this.rotation = rotation;
        }
    }
}
