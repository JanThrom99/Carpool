using CarPoolApi.Data.Models;
using Swashbuckle.AspNetCore.Filters;

namespace CarPoolApi;

public class CarPoolDtoProvider : IExamplesProvider<CarPoolDtoModel>
{
    public CarPoolDtoModel GetExamples()
    {
        return new CarPoolDtoModel()
        {
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