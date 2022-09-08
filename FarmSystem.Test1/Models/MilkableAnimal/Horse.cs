using System;

namespace FarmSystem.Test1.Models.MilkableAnimal
{
    public sealed class Horse : MilkAbleAnimal
    {
        //Horse will always have 4 legs I am assuming, if not then this value would need to be passed via the constructor
        //Sound wise I am assuming horse will not learn how to baa
        public Horse(Guid id, int noOfLegs = 4) : base(id, noOfLegs, AnimalSounds.neigh)
        {
        }
    }
}