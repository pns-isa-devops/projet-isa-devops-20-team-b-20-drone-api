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
}
