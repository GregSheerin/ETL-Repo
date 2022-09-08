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
        public void Talk_ShouldReturnHenSaysCluck()
        {
            //Act Assert
            Assert.AreEqual("Hen says CLUCKAAAAAWWWWK!", _sut.Talk());
        }

        [TestMethod]
        public void Walk_ShouldReturnIsWalking()
        {

            //Act Assert
            Assert.AreEqual("Hen is walking", _sut.Walk());
        }

        [TestMethod]
        public void Run_ShouldReturnIsRunning()
        {
            //Act Assert
            Assert.AreEqual("Hen is running", _sut.Run());
        }
    }
}
