using CarPoolApi.Data;
using CarPoolApi.Data.Models;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CarPoolApi.Business
{
    public class UserBusinessService
    {
        UserDataService _userDataService = new UserDataService();

        public List<UserModel> GetAllUsers()
        {
            return _userDataService.GetAllUsers();
        }

        public UserModel? GetUserById(string userId)
        {
            Regex regex = new Regex("^[A-Z]{2}[#][0-9]$"); //TODO input checks
            if (!String.IsNullOrEmpty(userId) && regex.IsMatch(userId))
            {
                var userList = _userDataService.GetAllUsers();
                foreach (var user in userList)
                {
                    if (user.Id == userId)
                    {
                        return user;
                    }
                }
            }
            
            return null;
        }

        public UserModel CreateUser(UserDtoModel user) //TODO input checks!!!
        {
            return _userDataService.CreateUser(user);
        }
        public UserModel DeleteUser(string userId)
        {
            return _userDataService.DeleteUser(userId);
        }
        public UserModel UpdateUser(UserModel newUser)
        {
            return _userDataService.UpdateUser(newUser);
        }
    }
}
