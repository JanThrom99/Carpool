using CarPoolApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolApi.Business.Interfaces
{
    public interface ILocationBusinessService
    {
        List<LocationModel> GetAllLocations();
        LocationModel? GetLocationById(string locationId);
        LocationModel? CreateLocation(LocationDtoModel locationDtoModel);
        LocationModel? UpdateLocation(LocationModel newLocation);
        LocationModel? DeleteLocation(string locationId);
    }
}
