using CarPoolApi.Data.Models;
using CarPoolApi.Data;
using System.Text.RegularExpressions;

namespace CarPoolApi.Business
{
    public class LocationBusinessService
    {
        LocationDataService _locationDataService = new LocationDataService();
        Regex locationIdPatternRegex = new Regex("^[A-Z]{3}[#].*[0-9]$");
        public List<LocationModel> GetAllLocations()
        {
            return _locationDataService.GetAllLocations();
        }

        public LocationModel? GetLocationById(string locationId)
        {
            if (!String.IsNullOrEmpty(locationId) && locationIdPatternRegex.IsMatch(locationId))
            {
                foreach (var location in _locationDataService.GetAllLocations())
                {
                    if (location.Id == locationId)
                    {
                        return location;
                    }
                }
            }
            return null;
        }

        public LocationModel? CreateLocation(LocationDtoModel locationDtoModel)
        {
            if (String.IsNullOrEmpty(locationDtoModel.Name))
            {
                return null;
            }
            var locationModel = new LocationModel()
            {
                Id = GetNewLocationId(),
                Name = locationDtoModel.Name
            };
            return _locationDataService.CreateLocation(locationModel);
        }

        public LocationModel? UpdateLocation(LocationModel newLocation)
        {
            if (!String.IsNullOrEmpty(newLocation.Id) && locationIdPatternRegex.IsMatch(newLocation.Id))
            {
                return _locationDataService.UpdateLocation(newLocation);
            }
            return null;
        }

        public LocationModel? DeleteLocation(string locationId)
        {
            if (!String.IsNullOrEmpty(locationId) && locationIdPatternRegex.IsMatch(locationId))
            {
                return _locationDataService.DeleteLocation(locationId);
            }
            return null;
            
        }

        #region Helper Methods
        public string GetNewLocationId()
        {
            int highestId = 0;
            var currentLocations = GetAllLocations();

            foreach (var locations in currentLocations)
            {
                if (Convert.ToInt32(locations.Id.Split('#').Last()) > highestId)
                {
                    highestId = Convert.ToInt32(locations.Id.Split('#').Last());
                }
            }
            var newId = Convert.ToInt32(highestId) + 1;
            return $"LID#{newId}"; ;
        }
        #endregion
    }
}
