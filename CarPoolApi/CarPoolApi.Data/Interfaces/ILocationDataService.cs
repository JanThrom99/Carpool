using CarPoolApi.Data.Models;

namespace CarPoolApi.Data.Interfaces
{
    public interface ILocationDataService
    {
        List<LocationModel> GetAllLocations();
        LocationModel? GetLocationById(string locationId);
        LocationModel? CreateLocation(LocationModel locationModel);
        LocationModel? UpdateLocation(LocationModel newLocation);
        LocationModel? DeleteLocation(string locationId);
    }
}