using CarPoolApi.Business;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    [Route("CarPoolApi")]
    public class LocationController : ControllerBase
    {
        LocationBusinessService _locationBusinessService;

        [HttpGet]
        [Route("api/CarPoolApi/GetLocations")]   
        public ActionResult<string> GetLocations()
        {
            return "";//_locationBusinessService.GetAllLocations();
        }

        [HttpGet]
        [Route("api/CarPoolApi/GetLocationById/{id}")]
        public ActionResult<string> GetLocationById(int id)
        {
            return "";//_locationBusinessService.GetLocationById(id);
        }

        [HttpPost]
        [Route("api/CarPoolApi/PostLocation/{id}")]
        public ActionResult<string> PostLocation(int id)
        {
            return "";//_locationBusinessService.PostLocation(id);
        }

        [HttpPut]
        [Route("api/CarPoolApi/PutLocation")]
        public ActionResult<string> PutLocation()
        {
            return "";// _locationBusinessService.PutLocation();
        }

        [HttpDelete]
        [Route("api/CarPoolApi/DeleteLocation/{id}")]
        public ActionResult<string> DeleteLocation(int id)
        {
            return "";//_locationBusinessService.DeleteLocation(id);
        }
    }
}