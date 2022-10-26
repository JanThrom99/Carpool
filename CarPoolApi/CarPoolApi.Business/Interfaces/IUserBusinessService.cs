using CarPoolApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolApi.Business.Interfaces
{
    internal interface IUserBusinessService
    {
        List<UserModel> GetAllUsers();
        UserModel? GetUserById(string userId);
        UserModel? CreateUser(UserDtoModel user);
        UserModel? UpdateUser(UserModel newUser);
        UserModel? DeleteUser(string userId);


    }
}
