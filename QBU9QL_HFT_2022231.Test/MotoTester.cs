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
        Mock<IRepository<Motorcycle>> mock;

        [SetUp]
        public void InIt()
        {
            mock = new Mock<IRepository<Motorcycle>>();
            mock.Setup(m => m.ReadAll()).Returns(new List<Motorcycle>()
            {
                new Motorcycle(45, "S50", 50, 6, 12),
                new Motorcycle(12, "ETZ", 250, 20, 13),
                new Motorcycle(21, "Pegaso", 650, 36, 14),

            }.AsQueryable());

            motoLogic = new MotoLogic(mock.Object);
        }

        [Test]
        public void CreateCheck()
        {
            Motorcycle newMoto = new Motorcycle(36, "Varadero", 1000, 102, 3);

            motoLogic.Create(newMoto);

            mock.Verify(m => m.Create(newMoto), Times.Once);
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


            mock.Verify(m => m.Create(newMoto), Times.Never);
        }
        [Test]
        public void DeleteCheck()
        {
            motoLogic.Delete(1);

            mock.Verify(m => m.Delete(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void UpdateCheck()
        {
            Motorcycle newMoto = new Motorcycle(12, "ETZ", 150, 15, 13);

            motoLogic.Update(newMoto);

            mock.Verify(m => m.Update(newMoto), Times.Once);
        }
        [Test]
        public void ReadCheck()
        {
            Motorcycle newMoto = new Motorcycle(45, "S50", 50, 6, 12);
            mock.Setup(m => m.Read(0)).Returns(newMoto);

            var result = motoLogic.Read(0);

            Assert.That(result, Is.EqualTo(newMoto));
        }


    }
}
