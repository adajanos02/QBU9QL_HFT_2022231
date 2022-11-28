using System;
using NUnit.Framework;
using Moq;
using QBU9QL_HFT_2022231.Logic;
using QBU9QL_HFT_2022231.Models;
using QBU9QL_HFT_2022231.Repository;
using System.Collections.Generic;
using System.Linq;
using QBU9QL_HFT_2022231.Logic.Classes;
using QBU9QL_HFT_2022231.Repository.Interfaces;

namespace QBU9QL_HFT_2022231.Test
{

    [TestFixture]
    public class MotoTester
    {
        MotoLogic motoLogic;
        RiderLogic riderLogic;
        BrandLogic brandLogic;

       

        Mock<IRepository<Motorcycle>> mockMoto;
        Mock<IRepository<Riders>> mockRiders;
        Mock<IRepository<Brands>> mockBrands;


        [SetUp]
        public void InIt()
        {
            mockMoto = new Mock<IRepository<Motorcycle>>();
            mockRiders = new Mock<IRepository<Riders>>();
            mockBrands = new Mock<IRepository<Brands>>();

            var brands = new List<Brands>()
            {
                 new Brands(1, "Simson", 1856, 30000000),
                 new Brands(2, "MZ", 1785, 90000),
                 new Brands(3, "Aprilia", 1955, 3000),
            };

            var motos = new List<Motorcycle>()
            {
                new Motorcycle(1, "S50", 50, 6, 2) {Brands = brands[0]},
                new Motorcycle(2, "ETZ", 850, 20, 3) {Brands = brands[1]},
                new Motorcycle(3, "Pegaso", 900, 36, 1) {Brands = brands[2]},
            };

            var riders = new List<Riders>()
            {
                new Riders(1, "Max Verstappen", 1999, 'M', 2) {Motorcycle = motos[1]},
                new Riders(2, "Lewis Hamilton", 1992, 'M', 1) {Motorcycle = motos[0]},
                new Riders(3, "Niki Lauda", 1965, 'M', 3) {Motorcycle = motos[2]},
            };



            mockMoto.Setup(m => m.ReadAll()).Returns(motos.AsQueryable());
            mockRiders.Setup(m => m.ReadAll()).Returns(riders.AsQueryable());
            mockBrands.Setup(m => m.ReadAll()).Returns(brands.AsQueryable());

            motoLogic = new MotoLogic(mockMoto.Object);
            riderLogic = new RiderLogic(mockRiders.Object);
            brandLogic = new BrandLogic(mockBrands.Object);

            

        }
      
        [Test]
        public void HasThisModelTest()
        {
            var expected = new List<object>()
            {
                new Riders(1, "Max Verstappen", 1999, 'M', 2),
            };

            var result = riderLogic.HasThisModel().ToList();

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void MasMoreThan800ccmMoto()
        {
            var expected = new List<object>()
            {
                new Riders(1, "Max Verstappen", 1999, 'M', 2),
                new Riders(3, "Niki Lauda", 1965, 'M', 3),
            };

            var result = riderLogic.HasMoreThan800ccmMoto().ToList();

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void HasApriliaTest()
        {
            object expected = new List<object>()
            {
                new Riders(3, "Niki Lauda", 1965, 'M', 3),
            };

            var result = riderLogic.HasAprilia().ToList();

            Assert.AreEqual(expected, result);

        }
        [Test]
        public void MaxSoldCompanyTest()
        {
            var expected = new List<object>()
            {
                new Motorcycle(1, "S50", 50, 6, 2),
            };
            
            var result = motoLogic.MaxSoldCompany().ToList();

            Assert.AreEqual(expected.ToString(), result.ToString());  
        }

        [Test]
        public void CompanyOlderThan70Test()
        {
            var expected = new List<object>()
            {
                new Brands(1, "Simson", 1856, 30000000),
                new Brands(2, "MZ", 1785, 90000),
            };

            var result = motoLogic.CompanyOlderThan70().ToList();

            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [Test]
        public void CreateCheck()
        {
            Motorcycle newMoto = new Motorcycle(36, "Varadero", 1000, 102, 3);

            motoLogic.Create(newMoto);

            mockMoto.Verify(m => m.Create(newMoto), Times.Once);
        }

        [Test]
        public void CreateCheckWithIncorrectInput()
        {
            Motorcycle newMoto = new Motorcycle() { MotoId = 87 };
            try
            {
                motoLogic.Create(newMoto);
            }
            catch (Exception)
            {

            }


            mockMoto.Verify(m => m.Create(newMoto), Times.Never);
        }
        [Test]
        public void CreateCheckWithIncorrectModelName()
        {
            Motorcycle newMoto = new Motorcycle(36, "aaaaaaaaaaa", 1000, 1, 125);
            try
            {
                motoLogic.Create(newMoto);
            }
            catch (Exception)
            {

            }


            mockMoto.Verify(m => m.Create(newMoto), Times.Never);

        }
        [Test]
        public void DeleteCheck()
        {
            motoLogic.Delete(1);

            mockMoto.Verify(m => m.Delete(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void UpdateCheck()
        {
            Motorcycle newMoto = new Motorcycle(12, "ETZ", 150, 15, 13);

            motoLogic.Update(newMoto);

            mockMoto.Verify(m => m.Update(newMoto), Times.Once);
        }
        [Test]
        public void ReadCheck()
        {
            Motorcycle newMoto = new Motorcycle(45, "S50", 50, 6, 12);
            mockMoto.Setup(m => m.Read(0)).Returns(newMoto);

            var result = motoLogic.Read(0);

            Assert.That(result, Is.EqualTo(newMoto));
        }




    }
}
