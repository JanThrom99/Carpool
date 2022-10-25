using CarPoolApi.Business;
using CarPoolApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarPoolApi.Controllers
{
    [ApiController]
    [Route("CarPoolApi")]
    public class UserController : ControllerBase
    {
        UserBusinessService _userBusinessService = new UserBusinessService();

        [HttpGet]
        [Route("api/CarPoolApi/GetAllUsers")]
        public ActionResult<List<UserModel>> GetAllUsers()
        {
            return _userBusinessService.GetAllUsers();
        }

        [HttpGet]
        [Route("api/CarPoolApi/GetUserById/{userId}")]
        public ActionResult<UserModel?> GetUserById(string userId)
        {
            var result = _userBusinessService.GetUserById(userId);
            return result == null? StatusCode(404, "UserId not found") : result;
            
        }

        [HttpPost]
        [Route("api/CarPoolApi/CreateUser")]
        public ActionResult<UserModel?> CreateUser(UserDtoModel user)
        {
            var result =  _userBusinessService.CreateUser(user);
            return result == null ? StatusCode(400, "Non valid input! Strings cannot be null or empty") : result;
        }

        [HttpPut]
        [Route("api/CarPoolApi/UpdateUser")]
        public ActionResult<UserModel?> UpdateUser(UserModel newUser)
        {
            var result = _userBusinessService.UpdateUser(newUser);
            return result == null ? StatusCode(404, "User to update Not Found (wrong ID)") : result;
        }

        [HttpDelete]
        [Route("api/CarPoolApi/DeleteUser/{userId}")]
        public ActionResult<UserModel?> DeleteUser(string userId)
        {
            var result = _userBusinessService.DeleteUser(userId);
            return result == null ? StatusCode(404, "User to delete Not Found (wrong ID)") : StatusCode(200, $"Deleted User: {result.ToDataString()}");
        }
    }
}