using System;

namespace FarmSystem.Test1.Models.MilkableAnimal
{
    public sealed class Sheep : MilkAbleAnimal
    {
        //Sheep will always have 4 legs I am assuming, if not then this value would need to be passed via the constructor
        //Sound wise I am assuming sheep will not learn how to moo
        public Sheep(Guid id, int noOfLegs = 4) : base(id, noOfLegs, AnimalSounds.baa)
        {
        }
    }

}