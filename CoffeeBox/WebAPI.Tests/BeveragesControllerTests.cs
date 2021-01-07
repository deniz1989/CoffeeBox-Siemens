using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Business.Abstract;
using WebAPI.Controllers;
using WebAPI.DataAccess.Abstract;
using WebAPI.Models;

namespace WebAPI.Tests
{
    [TestClass]
    public class BeveragesControllerTests
    {
        Mock<IBeverageService> _mockBeverageService;
        Mock<ISizeService> _mockSizeService;

        [TestInitialize]
        public void Start()
        {
            _mockBeverageService = new Mock<IBeverageService>();
            _mockSizeService = new Mock<ISizeService>();
        }

        [TestMethod]
        public void GetVentiLattePriceShouldReturnOK()
        {
            // Arrange
            _mockBeverageService.Setup(b => b.GetPrice(1)).Returns(10);
            _mockSizeService.Setup(s => s.GetPercentageOfPrice(3)).Returns(40);
            BeveragesController beveragesController = new BeveragesController(_mockBeverageService.Object, _mockSizeService.Object);

            //Act
            IActionResult actionResult = beveragesController.GetPrice(1, 3);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void IfBeverageIdIsNegativeShouldReturnsBadRequest()
        {
            // Arrange
            BeveragesController beveragesController = new BeveragesController(_mockBeverageService.Object, _mockSizeService.Object);

            //Act
            IActionResult actionResult = beveragesController.GetPrice(-1, 1);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void IfBeverageSizeIsNegativeShouldReturnsBadRequest()
        {
            // Arrange
            BeveragesController beveragesController = new BeveragesController(_mockBeverageService.Object, _mockSizeService.Object);

            //Act
            IActionResult actionResult = beveragesController.GetPrice(1, -1);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void IfBeverageNotExistShouldReturnsBadRequest()
        {
            //Arrange
            _mockBeverageService.Setup(b => b.GetPrice(5)).Returns(-1);
            _mockSizeService.Setup(s => s.GetPercentageOfPrice(1)).Returns(20);
            BeveragesController beveragesController = new BeveragesController(_mockBeverageService.Object, _mockSizeService.Object);

            //Act
            IActionResult actionResult = beveragesController.GetPrice(5, 1);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void IfBeverageSizeNotExistShouldReturnsBadRequest()
        {
            //Arrange
            _mockBeverageService.Setup(b => b.GetPrice(1)).Returns(10);
            _mockSizeService.Setup(s => s.GetPercentageOfPrice(3)).Returns(-1);
            BeveragesController beveragesController = new BeveragesController(_mockBeverageService.Object, _mockSizeService.Object);

            //Act
            IActionResult actionResult = beveragesController.GetPrice(1, 3);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }
    }
}
