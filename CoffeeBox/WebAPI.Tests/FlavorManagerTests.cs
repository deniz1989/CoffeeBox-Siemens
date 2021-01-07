using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Business.Abstract;
using WebAPI.Business.Concrete;
using WebAPI.DataAccess.Abstract;
using WebAPI.Models;

namespace WebAPI.Tests
{
    [TestClass]
    public class FlavorManagerTests
    {
        Mock<IFlavorRepository> _mockFlavorRepository;
        List<Flavor> _dbFlavors;

        [TestInitialize]
        public void Start()
        {
            _mockFlavorRepository = new Mock<IFlavorRepository>();

            _dbFlavors = new List<Flavor>
            {
                new Flavor { Id = 0, Name = "Milk", Price = 10 },
                new Flavor { Id = 1, Name = "Chocalate sauce", Price = 10 },
                new Flavor { Id = 2, Name = "Hazelnut Syrup", Price = 10 },
            };

            _mockFlavorRepository.Setup(m => m.GetAll()).Returns(_dbFlavors);
        }

        [TestMethod]
        public void GetMilkPrice()
        {
            IFlavorService flavorService = new FlavorManager(_mockFlavorRepository.Object);

            var price = flavorService.GetPrice(0);

            Assert.AreEqual(10, price);
        }

        [TestMethod]
        public void IfFlavorNotExist()
        {
            //Arrange
            IFlavorService flavorService = new FlavorManager(_mockFlavorRepository.Object);

            //Act
            var price = flavorService.GetPrice(3);

            //Assert
            Assert.AreEqual(-1, price);
        }

        [TestMethod]
        public void GetAllBeverage()
        {
            //Arrange
            IFlavorService flavorService = new FlavorManager(_mockFlavorRepository.Object);

            //Act
            var flavors = flavorService.GetAll();

            //Assert
            Assert.AreEqual(3, flavors.Count);
        }
    }
}
