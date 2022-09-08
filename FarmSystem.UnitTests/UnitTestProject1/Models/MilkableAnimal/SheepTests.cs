using System;
using System.IO;
using FarmSystem.Test1.Models.MilkableAnimal;
using FarmSystem.Test1.Models;
using FarmSystem.Test2.Models.MilkableAnimal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FarmSystem.UnitTests.Models.MilkableAnimal
{
    [TestClass]
    public class SheepTests
    {
        private readonly Sheep _sut;
        private readonly Guid _sheepGuid;

        public SheepTests()
        {
            _sheepGuid = Guid.NewGuid();

            _sut = new Sheep(_sheepGuid);
        }

        [TestMethod]
        public void Sheep_ShouldInheritAnimal()
        {
            //Assert
            Assert.IsInstanceOfType(_sut, typeof(Animal));
        }

        [TestMethod]
        public void Sheep_ShouldImplentIMilkableAnimal()
        {
            //Assert
            Assert.IsInstanceOfType(_sut, typeof(IMilkableAnimal));
        }

        [TestMethod]
        public void GetId_ShouldReturnGuid()
        {
            //Act Assert
            Assert.AreEqual(_sut.Id, _sheepGuid.ToString());
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
            var sut = new Sheep(Guid.NewGuid(), noOfLegs: 3);

            //act
            Assert.AreEqual(sut.NoOfLegs, 3);
        }

        [TestMethod]
        public void SetNumOfLegs_ShouldSetNumOfLegs()
        {
            //Act
            _sut.NoOfLegs = 5;

            //act
            Assert.AreEqual(_sut.NoOfLegs, 5);
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
            Assert.AreEqual("Sheep produced milk\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void Talk_ShouldOutputBaaToTheConsole()
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            _sut.Talk();

            //Assert
            Assert.AreEqual("Sheep says baa!\r\n", stringWriter.ToString());
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
            Assert.AreEqual("Sheep is walking\r\n", stringWriter.ToString());
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
            Assert.AreEqual("Sheep is running\r\n", stringWriter.ToString());
        }
    }
}

