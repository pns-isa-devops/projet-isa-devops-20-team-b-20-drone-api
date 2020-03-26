using System.Runtime.Serialization;
using System;

namespace Drone.Data
{
    [DataContract(Namespace = "http://drone/external/request/data/",
                  Name = "DroneRequest")]
    public class DroneRequest
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string hour { get; set; }

        override public string ToString()
        {
            return "DroneRequest[ Drone " + id + " will be launched at " + hour + " ]";
        }
    }
    [DataContract(Namespace = "http://drone/external/request/data/",
                  Name = "DroneStatus")]
    public class DroneStatus
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public int remainingTime { get; set; }


        override public string ToString()
        {
            return "DroneStatus[ Drone " + id + " with " + status + " delivery time estimation " + remainingTime + "s ]";
        }
    }

}
