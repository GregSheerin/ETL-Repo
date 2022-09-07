using System;

namespace FarmSystem.Test1.Models
{
    public class Sheep : Animal
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
    }

}