using System.Runtime.Serialization;
using System;

namespace Drone.Data {
  [DataContract(Namespace = "http://drone/external/request/data/",
                Name = "DroneRequest")]
  public class DroneRequest
  {
    [DataMember]
    public string id { get; set; }

    [DataMember]
    public string status { get; set; }

    override public string ToString()
    {
      return "DroneRequest[" + id + ", " + status + "]";
    }
  }
}
