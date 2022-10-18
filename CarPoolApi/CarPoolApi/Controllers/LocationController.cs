using CarPoolApi.Business;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    [Route("CarPoolApi")]
    public class LocationController : ControllerBase
    {

        [HttpGet]
        [Route("api/CarPoolApi/GetAllLocation")]   
        public ActionResult<string> GetAllLocation()
        {
            return "";
        }

        [HttpGet]
        [Route("api/CarPoolApi/GetLocationById/{id}")]
        public ActionResult<string> GetLocationById(int id)
        {
            return "";
        }

        [HttpPost]
        [Route("api/CarPoolApi/PostLocation/{id}")]
        public ActionResult<string> PostLocation(int id)
        {
            return "";
        }

        [HttpPut]
        [Route("api/CarPoolApi/PutLocation")]
        public ActionResult<string> PutLocation()
        {
            return "";
        }

        [HttpDelete]
        [Route("api/CarPoolApi/DeleteLocation/{id}")]
        public ActionResult<string> DeleteLocation(int id)
        {
            return "";
        }
    }
}