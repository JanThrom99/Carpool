using CarPoolApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolApi.Business.Interfaces
{
    /// <summary>
    /// The Interface for the CarPool Business Service where all the Methods and their return types and parameters are defined.
    /// </summary>
    public interface ICarPoolBusinessService
    {
        /// <summary>
        /// A Method which will return a List with all the existing CarPools that are currently in the .csv file.
        /// </summary>
        /// <returns> An unfiltered list with CarPoolModels. (List can be empty) </returns>
        List<CarPoolModel> GetAllCarPools();

        /// <summary>
        /// A Method which will return a single carPool that is identified by the carPoolId.
        /// </summary>
        /// <param name="carPoolId"> The Id of the carPool the customer wants to get. </param>
        /// <returns> A single CarPoolModel. </returns>
        /// <returns> Null if the carPoolId was not found or wrong. </returns>
        CarPoolModel? GetCarPoolById(string carPoolId);

        /// <summary>
        /// A Method which will receive a CarPoolDtoModel and then create a new Dataset in the .csv file with the given data in the model.
        /// </summary>
        /// <param name="carPoolDtoModel"> A CarPoolDtoModel with all the data the user wants in the to be created dataset. </param>
        /// <returns> A single CarPoolModel Object with the data of the newly created dataset. </returns>
        /// <returns> Null if the passed data was faulty. </returns>
        CarPoolModel? CreateCarPool(CarPoolDtoModel carPoolDtoModel);

        /// <summary>
        /// A Method which will update an existing carPool dataset and overwrite it with new data. 
        /// </summary>
        /// <param name="newCarPool"> A CarPoolModel with the new carPool data. </param>
        /// <returns> A single CarPoolModel Object with the data of the updated dataset. </returns>
        /// <returns> Null if the CarPool to update was not found or the data wrong. </returns>
        CarPoolModel? UpdateCarPool(CarPoolModel newCarPool);

        /// <summary>
        /// A Method which will delete an existing carPool dataset.
        /// </summary>
        /// <param name="carPoolId"> The Id of the carPool that the customer wants to delete. </param>
        /// <returns> A single CarPoolModel Object with the data of the deleted dataset. </returns>
        /// <returns> Null if the carPoolId was not found or wrong. </returns>
        CarPoolModel? DeleteCarPool(string carPoolId);
    }
}