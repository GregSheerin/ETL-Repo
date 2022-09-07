using System;
using FarmSystem.Test2.Models.MilkableAnimal;

namespace FarmSystem.Test1.Models.MilkableAnimal
{
    public class Sheep : Animal, IMilkableAnimal
    {

        public Sheep(Guid id, int noOfLegs = 4) : base(id, noOfLegs)//Sheep will always have 4 legs I am assuming, if not then this value would need to be passed via the constructor
        {
        }
        public override void Talk()
        {
            Console.WriteLine("Sheep says baa!");
        }

        public override void Run()
        {
            Console.WriteLine("Sheep is running");
        }

        public override void Walk()
        {
            Console.WriteLine("Sheep is walking");
        }

        public void ProduceMilk()
        {
            Console.WriteLine("Sheep produced milk");
        }
    }

}