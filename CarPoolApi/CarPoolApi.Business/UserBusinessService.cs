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
        Regex userIdPatternRegex = new Regex("^[A-Z]{2}[#].*[0-9]$");

        public List<UserModel> GetAllUsers()
        {
            return _userDataService.GetAllUsers();
        }

        public UserModel? GetUserById(string userId)
        {
            if (!String.IsNullOrEmpty(userId) && userIdPatternRegex.IsMatch(userId))
            {
                return _userDataService.GetUserById(userId);
            }
            return null;
        }

        public UserModel? CreateUser(UserDtoModel user) 
        {
            if (String.IsNullOrEmpty(user.FirstName) || String.IsNullOrEmpty(user.LastName) || String.IsNullOrEmpty(user.LocationName))
            {
                return null;
            }
            var userModel = new UserModel() 
            {
                Id = GetNewUserId(),
                FirstName = user.FirstName, 
                LastName = user.LastName, 
                LocationName = user.LocationName
            };
            return _userDataService.CreateUser(userModel);
        }

        public UserModel? UpdateUser(UserModel newUser)
        {
            if (!String.IsNullOrEmpty(newUser.Id) && userIdPatternRegex.IsMatch(newUser.Id))
            {
                return _userDataService.UpdateUser(newUser);
            }
            return null;
        }

        public UserModel? DeleteUser(string userId)
        {
            if (!String.IsNullOrEmpty(userId) && userIdPatternRegex.IsMatch(userId))
            {
                return _userDataService.DeleteUser(userId);
            }
            return null;
        }

        #region Helper Methods
        public string GetNewUserId()
        {
            int highestId = 0;
            var currentUsers = GetAllUsers();

            foreach (var user in currentUsers)
            {
                if (Convert.ToInt32(user.Id.Split('#').Last()) > highestId)
                {
                    highestId = Convert.ToInt32(user.Id.Split('#').Last());
                }
            }
            var newId = Convert.ToInt32(highestId) + 1;
            return $"ID#{newId}"; ;
        }
        #endregion
    }
}