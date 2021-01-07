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
    public class SizeManagerTests
    {
        Mock<ISizeRepository> _mockSizeRepository;

        List<Size> _dbSizes;

        [TestInitialize]
        public void Start()
        {
            _mockSizeRepository = new Mock<ISizeRepository>();

            _dbSizes = new List<Size>
            {
              new Size { Id = 0, Name = "Short", Price = 10 },
              new Size { Id = 1, Name = "Tall", Price = 20 },
              new Size { Id = 2, Name = "Grande", Price = 30 },
              new Size { Id = 3, Name = "Venti", Price = 40 }
            };

            _mockSizeRepository.Setup(m => m.GetAll()).Returns(_dbSizes);
        }

        [TestMethod]
        public void GetTallSizePercentageOfPrice()
        {
            //Arrange
            ISizeService sizeService = new SizeManager(_mockSizeRepository.Object);

            //Act
            var price = sizeService.GetPercentageOfPrice(1);

            //Assert
            Assert.AreEqual(20, price);
        }

        [TestMethod]
        public void IfSizeNotExist()
        {
            //Arrange
            ISizeService sizeService = new SizeManager(_mockSizeRepository.Object);

            //Act
            var price = sizeService.GetPercentageOfPrice(4);

            //Assert
            Assert.AreEqual(-1, price);
        }

        [TestMethod]
        public void GetAllBeverage()
        {
            //Arrange
            ISizeService sizeService = new SizeManager(_mockSizeRepository.Object);

            //Act
            var sizes = sizeService.GetAll();

            //Assert
            Assert.AreEqual(4, sizes.Count);
        }
    }
}
