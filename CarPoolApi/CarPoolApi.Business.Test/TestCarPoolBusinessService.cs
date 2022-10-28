using CarPoolApi.Data.Models;
using FluentAssertions;
using FluentValidation;

namespace CarPoolApi.Business.Test
{
    [TestClass]
    public class TestCarPoolBusinessService
    {
        CarPoolBusinessService _carPoolBusinessService = new CarPoolBusinessService();

        [TestMethod]
        public void GetAllCarPools()
        {
            //Arrange

            //Act
            var result = _carPoolBusinessService.GetAllCarPools();
            //Assert
            var expected = new List<CarPoolModel>()
            {
                new CarPoolModel()
                {
                    CarPoolId = "CPID#1",
                    Name = "CarPool Example No1",
                    DriverId = "ID#1",
                    PassengerIds = new List<string> {"ID#5","ID#6"},
                    StartingLocation = "New York",
                    Destination = "Washington DC",
                    StartingTime = "09:00",
                    ArrivalTime = "16:30"
                }
            };
            Assert.AreEqual(expected.First().CarPoolId, result.First().CarPoolId);
            Assert.AreEqual(expected.First().StartingLocation, result.First().StartingLocation);
            Assert.AreEqual(expected.First().StartingTime, result.First().StartingTime);
            Assert.AreEqual(expected.First().Destination, result.First().Destination);
            Assert.AreEqual(expected.First().ArrivalTime, result.First().ArrivalTime);
            Assert.AreEqual(expected.First().DriverId, result.First().DriverId);
            result.Should().BeOfType<List<CarPoolModel>>();
        }
        [TestMethod]
        public void GetCarPoolById()
        {
            //Arrange
            var carPoolId = "CPID#1";
            //Act
            var result = _carPoolBusinessService.GetCarPoolById(carPoolId);
            //Assert
            result.Should().BeOfType<CarPoolModel>();
            result.CarPoolId.Should().Be(carPoolId);
        }

        [TestMethod]
        public void CreateCarPool()
        {
            //Arrange
            var carPool = new CarPoolDtoModel()
            {
                Name = "CarPool Example No1",
                DriverId = "ID#1",
                PassengerIds = new List<string> { "ID#5", "ID#6" },
                StartingLocation = "New York",
                Destination = "Washington DC",
                StartingTime = "09:00",
                ArrivalTime = "16:30"
            };

            //Act
            var result = _carPoolBusinessService.CreateCarPool(carPool);

            //Assert
            result.Should().BeOfType<CarPoolModel>();
            result.Name.Should().Be("CarPool Example No1");
        }

        [TestMethod]
        public void UpdateCarPool()
        {
            //Arrange
            var carPool = new CarPoolModel()
            {
                CarPoolId = "CPID#1",
                Name = "foo",
                DriverId = "ID#1",
                PassengerIds = new List<string> { "ID#5", "ID#6" },
                StartingLocation = "New York",
                Destination = "Washington DC",
                StartingTime = "09:00",
                ArrivalTime = "16:30"
            };

            //Act
            var result = _carPoolBusinessService.UpdateCarPool(carPool);

            //Assert
            result.Should().BeOfType<CarPoolModel>();
            result.Name.Should().Be("foo");
            result.CarPoolId.Should().Be("CPID#1");
        }

        [TestMethod]
        public void DeleteCarPool()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}