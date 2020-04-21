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
    public struct Quaternion
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/Quaternion";

        //  This represents an orientation in free space in quaternion form.
        public double x;
        public double y;
        public double z;
        public double w;

        public Quaternion(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }
}
