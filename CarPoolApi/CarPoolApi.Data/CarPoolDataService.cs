using CarPoolApi.Data.Models;

namespace CarPoolApi.Data
{
    public class CarPoolDataService
    {
        public string carPoolDataPath = CarPoolApi.Data.Properties.Resources.carPoolDataPath;

        public List<CarPoolModel> GetAllCarPools()
        {
            var carPools = new List<CarPoolModel>();

            var lines = File.ReadAllLines(carPoolDataPath);
            foreach (var line in lines)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    var carPoolModel = new CarPoolModel();
                    var splittedLine = line.Split(';');

                    carPoolModel.CarPoolId = splittedLine[0];
                    carPoolModel.Name = splittedLine[1];
                    carPoolModel.DriverId = splittedLine[2];
                    carPoolModel.PassengerIds = CreatePassengerList(splittedLine[3]);
                    carPoolModel.StartingLocation = splittedLine[4];
                    carPoolModel.Destination = splittedLine[5];
                    carPoolModel.StartingTime = splittedLine[6];
                    carPoolModel.ArrivalTime = splittedLine[7];

                    carPools.Add(carPoolModel);
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
            File.AppendAllLines(carPoolId, newCarPools);
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