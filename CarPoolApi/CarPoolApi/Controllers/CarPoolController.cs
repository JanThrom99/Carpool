using CarPoolApi.Business;
using CarPoolApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    public class CarPoolController : ControllerBase
    {
        CarPoolBusinessService carPoolBusinessService = new CarPoolBusinessService();

        [HttpGet]
        [Route("api/CarPoolApi/GetAllCarPools")]   
        public ActionResult<List<CarPoolModel>> GetAllCarPools()
        {
            return carPoolBusinessService.GetAllCarPools();
        }

        [HttpGet]
        [Route("api/CarPoolApi/GetCarPoolById/{carPoolId}")]
        public ActionResult<CarPoolModel> GetCarPoolById(string id)
        {
            return carPoolBusinessService.GetCarPoolById();
        }

        [HttpPost]
        [Route("api/CarPoolApi/CreateCarPool")]
        public ActionResult<CarPoolModel> CreateCarPool(CarPoolModel carPool)
        {
            return carPoolBusinessService.CreateCarPool();
        }

        [HttpPut]
        [Route("api/CarPoolApi/UpdateCarPool")]
        public ActionResult<CarPoolModel> UpdateCarPool(CarPoolModel carPool)
        {
            return carPoolBusinessService.UpdateCarPool();
        }

        [HttpDelete]
        [Route("api/CarPoolApi/DeleteCarPool/{carPoolId}")]
        public ActionResult<CarPoolModel> DeleteCarPool(string carPoolId)
        {
            return carPoolBusinessService.DeleteCarPool();
        }
    }
}