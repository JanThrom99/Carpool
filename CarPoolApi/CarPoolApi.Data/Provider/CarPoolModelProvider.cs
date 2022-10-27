using CarPoolApi.Data.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolApi.Data.Provider
{
    public class CarPoolModelProvider : IExamplesProvider<CarPoolModel>
    {
        public CarPoolModel GetExamples()
        {
            return new CarPoolModel()
            {
                CarPoolId = "CPID#1",
                Name = "CarPool Example No1",
                DriverId = "ID#1",
                PassengerIds = new List<string> { "ID#5", "ID#6" },
                StartingLocation = "New York",
                Destination = "Washington DC",
                StartingTime = "9:00",
                ArrivalTime = "16:30"
            };
        }
    }
}
