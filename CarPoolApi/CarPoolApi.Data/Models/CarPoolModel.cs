using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolApi.Data.Models
{
    public class CarPoolModel
    {
        public string CarPoolId { get; set; }
        public string Name { get; set; }
        public string DriverId { get; set; }
        public List<string> PassengerIds { get; set; }
        public string StartingLocation { get; set; }
        public string Destination { get; set; }
        public string StartingTime { get; set; }
        public string ArrivalTime { get; set; }

        public string ToDataString()
        {
            string passengerString="";
            var passengerArray = PassengerIds.ToArray();
            for (int i = 0; i < passengerArray.Length; i++)
            {
                if (i == (passengerArray.Length-1))
                {
                    passengerString += passengerArray[i];
                }
                else
                {
                    passengerString += passengerArray[i] + ",";
                }
            }
            return $"{CarPoolId};{Name};{DriverId};{passengerString};{StartingLocation};{Destination};{StartingTime};{ArrivalTime}";
        }
    }
}