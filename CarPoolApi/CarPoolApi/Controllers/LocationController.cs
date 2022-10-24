using CarPoolApi.Business;
using CarPoolApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    [Route("CarPoolApi")]
    public class LocationController : ControllerBase
    {
        LocationBusinessService _locationBusinessService;

        [HttpGet]
        [Route("api/CarPoolApi/GetAllLocations")]   
        public ActionResult<List<LocationModel>> GetAllLocations()
        {
            return _locationBusinessService.GetAllLocations();
        }

        [HttpGet]
        [Route("api/CarPoolApi/GetLocationById/{id}")]
        public ActionResult<LocationModel> GetLocationById(string id)
        {
            return _locationBusinessService.GetLocationById(id);
        }

        [HttpPost]
        [Route("api/CarPoolApi/CreateLocation")]
        public ActionResult<LocationModel> CreateLocation(LocationDtoModel locationDtoModel)
        {
            return _locationBusinessService.CreateLocation(locationDtoModel);
        }

        [HttpPut]
        [Route("api/CarPoolApi/UpdateLocation")]
        public ActionResult<LocationModel> UpdateLocation(LocationModel newLocation)
        {
            return _locationBusinessService.UpdateLocation(newLocation);
        }

        [HttpDelete]
        [Route("api/CarPoolApi/DeleteLocation/{id}")]
        public ActionResult<LocationModel> DeleteLocation(string locationId)
        {
            return _locationBusinessService.DeleteLocation(locationId);
        }
    }
}