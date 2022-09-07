using System;

namespace FarmSystem.Test1.Models
{
    public class Hen : Animal
    {
        public Hen(Guid id, int noOfLegs = 2) : base(id, noOfLegs)//hen will always have 2 legs I am assuming, if not then this value would need to be passed via the constructor
        {
        }

        public override void Run()
        {
            Console.WriteLine("Hen is running");
        }

        public override void Talk()
        {
            Console.WriteLine("Hen say CLUCKAAAAAWWWWK!");
        }
    }
}