using CarPoolApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolApi.Business.Interfaces
{
    public interface ICarPoolBusinessService
    {
        List<CarPoolModel> GetAllCarPools();
        CarPoolModel? GetCarPoolById(string carPoolId);
        CarPoolModel? CreateCarPool(CarPoolDtoModel carPool);
        CarPoolModel? UpdateCarPool(CarPoolModel carPool);
        CarPoolModel? DeleteCarPool(string carPoolId);
    }
}