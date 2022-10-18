using CarPoolApi.Data;
using CarPoolApi.Data.Models;

namespace CarPoolApi.Business
{
    public class UserBusinessService
    {
        UserDataService _userDataService = new UserDataService();

        public List<UserModel> GetAllUser()
        {
            return _userDataService.GetUsers();
        }

        public UserModel GetUserById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                //Todo check for specific entry 



                return _userDataService.GetUserById(id);
            }
            else
            {
                return ""; //TODO error handling 
            }
            
        }
    }
}
