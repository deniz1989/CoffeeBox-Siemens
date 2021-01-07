using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Business.Abstract;
using WebAPI.Controllers;

namespace WebAPI.Tests
{
    [TestClass]
    public class FlavorsControllerTests
    {
        Mock<IFlavorService> _mockFlavorService;

        [TestInitialize]
        public void Start()
        {
            _mockFlavorService = new Mock<IFlavorService>();
        }

        #region Tests for GetPrice(flavorId, numberOfFlavor)
        [TestMethod]
        public void GetMilkPriceShouldReturnOK()
        {
            // Arrange
            _mockFlavorService.Setup(b => b.GetPrice(1)).Returns(10);
            FlavorsController flavorsController = new FlavorsController(_mockFlavorService.Object);

            //Act
            IActionResult actionResult = flavorsController.GetPrice(1, 3);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void IfFlavorIdIsNegativeShouldReturnsBadRequest()
        {
            // Arrange
            FlavorsController flavorsController = new FlavorsController(_mockFlavorService.Object);

            //Act
            IActionResult actionResult = flavorsController.GetPrice(-1, 1);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void IfFlavorNotExistShouldReturnsBadRequest()
        {
            // Arrange
            _mockFlavorService.Setup(b => b.GetPrice(3)).Returns(-1);
            FlavorsController flavorsController = new FlavorsController(_mockFlavorService.Object);

            //Act
            IActionResult actionResult = flavorsController.GetPrice(3, 1);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void IfNumberOfFlavorLessThenOneShouldReturnsBadRequest()
        {
            // Arrange
            FlavorsController flavorsController = new FlavorsController(_mockFlavorService.Object);

            //Act
            IActionResult actionResult = flavorsController.GetPrice(1, 0);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Tests for GetPrice(flavorId)
        [TestMethod]
        public void GetMilkPriceWithoutNumberOfFlavorShouldReturnOK()
        {
            // Arrange
            _mockFlavorService.Setup(b => b.GetPrice(1)).Returns(10);
            FlavorsController flavorsController = new FlavorsController(_mockFlavorService.Object);

            //Act
            IActionResult actionResult = flavorsController.GetPrice(1);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void IfFlavorIdIsNegativeShouldReturnsBadRequestt()
        {
            // Arrange
            FlavorsController flavorsController = new FlavorsController(_mockFlavorService.Object);

            //Act
            IActionResult actionResult = flavorsController.GetPrice(-1);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void IfFlavorNotExistShouldReturnsBadRequestt()
        {
            // Arrange
            _mockFlavorService.Setup(b => b.GetPrice(3)).Returns(-1);
            FlavorsController flavorsController = new FlavorsController(_mockFlavorService.Object);

            //Act
            IActionResult actionResult = flavorsController.GetPrice(3);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }
        #endregion
    }
}
