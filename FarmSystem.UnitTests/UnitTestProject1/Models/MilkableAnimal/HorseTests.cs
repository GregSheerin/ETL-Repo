using System;
using System.IO;
using FarmSystem.Test1.Models.MilkableAnimal;
using FarmSystem.Test1.Models;
using FarmSystem.Test2.Models.MilkableAnimal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FarmSystem.UnitTests.Models.MilkableAnimal
{
    [TestClass]
    public class HorseTests
    {
        private readonly Horse _sut;
        private readonly Guid _horseGuid;

        public HorseTests()
        {
            _horseGuid = Guid.NewGuid();

            _sut = new Horse(_horseGuid);
        }

        [TestMethod]
        public void Horse_ShouldInheritAnimal()
        {
            //Assert
            Assert.IsInstanceOfType(_sut, typeof(Animal));
        }

        [TestMethod]
        public void Horse_ShouldImplentIMilkableAnimal()
        {
            //Assert
            Assert.IsInstanceOfType(_sut, typeof(IMilkableAnimal));
        }

        [TestMethod]
        public void GetId_ShouldReturnGuid()
        {
            //Act Assert
            Assert.AreEqual(_sut.Id, _horseGuid.ToString());
        }

        [TestMethod]
        public void SetId_ShouldSetNewGuid()
        {
            //Arrange
            var newGuid = Guid.NewGuid().ToString();

            //Act
            _sut.Id = newGuid;

            //Act
            Assert.AreEqual(_sut.Id, newGuid);
        }

        [TestMethod]
        public void GetNumOfLegs_ShouldReturnDefaultNumberOfLegs()
        {
            //Act Assert
            Assert.AreEqual(_sut.NoOfLegs, 4);
        }

        [TestMethod]
        public void GetNumOfLegs_DifferntNumOfLegsSet_ShouldReturnNumberOfLegs()
        {
            //Arrange
            var sut = new Horse(Guid.NewGuid(), noOfLegs: 3);

            //act
            Assert.AreEqual(sut.NoOfLegs, 3);
        }

        [TestMethod]
        public void Milk_ShouldOutputMilkProducedToTheConsole()
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act 
            _sut.ProduceMilk();

            //Assert
            Assert.AreEqual("Horse produced milk\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void Talk_ShouldOutputNeighToTheConsole()
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            _sut.Talk();

            //Assert
            Assert.AreEqual("Horse says neigh!\r\n", stringWriter.ToString());
        }


        [TestMethod]
        public void Walk_ShouldOutputWalkingToTheConsole()
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            _sut.Walk();

            //Assert
            Assert.AreEqual("Horse is walking\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void Run_ShouldOutputRunningToTheConsole()
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            _sut.Run();

            //Assert
            Assert.AreEqual("Horse is running\r\n", stringWriter.ToString());
        }
    }
}
