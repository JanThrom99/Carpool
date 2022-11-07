using CarPoolApi.Data.Models;

namespace CarPoolApi.Business.Interfaces
{
    /// <summary>
    /// The Interface for the User Business Service where all the Methods and their return types and parameters are defined.
    /// </summary>
    public interface IUserBusinessService
    {
        /// <summary>
        /// A Method which will return a List with all the existing Users that are currently in the .csv file.
        /// </summary>
        /// <returns> An unfiltered list with UserModels. (List can be empty) </returns>
        List<UserModel> GetAllUsers();

        /// <summary>
        /// A Method which will return a single user that is identified by the userId.
        /// </summary>
        /// <param name="userId"> The Id of the user the customer wants to get. </param>
        /// <returns> A single UserModel. </returns>
        /// <returns> Null if the userId was not found or wrong. </returns>
        UserModel? GetUserById(string userId);

        /// <summary>
        /// A Method which will receive a UserDtoModel and then create a new Dataset in the .csv file with the given data in the model.
        /// </summary>
        /// <param name="userDtoModel"> A UserDtoModel with all the data the user wants in the to be created dataset. </param>
        /// <returns> A single UserModel Object with the data of the newly created dataset. </returns>
        /// <returns> Null if the passed data was faulty. </returns>
        UserModel? CreateUser(UserDtoModel userDtoModel);

        /// <summary>
        /// A Method which will update an existing user dataset and overwrite it with new data. 
        /// </summary>
        /// <param name="newUser"> A UserModel with the new UserData. </param>
        /// <returns> A single UserModel Object with the data of the updated dataset. </returns>
        /// <returns> Null if the User to update was not found or the data wrong. </returns>
        UserModel? UpdateUser(UserModel newUser);

        /// <summary>
        /// A Method which will delete an existing user dataset.
        /// </summary>
        /// <param name="userId"> The Id of the User that the customer wants to delete. </param>
        /// <returns> A single UserModel Object with the data of the deleted dataset. </returns>
        /// <returns> Null if the userId was not found or wrong. </returns>
        UserModel? DeleteUser(string userId);
    }
}