using System;
using FarmSystem.Test2.Models.MilkableAnimal;

namespace FarmSystem.Test1.Models.MilkableAnimal
{
    public class Cow : Animal, IMilkableAnimal
    {
        public Cow(Guid id, int noOfLegs = 4) : base(id, noOfLegs)//Cow will always have 4 legs I am assuming, if not then this value would need to be passed via the constructor
        {
        }

        //So far cow is the only one to have a "walk" method, but all given animals should be able to walk(In theroy)
        //TODO : If it is a case of common funcionalty ripping out, leave be, other move walk to base animal class
        public override void Walk()
        {
            Console.WriteLine("Cow is walking");
        }

        public void ProduceMilk()
        {
            Console.WriteLine("Cow produced milk");
        }

        public override void Run()
        {
            Console.WriteLine("Cow is running");
        }

        public override void Talk()
        {
            Console.WriteLine("Cow says Moo!");
        }

    }
}