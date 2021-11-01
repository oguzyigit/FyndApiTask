using FyndApiTask.Controllers;
using FyndApiTask.Model;
using FyndApiTask.Service;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace FyndApiTaskTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetHotels_Should_ReturnOk()
        {
            //Arrange
            var mock = new Mock<IHotelService>();
            mock.Setup(foo => foo.GetByHotelIdAndArrivedDate(1, System.DateTime.Now)).Returns(new List<Root>());
            var loggerMock = new Mock<ILogger<HotelController>>();
            var controller = new HotelController(loggerMock.Object, mock.Object);

            //Act
            var result = controller.Get(hotelId: 1, arrivalDate: System.DateTime.Now);
            var okResult = result as OkObjectResult;

            //Assert
            NUnit.Framework.Assert.IsNotNull(okResult);
            NUnit.Framework.Assert.AreEqual(200, okResult.StatusCode);

        }
    }
}