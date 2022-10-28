using CarPoolApi.Data.Interfaces;
using CarPoolApi.Data.Models;

namespace CarPoolApi.Data
{
    public class CarPoolDataService : ICarPoolDataService
    {
        public string carPoolDataPath = Properties.Resources.carPoolDataPath;

        public List<CarPoolModel> GetAllCarPools()
        {
            var carPools = new List<CarPoolModel>();

            var lines = File.ReadAllLines(carPoolDataPath);
            foreach (var line in lines)
            {
                if (!String.IsNullOrEmpty(line.Trim()))
                {
                    var carPoolModel = new CarPoolModel();
                    var splittedLine = line.Split(';');
                    if (!String.IsNullOrEmpty(splittedLine[0].Trim()))
                    {
                        carPoolModel.CarPoolId = splittedLine[0].Trim();
                        carPoolModel.Name = splittedLine[1].Trim();
                        carPoolModel.DriverId = splittedLine[2].Trim();
                        carPoolModel.PassengerIds = CreatePassengerList(splittedLine[3]);
                        carPoolModel.StartingLocation = splittedLine[4].Trim();
                        carPoolModel.Destination = splittedLine[5].Trim();
                        carPoolModel.StartingTime = splittedLine[6].Trim();
                        carPoolModel.ArrivalTime = splittedLine[7].Trim();

                        carPools.Add(carPoolModel);
                    }
                }
            }
            return carPools;
        }

        public CarPoolModel? CreateCarPool(CarPoolModel carPool)
        {
            File.AppendAllText(carPoolDataPath, $"\n{carPool.ToDataString()}");
            return carPool;
        }

        public CarPoolModel? UpdateCarPool(CarPoolModel newCarPool)
        {
            var oldCarPools = GetAllCarPools();
            var newCarPools = new List<string>();
            CarPoolModel? carPoolToUpdate = null;
            File.WriteAllText(carPoolDataPath, "");

            foreach (var carPool in oldCarPools)
            {
                if (!(carPool.CarPoolId == newCarPool.CarPoolId))
                {
                    newCarPools.Add(carPool.ToDataString());
                }
                else
                {
                    newCarPools.Add(newCarPool.ToDataString());
                    carPoolToUpdate = newCarPool;
                }
            }
            File.AppendAllLines(carPoolDataPath, newCarPools);
            if (carPoolToUpdate == null)
            {
                return null;
            }
            return carPoolToUpdate;
        }

        public CarPoolModel? DeleteCarPool(string carPoolId)
        {
            var oldCarPools = GetAllCarPools();
            var newCarPools = new List<string>();
            CarPoolModel? deletedCarPool = null;
            File.WriteAllText(carPoolDataPath, "");
            foreach (var carPool in oldCarPools)
            {
                if (!(carPool.CarPoolId == carPoolId))
                {
                    newCarPools.Add(carPool.ToDataString());
                }
                else
                {
                    deletedCarPool = carPool;
                }
            }
            File.AppendAllLines(carPoolDataPath, newCarPools);
            if (deletedCarPool == null)
            {
                return null;
            }
            return deletedCarPool;
        }

        #region Helper Methods
        public List<string> CreatePassengerList(string passengerString)
        {
            var PassengerIds = new List<string>();
            var splittedIds = passengerString.Split(',');
            foreach (var id in splittedIds)
            {
                PassengerIds.Add(id);
            }
            return PassengerIds;
        }
        #endregion
    }
} 