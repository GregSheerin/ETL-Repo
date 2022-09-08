using System;
using System.IO;
using FarmSystem.Test1.Models.MilkableAnimal;
using FarmSystem.Test1.Models;
using FarmSystem.Test2.Models.MilkableAnimal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FarmSystem.UnitTests.Models.MilkableAnimal
{
    [TestClass]
    public class CowTests
    {
        private readonly Cow _sut;
        private readonly Guid _cowGuid; //want to be able to access this later for assertions

        public CowTests()
        {
            _cowGuid = Guid.NewGuid();

            _sut = new Cow(_cowGuid);
        }

        [TestMethod]
        public void Cow_ShouldInheritAnimal()
        {
            //Assert
            Assert.IsInstanceOfType(_sut, typeof(Animal)); //ensure it inherits from animal
        }

        [TestMethod]
        public void Cow_ShouldImplentIMilkableAnimal()
        {
            //Assert
            Assert.IsInstanceOfType(_sut, typeof(IMilkableAnimal)); //ensure that it implemts 
        }

        [TestMethod]
        public void GetId_ShouldReturnGuid()
        {
            //Act Assert
            Assert.AreEqual(_sut.Id, _cowGuid.ToString()); //Check that it sets the ID correctly(IE takes the guid and converts it to a string)
        }

        [TestMethod]
        public void SetId_ShouldSetNewGuid()
        {
            //Arrange
            var newGuid = Guid.NewGuid().ToString();

            //Act
            _sut.Id = newGuid;

            //Act
            Assert.AreEqual(_sut.Id, newGuid); //testing the setter for the ID
        }

        [TestMethod]
        public void GetNumOfLegs_ShouldReturnDefaultNumberOfLegs()
        {
            //Act Assert
            Assert.AreEqual(_sut.NoOfLegs, 4); //checking to ensure the default is passed in(and that the default remains 4)
        }

        [TestMethod]
        public void GetNumOfLegs_DifferntNumOfLegsSet_ShouldReturnNumberOfLegs()
        {
            //Arrange
            var sut = new Cow(Guid.NewGuid(), noOfLegs: 3); //create a new cow for this test with 3 legs

            //act
            Assert.AreEqual(sut.NoOfLegs, 3); //ensure that the cow object did set the leg number to 3 via the constructor
        }

        [TestMethod]
        public void SetNumOfLegs_ShouldSetNumOfLegs()
        {
            //Act
            _sut.NoOfLegs = 5;

            //act
            Assert.AreEqual(_sut.NoOfLegs, 5); //ensure the setter is setting a new number
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
            Assert.AreEqual("Cow produced milk\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void Talk_ShouldOutputMooToTheConsole()
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            _sut.Talk();

            //Assert
            Assert.AreEqual("Cow says Moo!\r\n", stringWriter.ToString());
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
            Assert.AreEqual("Cow is walking\r\n", stringWriter.ToString());
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
            Assert.AreEqual("Cow is running\r\n", stringWriter.ToString());
        }
    }
}
