using CarPoolApi.Business;
using CarPoolApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    [Route("CarPoolApi")]
    public class CarPoolController : ControllerBase
    {
        CarPoolBusinessService _carPoolBusinessService = new CarPoolBusinessService();

        /// <summary>
        /// Gets all the existing CarPool Entries
        /// </summary>
        /// <returns>A List of CarPool Entries (List can have no entries)</returns>
        /// <response code ="200">Returns complete List of the Items (List can have no entries)</response>
        [HttpGet]
        [Route("api/CarPoolApi/GetAllCarPools")]
        public ActionResult<List<CarPoolModel>> GetAllCarPools()
        {
            return _carPoolBusinessService.GetAllCarPools();
        }

        /// <summary>
        /// Gets a specific CarPool Entry
        /// </summary>
        /// <param name="carPoolId">The Id of the CarPool the Customer wants to receive (ID schema: 'CPID#1')</param>
        /// <returns>A Single CarPool Entry</returns>
        /// <response code ="200">Returns single CarPool Item </response>
        /// <response code ="404">If the item to get is null (ID not found) </response>
        [HttpGet]
        [Route("api/CarPoolApi/GetCarPoolById/{carPoolId}")]
        public ActionResult<CarPoolModel?> GetCarPoolById(string carPoolId)
        {
            var result = _carPoolBusinessService.GetCarPoolById(carPoolId);
            return result == null ? StatusCode(404, "CarPoolId not found") : result;
        }

        /// <summary>
        /// Creates a new CarPool Entry
        /// </summary>
        /// <param name="carPool"></param>
        /// <returns>The JSON Body of the newly created CarPool Entry</returns>
        /// <response code ="200">Returns the body of the created CarPool Item </response>
        /// <response code ="400">If the userInput is not valid </response>
        [HttpPost]
        [Route("api/CarPoolApi/CreateCarPool")]
        public ActionResult<CarPoolModel?> CreateCarPool(CarPoolDtoModel carPool)
        {
            var result = _carPoolBusinessService.CreateCarPool(carPool);
            return result == null ? StatusCode(400, "Non valid input! Strings cannot be null or empty") : result;
        }

        /// <summary>
        /// Updates an existing CarPool with new Data
        /// </summary>
        /// <param name="carPool">The JSON Body with all the Data the Customer wants to put in an existing CarPool Entry</param>
        /// <returns>The JSON Body of the updated CarPool Entry</returns>
        /// <response code ="200">Returns the updated CarPool Item </response>
        /// <response code ="404">If the item to update is null (ID not found) </response>
        [HttpPut]
        [Route("api/CarPoolApi/UpdateCarPool")]
        public ActionResult<CarPoolModel?> UpdateCarPool(CarPoolModel carPool)
        {
            var result = _carPoolBusinessService.UpdateCarPool(carPool);
            return result == null ? StatusCode(404, "CarPool to update Not Found (wrong ID)") : result;
        }

        /// <summary>
        /// Deletes a existing CarPool
        /// </summary>
        /// <param name="carPoolId"> The Id of the CarPool the Customer wants to delete (ID schema: 'CPID#1') </param>
        /// <returns>The JSON Body of the deleted CarPool Entry </returns>
        /// <response code ="200">Returns the deleted CarPool Item </response>
        /// <response code ="404">If the item to delete is null (ID not found) </response>
        [HttpDelete]
        [Route("api/CarPoolApi/DeleteCarPool/{carPoolId}")]
        public ActionResult<CarPoolModel?> DeleteCarPool(string carPoolId)
        {
            var result = _carPoolBusinessService.DeleteCarPool(carPoolId);
            return result == null ? StatusCode(404, "CarPool to delete Not Found (wrong ID)") : result;
        }
    }
}