using System;
using System.Net;
using System.ServiceModel;
using System.Globalization;
using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Drone.Data;

namespace Drone.Service
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                    ConcurrencyMode = ConcurrencyMode.Single)]
    public class DroneService : IDroneService
    {

        private static Timer timer = new Timer();
        private static int deliveryTime = 10; //s
        private Dictionary<string, DroneStatus> drones = new Dictionary<string, DroneStatus>();
        Random rnd = new Random();
        private List<Address> addresses = new List<Address>();

        public DroneService()
        {
            Console.WriteLine("Start drone service");
            timer.Interval = 1000;
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;

            //MOCK some addresses
            addresses.Add(new Address("Instant travel", 1)); // instant travel
            addresses.Add(new Address("5 rue Vert", 5));
            addresses.Add(new Address("10 rue Orange", 10));
            addresses.Add(new Address("900 rue Rouge", 900)); //15 min
        }
        public string NotFound()
        {
            return "Page not found";
        }

        public DroneStatus getDroneStatus(string identifier)
        {
            if (!drones.ContainsKey(identifier))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            return drones[identifier];
        }

        public DroneStatus LaunchDrone(DroneRequest request)
        {
            DroneStatus d;
            if (!drones.ContainsKey(request.id))
            {
                d = new DroneStatus();
                d.id = request.id;
                drones.Add(request.id, d);
            }
            else if (drones[request.id].status == "ON_DELIVERY")
            {
                Console.WriteLine("ReceivedRequest: Drone " + request.id + " already on delivery");
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            else
            {
                d = drones[request.id];
            }

            //compare addresses from mock to find round-trip time
            foreach (Address a in addresses)
            {
                if (a.location.Equals(request.destination))
                {
                    deliveryTime = a.roundTripTime;
                    break;
                }
            }

            d.delivery = "ONGOING";
            d.status = "ON_DELIVERY";
            d.remainingTime = deliveryTime;
            Console.WriteLine("ReceivedRequest: " + d);
            return d;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Console.WriteLine(e.SignalTime.Second);
            foreach (DroneStatus d in drones.Values)
            {
                d.remainingTime -= 1;
                if (d.remainingTime == 0)
                {
                    d.status = "AVAILABLE";
                    d.delivery = rnd.Next(10) == 0 ? "FAILED" : "DELIVERED";
                    Console.WriteLine(e.SignalTime);
                    Console.WriteLine(d);
                }
            }
        }
    }
}
