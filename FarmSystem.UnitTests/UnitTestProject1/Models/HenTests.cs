using System;
using System.IO;
using FarmSystem.Test1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.Models
{
    [TestClass]
    public class HenTests
    {
        private readonly Hen _sut;
        private readonly Guid _henGuid;

        public HenTests()
        {
            _henGuid = Guid.NewGuid();

            _sut = new Hen(_henGuid);
        }

        [TestMethod]
        public void Hen_ShouldInheritAnimal()
        {
            //Assert
            Assert.IsInstanceOfType(_sut, typeof(Animal));
        }

        [TestMethod]
        public void GetId_ShouldReturnGuid()
        {
            //Act Assert
            Assert.AreEqual(_sut.Id, _henGuid.ToString());
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
            Assert.AreEqual(_sut.NoOfLegs, 2);
        }

        [TestMethod]
        public void GetNumOfLegs_DifferntNumOfLegsSet_ShouldReturnNumberOfLegs()
        {
            //Arrange
            var sut = new Hen(Guid.NewGuid(), noOfLegs: 1);

            //act
            Assert.AreEqual(sut.NoOfLegs, 1);
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
        public void Talk_ShouldOutputCluckToTheConsole()
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            _sut.Talk();

            //Assert
            var res = stringWriter.ToString();
            Assert.AreEqual("Hen says CLUCKAAAAAWWWWK!\r\n", stringWriter.ToString());
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
            Assert.AreEqual("Hen is walking\r\n", stringWriter.ToString());
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
            Assert.AreEqual("Hen is running\r\n", stringWriter.ToString());
        }
    }
}
