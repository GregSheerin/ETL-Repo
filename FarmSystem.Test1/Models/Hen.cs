using System;

namespace FarmSystem.Test1.Models
{
    public sealed class Hen : Animal
    {
        public Hen(Guid id, int noOfLegs = 2) : base(id, noOfLegs)//hen will always have 2 legs I am assuming, if not then this value would need to be passed via the constructor
        {
        }

        public override void Talk()
        {
            Console.WriteLine("Hen says CLUCKAAAAAWWWWK!");
        }
    }
}