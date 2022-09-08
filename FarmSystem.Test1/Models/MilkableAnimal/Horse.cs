using System;

namespace FarmSystem.Test1.Models.MilkableAnimal
{
    public sealed class Horse : MilkAbleAnimal
    {
        public Horse(Guid id, int noOfLegs = 4) : base(id, noOfLegs, AnimalSounds.neigh)//Horse will always have 4 legs I am assuming, if not then this value would need to be passed via the constructor
        {
        }
    }
}