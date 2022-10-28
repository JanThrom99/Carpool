using CarPoolApi.Data.Interfaces;
using CarPoolApi.Data.Models;

namespace CarPoolApi.Data
{
    public class LocationDataService : ILocationDataService
    {
        public string locationDataPath = Properties.Resources.locationDataPath;
        public List<LocationModel> GetAllLocations()
        {
            var locations = new List<LocationModel>();
            var lines = File.ReadAllLines(locationDataPath);
            foreach (var line in lines)
            {
                if (!String.IsNullOrEmpty(line.Trim()))
                {
                    var newLocationEntry = new LocationModel();
                    var splittedLine = line.Split(';');
                    newLocationEntry.Id = splittedLine[0];
                    newLocationEntry.Name = splittedLine[1];
                    locations.Add(newLocationEntry);
                }
            }
            return locations;
        }

        public LocationModel? GetLocationById(string locationId)
        {
            foreach (var location in GetAllLocations())
            {
                if (location.Id == locationId)
                {
                    return location;
                }
            }
            return null;
        }

        public LocationModel? CreateLocation(LocationModel locationModel)
        {
            File.AppendAllText(locationDataPath, $"\n{locationModel.ToDataString()}");
            return locationModel;
        }

        public LocationModel? UpdateLocation(LocationModel newLocation)
        {
            var oldLocations = GetAllLocations();
            var newLocations = new List<string>();
            LocationModel? locationToUpdate = null;
            File.WriteAllText(locationDataPath, "");

            foreach (var location in oldLocations)
            {
                if (!(location.Id == newLocation.Id))
                {
                    newLocations.Add(location.ToDataString());
                }
                else
                {
                    newLocations.Add(newLocation.ToDataString());
                    locationToUpdate = newLocation;
                }
            }
            File.AppendAllLines(locationDataPath, newLocations);
            if (locationToUpdate == null)
            {
                return null;
            }
            return locationToUpdate;
        }

        public LocationModel? DeleteLocation(string locationId)
        {
            var oldLocations = GetAllLocations();
            var newLocations = new List<string>();
            LocationModel? locationToDelete = null;
            File.WriteAllText(locationDataPath, "");

            foreach (var location in oldLocations)
            {
                if (!(location.Id == locationId))
                {
                    newLocations.Add(location.ToDataString());
                }
                else
                {
                    locationToDelete = location;
                }
            }
            File.AppendAllLines(locationDataPath, newLocations);
            if (locationToDelete == null)
            {
                return null;
            }
            return locationToDelete;
        }
    }
}
