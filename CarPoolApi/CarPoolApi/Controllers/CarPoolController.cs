using CarPoolApi.Business;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    public class CarPoolController : ControllerBase
    {

        [HttpGet]
        [Route("api/CarPoolApi/GetCarPools")]   
        public ActionResult<string> GetCarPools()
        {
            return "";
        }

        [HttpGet]
        [Route("api/CarPoolApi/GetCarPoolById/{id}")]
        public ActionResult<string> GetCarPoolById(int id)
        {
            return $"{id}";
        }

        [HttpPost]
        [Route("api/CarPoolApi/PostCarPool/{id}")]
        public ActionResult<string> PostCarPool(int id)
        {
            return $"{id}";
        }

        [HttpPut]
        [Route("api/CarPoolApi/PutCarPool")]
        public ActionResult<string> PutCarPool()
        {
            return "";
        }

        [HttpDelete]
        [Route("api/CarPoolApi/DeleteCarPool/{id}")]
        public ActionResult<string> DeleteCarPool(int id)
        {
            return $"{id}";
        }
    }
}