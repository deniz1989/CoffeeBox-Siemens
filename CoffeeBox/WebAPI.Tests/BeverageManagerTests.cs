using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Business.Abstract;
using WebAPI.Business.Concrete;
using WebAPI.Controllers;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete;
using WebAPI.Models;

namespace WebAPI.Tests
{
    [TestClass]
    public class BeverageManagerTests
    {
        Mock<IBeverageRepository> _mockBeverageRepository;

        List<Beverage> _dbBeverages;

        [TestInitialize]
        public void Start()
        {
            _mockBeverageRepository = new Mock<IBeverageRepository>();

            _dbBeverages = new List<Beverage>
            {
                new Beverage { Id = 0, Name = "Black Coffee", Price = 10 },
                new Beverage { Id = 1, Name = "Latte", Price = 10 },
                new Beverage { Id = 2, Name = "Mocha", Price = 10 },
                new Beverage { Id = 3, Name = "Tea", Price = 10 }
            };

            _mockBeverageRepository.Setup(m => m.GetAll()).Returns(_dbBeverages);
        }

        [TestMethod]
        public void GetLattePrice()
        {
            //Arrange
            IBeverageService beverageService = new BeverageManager(_mockBeverageRepository.Object);

            //Act
            var price = beverageService.GetPrice(1);

            //Assert
            Assert.AreEqual(10, price);
        }

        [TestMethod]
        public void IfBeverageNotExist()
        {
            //Arrange
            IBeverageService beverageService = new BeverageManager(_mockBeverageRepository.Object);

            //Act
            var price = beverageService.GetPrice(5);

            //Assert
            Assert.AreEqual(-1, price);
        }

        [TestMethod]
        public void GetAllBeverage()
        {
            //Arrange
            IBeverageService beverageService = new BeverageManager(_mockBeverageRepository.Object);

            //Act
            var beverages = beverageService.GetAll();

            //Assert
            Assert.AreEqual(4, beverages.Count);
        }
    }
}
