using CarPoolApi.Data;
using CarPoolApi.Data.Models;

namespace CarPoolApi.Business.Test
{
    [TestClass]
    public class TestCarPoolBusinessService
    {
        CarPoolBusinessService _carPoolBusinessService  = new CarPoolBusinessService();

        [TestMethod]
        public void GetAllCarPools()
        {
            //Arrange

            //Act
            var result = _carPoolBusinessService.GetAllCarPools();
            //Assert
            var expected = new List<CarPoolModel>() 
            {
                new CarPoolModel(){},
                new CarPoolModel(){},
                new CarPoolModel(){}
            };
            Assert.AreEqual(expected, result);
        }

        public void GetCarPoolById(string carPoolId)
        {
            //Arrange

            //Act

            //Assert
        }

        public void CreateCarPool(CarPoolDtoModel carPool)
        {
            //Arrange

            //Act

            //Assert
        }

        public void UpdateCarPool(CarPoolModel carPool)
        {
            //Arrange

            //Act

            //Assert
        }

        public void DeleteCarPool(string carPoolId)
        {
            //Arrange

            //Act

            //Assert
        }
    }
}