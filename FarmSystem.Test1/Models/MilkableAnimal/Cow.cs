using System;
using FarmSystem.Test2.Models.MilkableAnimal;

namespace FarmSystem.Test1.Models.MilkableAnimal
{
    public sealed class Cow : MilkAbleAnimal, IMilkableAnimal
    {
        public Cow(Guid id, int noOfLegs = 4) : base(id, noOfLegs, AnimalSounds.Moo)//Cow will always have 4 legs I am assuming, if not then this value would need to be passed via the constructor
        {
        }
    }
}