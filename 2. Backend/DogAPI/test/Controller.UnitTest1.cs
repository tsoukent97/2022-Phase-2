using NUnit.Framework;
using 
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
            var result = dogAPIController;

            //Assert
            Assert.That(result, Is.True);
        }
    }
}
