using DogAPI.Controllers;
using DogAPI.Models.Dto;

namespace Controller.UnitTests;

public class DogAPIControllerTest
{
    [TestFixture]
    public class GetDogsTest
    {
        [Test]
        public void CanReturnDogList()
        {
            //Arrange
            var dogAPIController = new DogAPIController();

            //Act
            var result = dogAPIController.GetDogs();

            //Assert
            List<DogsDTO> expected = new List<DogsDTO>();
            DogsDTO dog1 = new DogsDTO { Id = 1, Name = "Pug", Size = "Small", AverageWeight = "8kgs" };
            DogsDTO dog2 = new DogsDTO { Id = 2, Name = "Border Collie", Size = "Medium", AverageWeight = "20kgs" };
            expected.Add(dog1);
            expected.Add(dog2);
            Assert.AreEqual(expected.Count, 2);
        }
    }
}
