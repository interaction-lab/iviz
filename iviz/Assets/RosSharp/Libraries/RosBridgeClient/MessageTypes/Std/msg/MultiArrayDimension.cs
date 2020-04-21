/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */

using Newtonsoft.Json;

namespace RosSharp.RosBridgeClient.MessageTypes.Std
{
    public class MultiArrayDimension : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/MultiArrayDimension";

        public string label;
        //  label of given dimension
        public uint size;
        //  size of given dimension (in type units)
        public uint stride;
        //  stride of given dimension

        public MultiArrayDimension()
        {
            this.label = "";
            this.size = 0;
            this.stride = 0;
        }

        public MultiArrayDimension(string label, uint size, uint stride)
        {
            this.label = label;
            this.size = size;
            this.stride = stride;
        }
    }
}
