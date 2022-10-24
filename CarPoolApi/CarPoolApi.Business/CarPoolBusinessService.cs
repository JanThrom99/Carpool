using CarPoolApi.Data;
using CarPoolApi.Data.Models;
using System.Text.RegularExpressions;

namespace CarPoolApi.Business
{
    public class CarPoolBusinessService
    {
        CarPoolDataService _carPoolDataService = new CarPoolDataService();
        Regex idPatternRegex = new Regex("^[A-Z]{2}[#].*[0-9]$");

        public List<CarPoolModel> GetAllCarPools()
        {
            return _carPoolDataService.GetAllCarPools();
        }
        public CarPoolModel? GetCarPoolById(string carPoolId)
        {
            if (!String.IsNullOrEmpty(carPoolId) && idPatternRegex.IsMatch(carPoolId))
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
        public CarPoolModel CreateCarPool(CarPoolDtoModel carPool)
        {
            if (String.IsNullOrEmpty(carPool.Name)
                || String.IsNullOrEmpty(carPool.DriverId)
                || String.IsNullOrEmpty(carPool.StartingLocation) 
                || String.IsNullOrEmpty(carPool.Destination) 
                || String.IsNullOrEmpty(carPool.StartingTime) 
                || String.IsNullOrEmpty(carPool.ArrivalTime) )
            {
                return null;
            }
            var carPoolModel = new CarPoolModel()
            {
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
        public CarPoolModel UpdateCarPool(CarPoolModel carPool)
        {
            if (!String.IsNullOrEmpty(carPool.CarPoolId)&& idPatternRegex.IsMatch(carPool.CarPoolId))
            {
                return _carPoolDataService.UpdateCarPool(carPool);
            }
            return null;
        }
        public CarPoolModel DeleteCarPool(string carPoolId)
        {
            if (!String.IsNullOrEmpty(carPoolId) && idPatternRegex.IsMatch(carPoolId))
            {
                return _carPoolDataService.DeleteCarPool(carPoolId);
            }
            return null;
        }
    }
}