using CarPoolApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolApi.Business.Interfaces
{
    /// <summary>
    /// The Interface for the Location Business Service where all the Methods and their return types and parameters are defined.
    /// </summary>
    public interface ILocationBusinessService
    {
        /// <summary>
        /// A Method which will return a List with all the existing locations that are currently in the .csv file.
        /// </summary>
        /// <returns> An unfiltered list with LocationModels. (List can be empty) </returns>
        List<LocationModel> GetAllLocations();

        /// <summary>
        /// A Method which will return a single location that is identified by the locationId.
        /// </summary>
        /// <param name="locationId"> The Id of the location the customer wants to get. </param>
        /// <returns> A single LocationModel. </returns>
        /// <returns> Null if the locationId was not found or wrong. </returns>
        LocationModel? GetLocationById(string locationId);

        /// <summary>
        /// A Method which will receive a locationDtoModel and then create a new Dataset in the .csv file with the given data in the model.
        /// </summary>
        /// <param name="locationDtoModel"> A locationDtoModel with all the data the user wants in the to be created dataset. </param>
        /// <returns> A single LocationModel Object with the data of the newly created dataset. </returns>
        /// <returns> Null if the passed data was faulty. </returns>
        LocationModel? CreateLocation(LocationDtoModel locationDtoModel);

        /// <summary>
        /// A Method which will update an existing location dataset and overwrite it with new data. 
        /// </summary>
        /// <param name="newLocation"> A LocationModel with the new locationData. </param>
        /// <returns> A single LocationModel Object with the data of the updated dataset. </returns>
        /// <returns> Null if the location to update was not found or the data wrong. </returns>
        LocationModel? UpdateLocation(LocationModel newLocation);

        /// <summary>
        /// A Method which will delete an existing location dataset.
        /// </summary>
        /// <param name="locationId"> The Id of the location that the customer wants to delete. </param>
        /// <returns> A single LocationModel Object with the data of the deleted dataset. </returns>
        /// <returns> Null if the locationId was not found or wrong. </returns>
        LocationModel? DeleteLocation(string locationId);
    }
}