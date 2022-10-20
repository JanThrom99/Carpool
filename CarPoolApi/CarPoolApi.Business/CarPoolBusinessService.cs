using CarPoolApi.Data;
using CarPoolApi.Data.Models;

namespace CarPoolApi.Business
{
    public class CarPoolBusinessService
    {
        CarPoolDataService carPoolDataService = new CarPoolDataService();
        
        public List<CarPoolModel> GetAllCarPools()
        {
            return new List<CarPoolModel>();
        }
        public CarPoolModel GetCarPoolById()
        {
            return new CarPoolModel();
        }
        public CarPoolModel CreateCarPool()
        {
            return new CarPoolModel();
        }
        public CarPoolModel UpdateCarPool()
        {
            return new CarPoolModel();
        }
        public CarPoolModel DeleteCarPool()
        {
            return new CarPoolModel();
        }
    }
}