using CarPoolApi.Business.Interfaces;
using CarPoolApi.Data;
using CarPoolApi.Data.Models;
using System.Text.RegularExpressions;

namespace CarPoolApi.Business
{
    public class CarPoolBusinessService : ICarPoolBusinessService
    {
        CarPoolDataService _carPoolDataService = new CarPoolDataService();
        Regex carPoolIdPatternRegex = new Regex("^[A-Z]{4}[#].*[0-9]$");

        public List<CarPoolModel> GetAllCarPools()
        {
            var result = _carPoolDataService.GetAllCarPools();
            return result;
        }

        public CarPoolModel? GetCarPoolById(string carPoolId)
        {
            if (!String.IsNullOrEmpty(carPoolId) && carPoolIdPatternRegex.IsMatch(carPoolId))
            {
                var allCarPool = _carPoolDataService.GetAllCarPools();
                foreach (var carPool in allCarPool)
                {
                    if (carPoolId == carPool.CarPoolId)
                    {
                        return carPool;
                    }
                }
                return null;
            }
            return null;
        }

        public CarPoolModel? CreateCarPool(CarPoolDtoModel carPool)
        {
            if (String.IsNullOrEmpty(carPool.Name)
                || String.IsNullOrEmpty(carPool.DriverId)
                || String.IsNullOrEmpty(carPool.StartingLocation) 
                || String.IsNullOrEmpty(carPool.Destination))
            {
                return null;
            }
            var carPoolModel = new CarPoolModel()
            {
                CarPoolId = GetNewCarPoolId(),
                Name = carPool.Name,
                DriverId = carPool.DriverId,
                PassengerIds = carPool.PassengerIds,
                StartingLocation = carPool.StartingLocation,
                Destination = carPool.Destination,
                StartingTime = carPool.StartingTime,
                ArrivalTime = carPool.ArrivalTime,
            };

            return _carPoolDataService.CreateCarPool(carPoolModel);
        }

        public CarPoolModel? UpdateCarPool(CarPoolModel carPool)
        {
            if (!String.IsNullOrEmpty(carPool.CarPoolId)&& carPoolIdPatternRegex.IsMatch(carPool.CarPoolId))
            {
                return _carPoolDataService.UpdateCarPool(carPool);
            }
            return null;
        }

        public CarPoolModel? DeleteCarPool(string carPoolId)
        {
            if (!String.IsNullOrEmpty(carPoolId) && carPoolIdPatternRegex.IsMatch(carPoolId))
            {
                return _carPoolDataService.DeleteCarPool(carPoolId);
            }
            return null;
        }

        #region Helper Methods
        public string GetNewCarPoolId()
        {
            int highestId = 0;
            var currentCarPools = GetAllCarPools();

            foreach (var carPool in currentCarPools)
            {
                if (Convert.ToInt32(carPool.CarPoolId.Trim().Split('#').Last()) > highestId)
                {
                    highestId = Convert.ToInt32(carPool.CarPoolId.Split('#').Last());
                }
            }

            var newId = Convert.ToInt32(highestId) + 1;
            return $"CPID#{newId}";
        }
        #endregion
    }
}