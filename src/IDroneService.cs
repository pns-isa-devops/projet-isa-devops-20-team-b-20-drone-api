using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;

using Drone.Data;

namespace Drone.Service
{

    [ServiceContract]
    public interface IDroneService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "status",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        bool Status();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "drone/launch",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        DroneRequest LaunchDrone(DroneRequest request);

        // catch all the other requests
        [OperationContract]
        [WebGet(UriTemplate = "*",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        string NotFound();
    }

}
