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
        Regex idPatternRegex = new Regex("^[A-Z]{2}[#].*[0-9]$");

        public List<UserModel> GetAllUsers()
        {
            return _userDataService.GetAllUsers();
        }

        public UserModel? GetUserById(string userId)
        {
            
            if (!String.IsNullOrEmpty(userId) && idPatternRegex.IsMatch(userId))
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

        public UserModel? CreateUser(UserDtoModel user) 
        {
            if (String.IsNullOrEmpty(user.FirstName) || String.IsNullOrEmpty(user.LastName) || String.IsNullOrEmpty(user.LocationName))
            {
                return null;
            }
            var userModel = new UserModel() { FirstName = user.FirstName, LastName = user.LastName, LocationName = user.LocationName };
            return _userDataService.CreateUser(userModel);
        }
        public UserModel? DeleteUser(string userId)
        {
            if (!String.IsNullOrEmpty(userId) && idPatternRegex.IsMatch(userId))
            {
                return _userDataService.DeleteUser(userId);
            }
            return null;
            
        }
        public UserModel? UpdateUser(UserModel newUser)
        {
            if (!String.IsNullOrEmpty(newUser.Id) && idPatternRegex.IsMatch(newUser.Id))
            {
                return _userDataService.UpdateUser(newUser);
            }
            return null;
        }
    }
}
