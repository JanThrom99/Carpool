using CarPoolApi.Data.Models;

namespace CarPoolApi.Data.Interfaces
{
    public interface IUserDataService
    {
        List<UserModel> GetAllUsers();
        UserModel? GetUserById(string userId);
        UserModel? CreateUser(UserModel user);
        UserModel? UpdateUser(UserModel newUser);
        UserModel? DeleteUser(string userId);
    }
}
