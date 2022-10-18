using CarPoolApi.Business;
using CarPoolApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolApi.Controllers
{
    [ApiController]
    [Route("CarPoolApi")]
    public class UserController : ControllerBase
    {

        UserBusinessService _userBusinessService = new UserBusinessService();

        [HttpGet]
        [Route("api/CarPoolApi/GetUsers")]
        public ActionResult<List<UserModel>> GetUsers()
        {
            return _userBusinessService.GetAllUser();
        }

        [HttpGet]
        [Route("api/CarPoolApi/GetUserById/{id}")]
        public ActionResult<string> GetUserById(string id)
        {
            return _userBusinessService.GetUserById(id);
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