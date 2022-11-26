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
    public class Class1
    {
        MotoLogic motoLogic;
        Mock<IRepository<Motorcycle>> mock;

        [SetUp]
        public void InIt()
        {
            mock = new Mock<IRepository<Motorcycle>>();
            mock.Setup(m => m.ReadAll()).Returns(new List<Motorcycle>()
            {
                new Motorcycle(45, "S50", 50, 6, 2),
                new Motorcycle(12, "ETZ", 250, 20, 3),
                new Motorcycle(21, "Pegaso", 650, 36, 4),

            }.AsQueryable());

            motoLogic = new MotoLogic(mock.Object);
        }

        
     
    }
}
