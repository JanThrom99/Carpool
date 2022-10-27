using CarPoolApi.Data.Models;

namespace CarPoolApi.Data.Interfaces
{
    public interface ICarPoolDataService
    {
        List<CarPoolModel> GetAllCarPools();
        CarPoolModel? CreateCarPool(CarPoolModel carPool);
        CarPoolModel? UpdateCarPool(CarPoolModel newCarPool);
        CarPoolModel? DeleteCarPool(string carPoolId);
    }
}