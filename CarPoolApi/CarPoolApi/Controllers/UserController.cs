using CarPoolApi.Business;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    [Route("CarPoolApi")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        [Route("api/CarPoolApi/GetAllUser")]   
        public ActionResult<string> GetAllUser()
        {
            return "";
        }

        [HttpGet]
        [Route("api/CarPoolApi/GetUserById/{id}")]
        public ActionResult<string> GetUserById(int id)
        {
            return "";
        }

        [HttpPost]
        [Route("api/CarPoolApi/PostUser/{id}")]
        public ActionResult<string> PostUser(int id)
        {
            return "";
        }

        [HttpPut]
        [Route("api/CarPoolApi/PutUser")]
        public ActionResult<string> PutUser()
        {
            return "";
        }

        [HttpDelete]
        [Route("api/CarPoolApi/DeleteUser/{id}")]
        public ActionResult<string> DeleteUser(int id)
        {
            return "";
        }
    }
}