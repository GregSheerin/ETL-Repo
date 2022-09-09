using System;
using FarmSystem.Test2.Models.MilkableAnimal;

namespace FarmSystem.Test1.Models.MilkableAnimal
{
    public class MilkAbleAnimal : Animal, IMilkableAnimal
    {
        public MilkAbleAnimal(Guid id, int noOfLegs, AnimalSounds sound) : base(id, noOfLegs, sound)
        {
        }

        //Extract out the milking functionalty here to avoid code repeating
        public virtual string ProduceMilk()
        {
            return $"{GetType().Name} was milked!"; //Using get type here,types are the name of the animal
        }
    }
}
