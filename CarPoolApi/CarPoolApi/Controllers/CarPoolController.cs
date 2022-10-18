using CarPoolApi.Business;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    [Route("CarPoolApi")]
    public class CarPoolController : ControllerBase
    {

        [HttpGet]
        [Route("api/CarPoolApi/GetAllCarPool")]   
        public ActionResult<string> GetAllCarPool()
        {
            return "";
        }

        [HttpGet]
        [Route("api/CarPoolApi/GetCarPoolById/{id}")]
        public ActionResult<string> GetCarPoolById(int id)
        {
            return "";
        }

        [HttpPost]
        [Route("api/CarPoolApi/PostCarPool/{id}")]
        public ActionResult<string> PostCarPool(int id)
        {
            return "";
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
            return "";
        }
    }
}