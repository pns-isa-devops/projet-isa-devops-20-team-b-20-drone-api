using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;

using Drone.Data;

namespace Drone.Service {

    [ServiceContract]
    public interface IDroneService
    {
        [OperationContract]
        [WebInvoke( Method = "GET", UriTemplate = "status",
                RequestFormat = WebMessageFormat.Json)]
        bool Status();

        [OperationContract]
        [WebInvoke( Method = "POST", UriTemplate = "drone/launch",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        DroneRequest LaunchDrone(DroneRequest request);
    }

}
