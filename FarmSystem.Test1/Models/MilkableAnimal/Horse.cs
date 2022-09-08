using System;
using FarmSystem.Test2.Models.MilkableAnimal;

namespace FarmSystem.Test1.Models.MilkableAnimal
{
    public sealed class Horse : Animal, IMilkableAnimal
    {
        public Horse(Guid id, int noOfLegs = 4) : base(id, noOfLegs)//Horse will always have 4 legs I am assuming, if not then this value would need to be passed via the constructor
        {
        }

        public override void Talk()
        {
            Console.WriteLine("Horse says neigh!");
        }

        public void ProduceMilk()
        {
            Console.WriteLine("Horse produced milk");
        }

    }
}