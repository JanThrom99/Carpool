using CarPoolApi.Business;
using CarPoolApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    [Route("CarPoolApi")]
    public class LocationController : ControllerBase
    {
        LocationBusinessService _locationBusinessService = new LocationBusinessService();

        /// <summary>
        /// Gets all the existing Location Entries
        /// </summary>
        /// <returns>A List of Location Entries</returns>
        [HttpGet]
        [Route("api/CarPoolApi/GetAllLocations")]   
        public ActionResult<List<LocationModel>> GetAllLocations()
        {
            return _locationBusinessService.GetAllLocations();
        }

        /// <summary>
        /// Gets a specific Location Entry
        /// </summary>
        /// <param name="locationId">The Id of the Location the Customer wants to receive (ID schema: 'LID#1')</param>
        /// <returns>A Single Location Entry</returns>
        [HttpGet]
        [Route("api/CarPoolApi/GetLocationById/{locationId}")]
        public ActionResult<LocationModel?> GetLocationById(string locationId)
        {
            return _locationBusinessService.GetLocationById(locationId);
        }

        /// <summary>
        /// Creates a new Location Entry
        /// </summary>
        /// <returns>The JSON Body of the newly created Location Entry</returns>
        [HttpPost]
        [Route("api/CarPoolApi/CreateLocation")]
        public ActionResult<LocationModel?> CreateLocation(LocationDtoModel location)
        {
            return _locationBusinessService.CreateLocation(location);
        }

        /// <summary>
        /// Updates an existing Location with new Data
        /// </summary>
        /// <param name="newLocation">The JSON Body with all the Data the Customer wants to put in an existing Location Entry</param>
        /// <returns>The JSON Body of the updated Location Entry</returns>
        [HttpPut]
        [Route("api/CarPoolApi/UpdateLocation")]
        public ActionResult<LocationModel?> UpdateLocation(LocationModel newLocation)
        {
            return _locationBusinessService.UpdateLocation(newLocation);
        }

        /// <summary>
        /// Deletes a existing Location
        /// </summary>
        /// <param name="locationId"> The Id of the Location the Customer wants to delete (ID schema: 'LID#1') </param>
        /// <returns>The JSON Body of the deleted Location Entry </returns>
        [HttpDelete]
        [Route("api/CarPoolApi/DeleteLocation/{id}")]
        public ActionResult<LocationModel?> DeleteLocation(string locationId)
        {
            return _locationBusinessService.DeleteLocation(locationId);
        }
    }
}