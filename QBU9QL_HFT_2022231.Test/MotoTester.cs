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

       

        Mock<IRepository<Moto>> mockMoto;
        Mock<IRepository<Rider>> mockRiders;
        Mock<IRepository<Brand>> mockBrands;


        [SetUp]
        public void InIt()
        {
            mockMoto = new Mock<IRepository<Moto>>();
            mockRiders = new Mock<IRepository<Rider>>();
            mockBrands = new Mock<IRepository<Brand>>();

            var brands = new List<Brand>()
            {
                 new Brand(1, "Simson", 1856, 30000000),
                 new Brand(2, "MZ", 1785, 90000),
                 new Brand(3, "Aprilia", 1955, 3000),
            };

            var motos = new List<Moto>()
            {
                new Moto(1, "S50", 50, 6, 2) {Brands = brands[0]},
                new Moto(2, "ETZ", 850, 20, 3) {Brands = brands[1]},
                new Moto(3, "Pegaso", 900, 36, 1) {Brands = brands[2]},
            };

            var riders = new List<Rider>()
            {
                new Rider(1, "Max Verstappen", 1999, 'M', 2) {Motorcycle = motos[1]},
                new Rider(2, "Lewis Hamilton", 1992, 'M', 1) {Motorcycle = motos[0]},
                new Rider(3, "Niki Lauda", 1965, 'M', 3) {Motorcycle = motos[2]},
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
                "Max Verstappen"
            };

            var result = riderLogic.HasETZModel().ToList();

            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [Test]
        public void MasMoreThan800ccmMoto()
        {
            var expected = new List<object>()
            {
                "Max Verstappen"
                
            };

            var result = riderLogic.HasMoreThan800ccmMoto().ToList();

            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [Test]
        public void HasApriliaTest()
        {
            object expected = new List<object>()
            {
                "Niki Lauda"
            };

            var result = riderLogic.HasAprilia().ToList();

            Assert.AreEqual(expected.ToString(), result.ToString());

        }
        [Test]
        public void MaxSoldCompanyTest()
        {
            var expected = new List<object>()
            {
                "S50"
            };
            
            var result = motoLogic.ThisModelHasTheBestBrand().ToList();

            Assert.AreEqual(expected.ToString(), result.ToString());  
        }

        [Test]
        public void CompanyOlderThan70Test()
        {
            var expected = new List<object>()
            {
                "Simson",
                "MZ"
            };

            var result = motoLogic.CompanyOlderThan70().ToList();

            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [Test]
        public void CreateCheck()
        {
            Moto newMoto = new Moto(36, "Varadero", 1000, 102, 3);

            motoLogic.Create(newMoto);

            mockMoto.Verify(m => m.Create(newMoto), Times.Once);
        }

        [Test]
        public void CreateCheckWithIncorrectInput()
        {
            Moto newMoto = new Moto() { MotoId = 87 };
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
            Moto newMoto = new Moto(36, "aaaaaaaaaaa", 1000, 1, 125);
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
            Moto newMoto = new Moto(12, "ETZ", 150, 15, 13);

            motoLogic.Update(newMoto);

            mockMoto.Verify(m => m.Update(newMoto), Times.Once);
        }
        [Test]
        public void ReadCheck()
        {
            Moto newMoto = new Moto(45, "S50", 50, 6, 12);
            mockMoto.Setup(m => m.Read(0)).Returns(newMoto);

            var result = motoLogic.Read(0);

            Assert.That(result, Is.EqualTo(newMoto));
        }




    }
}
