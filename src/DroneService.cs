using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Linq;
using Drone.Data;

namespace Drone.Service
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                    ConcurrencyMode = ConcurrencyMode.Single)]
    public class DroneService : IDroneService
    {
        public string NotFound()
        {
            return "Page not found";
        }

        public bool Status()
        {
            return true;
        }

        public DroneRequest LaunchDrone(DroneRequest request)
        {
            Console.WriteLine("ReceivedRequest: " + request);
            return request;
        }
    }
}
