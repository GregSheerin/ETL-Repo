using System;

namespace FarmSystem.Test1.Models
{
    public sealed class Hen : Animal
    {
        //hen will always have 2 legs I am assuming, if not then this value would need to be passed via the constructor
        //Sound wise I am assuming sheep will not learn how to moo
        public Hen(Guid id, int noOfLegs = 2) : base(id, noOfLegs, AnimalSounds.CLUCKAAAAAWWWWK)
        {
        }
    }
}