using CarPoolApi.Data.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Specialized;

namespace CarPoolApi.Data.Provider
{
    public class LocationModelProvider : IExamplesProvider<LocationModel>
    {
        public LocationModel GetExamples()
        {
            return new LocationModel()
            {
                Id = "LID#1",
                Name = "New York"
            };
        }
    }
}
