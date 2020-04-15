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

        [DataMember]
        public string destination { get; set; }

        override public string ToString()
        {
            return "DroneRequest[ Drone " + id + " will be launched at " + hour + " to "+ destination + " ]";
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
        public string delivery { get; set; }

        [DataMember]
        public int remainingTime { get; set; }


        override public string ToString()
        {
            return "DroneStatus[ Drone " + id + " with " + status + " delivery time " + remainingTime + "s ]";
        }
    }

    public class Address {
        public Address(string location, int roundTripTime){
            this.location = location;
            this.roundTripTime = roundTripTime;
        }
        public string location { get; set; }
        public int roundTripTime { get; set; }
    }

}
