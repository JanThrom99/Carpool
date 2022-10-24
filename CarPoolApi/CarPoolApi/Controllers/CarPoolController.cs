using CarPoolApi.Business;
using CarPoolApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    public class CarPoolController : ControllerBase
    {
        CarPoolBusinessService _carPoolBusinessService = new CarPoolBusinessService();

        [HttpGet]
        [Route("api/CarPoolApi/GetAllCarPools")]
        public ActionResult<List<CarPoolModel>> GetAllCarPools()
        {
            return _carPoolBusinessService.GetAllCarPools();
        }

        [HttpGet]
        [Route("api/CarPoolApi/GetCarPoolById/{carPoolId}")]
        public ActionResult<CarPoolModel> GetCarPoolById(string carPoolId)
        {
            var result = _carPoolBusinessService.GetCarPoolById(carPoolId);
            return result == null? StatusCode(404, "CarPoolId not found") : result;
        }

        [HttpPost]
        [Route("api/CarPoolApi/CreateCarPool")]
        public ActionResult<CarPoolModel> CreateCarPool(CarPoolDtoModel carPool)
        {
            var result = _carPoolBusinessService.CreateCarPool(carPool);
            return result == null ? StatusCode(400, "Non valid input! Strings cannot be null or empty") : result;
        }

        [HttpPut]
        [Route("api/CarPoolApi/UpdateCarPool")]
        public ActionResult<CarPoolModel> UpdateCarPool(CarPoolModel carPool)
        {
            var result = _carPoolBusinessService.UpdateCarPool(carPool);
            return result == null ? StatusCode(404, "CarPool to update Not Found (wrong ID)") : result;
        }

        [HttpDelete]
        [Route("api/CarPoolApi/DeleteCarPool/{carPoolId}")]
        public ActionResult<CarPoolModel> DeleteCarPool(string carPoolId)
        {
            var result = _carPoolBusinessService.DeleteCarPool(carPoolId);
            return result == null ? StatusCode(404, "CarPool to delete Not Found (wrong ID)") : result;
        }
    }
}