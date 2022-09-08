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
        public void Milk_ShouldShouldReturnHorseWasMilked()
        {

            //Assert
            Assert.AreEqual("Horse was milked!", _sut.ProduceMilk());
        }

        [TestMethod]
        public void Talk_ShouldReturnHorseSaysNeigh()
        {
            //Assert Act
            Assert.AreEqual("Horse says neigh!", _sut.Talk());
        }


        [TestMethod]
        public void Walk_ShouldReturnHorseIsWalking()
        {

            //Act Assert
            Assert.AreEqual("Horse is walking", _sut.Walk());
        }

        [TestMethod]
        public void Run_ShouldReturnHorseIsRunning()
        {
            //Act Assert
            Assert.AreEqual("Horse is running", _sut.Run());
        }
    }
}
