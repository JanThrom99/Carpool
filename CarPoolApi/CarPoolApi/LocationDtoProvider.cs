using CarPoolApi.Data.Models;
using Swashbuckle.AspNetCore.Filters;

namespace CarPoolApi
{
    public class LocationDtoProvider : IExamplesProvider <LocationDtoModel>
    {
        public LocationDtoModel GetExamples()
        {
            return new LocationDtoModel()
            {
                Name = "New York"
            };
        }
    }
}
