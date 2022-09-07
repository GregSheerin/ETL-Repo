using System;

namespace FarmSystem.Test1.Models
{
    public class Horse : Animal
    {
        public Horse(Guid id, int noOfLegs = 4) : base(id, noOfLegs)//Horse will always have 4 legs I am assuming, if not then this value would need to be passed via the constructor
        {
        }

        public override void Talk()
        {
            Console.WriteLine("Horse says neigh!");
        }

        public override void Run()
        {
            Console.WriteLine("Horse is running");
        }

    }
}