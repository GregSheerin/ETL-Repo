using System;
using System.IO;
using FarmSystem.Test1.Models.MilkableAnimal;
using FarmSystem.Test1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FarmSystem.Test1;

namespace FarmSystem.UnitTests
{
    [TestClass]
    public class EmydexFarmSystemTests
    {
        private readonly EventHandler _eventHandler;

        public EmydexFarmSystemTests()
        {
            //Need to declare this above and then init here for reuse on tests related to event
            //Using anonoymus functions doesnt gurante that one will del1 = del2, and I want to test the removal so I need a defined handler
            _eventHandler = (s, e) => Console.WriteLine("TestDelegateOutPut");
        }

        [TestMethod]
        public void EmydexFarmSystem_ShouldImplementIEmydexFarmSystem()
        {
            //Arrange Act
            var sut = new EmydexFarmSystem();

            //Assert
            Assert.IsInstanceOfType(sut, typeof(IEmydexFarmSystem));
        }

        [TestMethod]
        public void Enter_OutPutsAnimalsIntoTheFarm()
        {
            //Arrange
            var sut = new EmydexFarmSystem();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var cow = new Cow(Guid.NewGuid());

            //Act
            sut.Enter(cow);

            //Assert
            Assert.AreEqual("Cow has entered the Emydex farm\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void MakeNoise_AnimalsMakeNoise()
        {
            //Arrange
            var sut = new EmydexFarmSystem();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var cow = new Cow(Guid.NewGuid());
            var hen = new Hen(Guid.NewGuid());

            //Act
            sut.Enter(cow);
            sut.Enter(hen);
            sut.MakeNoise();

            //Assert
            Assert.AreEqual("Cow has entered the Emydex farm\r\nHen has entered the Emydex farm\r\nCow says Moo!\r\nHen says CLUCKAAAAAWWWWK!\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void MilkAnimals_MilkableAnimalsInFarm_MilksAnimals()
        {
            //Arrange
            var sut = new EmydexFarmSystem();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var cow = new Cow(Guid.NewGuid());
            var horse = new Horse(Guid.NewGuid());

            //Act
            sut.Enter(cow);
            sut.Enter(horse);
            sut.MilkAnimals();

            //Assert
            Assert.AreEqual("Cow has entered the Emydex farm\r\nHorse has entered the Emydex farm\r\nCow was milked!\r\nHorse was milked!\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void MilkAnimals_NoMilkableAnimalsInFarm_WarnsUser()
        {
            //Arrange
            var sut = new EmydexFarmSystem();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var hen = new Hen(Guid.NewGuid());

            //Act
            sut.Enter(hen);
            sut.MilkAnimals();

            //Assert
            Assert.AreEqual("Hen has entered the Emydex farm\r\nCannot identify the farm animals which can be milked\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void ReleaseAllAnimals_AnnoucesAnimalsLeavingAndCallsDelegate()
        {
            //Arrange
            var sut = new EmydexFarmSystem();
            sut.FarmEmpty += _eventHandler;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var cow = new Cow(Guid.NewGuid());
            var horse = new Horse(Guid.NewGuid());

            //Act

            //Act
            sut.Enter(cow);
            sut.Enter(horse);
            sut.ReleaseAllAnimals();

            //Assert
            Assert.AreEqual("Cow has entered the Emydex farm\r\nHorse has entered the Emydex farm\r\nCow has left the farm\r\nHorse has left the farm\r\nTestDelegateOutPut\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void ReleaseAllAnimals_AnnoucesAnimalsLeaving_DoesntNotCallDelgateIfRemoved()
        {
            //Arrange
            var sut = new EmydexFarmSystem();
            sut.FarmEmpty += _eventHandler;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var cow = new Cow(Guid.NewGuid());
            var horse = new Horse(Guid.NewGuid());
            sut.FarmEmpty -= _eventHandler;
            //Act
            sut.Enter(cow);
            sut.Enter(horse);
            sut.ReleaseAllAnimals();

            //Assert
            Assert.AreEqual("Cow has entered the Emydex farm\r\nHorse has entered the Emydex farm\r\nCow has left the farm\r\nHorse has left the farm\r\n", stringWriter.ToString());
        }
    }
}
