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

        /// <summary>
        /// Gets all the existing User Entries
        /// </summary>
        /// <returns>A List of User Entries</returns>
        /// <response code ="200">Returns complete List of the Items (List can have no entries)</response>
        [HttpGet]
        [Route("api/CarPoolApi/GetAllUsers")]
        public ActionResult<List<UserModel>> GetAllUsers()
        {
            return _userBusinessService.GetAllUsers();
        }

        /// <summary>
        /// Gets a specific User Entry
        /// </summary>
        /// <param name="userId">The Id of the User the Customer wants to receive (ID schema: 'ID#1')</param>
        /// <returns>A Single User Entry</returns>
        /// <response code ="200">Returns single User Item </response>
        /// <response code ="404">If the item to get is null (ID not found) </response>
        [HttpGet]
        [Route("api/CarPoolApi/GetUserById/{userId}")]
        public ActionResult<UserModel?> GetUserById(string userId)
        {
            var result = _userBusinessService.GetUserById(userId);
            return result == null? StatusCode(404, "UserId not found") : result;
            
        }

        /// <summary>
        /// Creates a new User Entry
        /// </summary>
        /// <param name="user"></param>
        /// <returns>The JSON Body of the newly created User Entry</returns>
        /// <response code ="200">Returns the body of the created User Item </response>
        /// <response code ="400">If the userInput is not valid </response>
        [HttpPost]
        [Route("api/CarPoolApi/CreateUser")]
        public ActionResult<UserModel?> CreateUser(UserDtoModel user)
        {
            var result =  _userBusinessService.CreateUser(user);
            return result == null ? StatusCode(400, "Non valid input! Strings cannot be null or empty") : result;
        }

        /// <summary>
        /// Updates an existing User with new Data
        /// </summary>
        /// <param name="newUser">The JSON Body with all the Data the Customer wants to put in an existing User Entry</param>
        /// <returns>The JSON Body of the updated User Entry</returns>
        /// <response code ="200">Returns the updated user Item </response>
        /// <response code ="404">If the item to update is null (ID not found) </response>
        [HttpPut]
        [Route("api/CarPoolApi/UpdateUser")]
        public ActionResult<UserModel?> UpdateUser(UserModel newUser)
        {
            var result = _userBusinessService.UpdateUser(newUser);
            return result == null ? StatusCode(404, "User to update Not Found (wrong ID)") : result;
        }

        /// <summary>
        /// Deletes a existing User
        /// </summary>
        /// <param name="userId"> The Id of the User the Customer wants to delete (ID schema: 'ID#1') </param>
        /// <returns>The JSON Body of the deleted User Entry </returns>
        /// <response code ="200">Returns the deleted user Item </response>
        /// <response code ="404">If the item to delete is null (ID not found) </response>
        [HttpDelete]
        [Route("api/CarPoolApi/DeleteUser/{userId}")]
        public ActionResult<UserModel?> DeleteUser(string userId)
        {
            var result = _userBusinessService.DeleteUser(userId);
            return result == null ? StatusCode(404, "User to delete Not Found (wrong ID)") : StatusCode(200, $"Deleted User: {result.ToDataString()}");
        }
    }
}