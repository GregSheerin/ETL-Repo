using System;
using System.Collections.Generic;
using FarmSystem.Test1.Models;

namespace FarmSystem.Test1
{
    public class EmydexFarmSystem
    {
        private readonly Queue<Animal> _animalsQue;

        public EmydexFarmSystem()
        {
            _animalsQue = new Queue<Animal>();
        }
        //TEST 1
        public void Enter(Animal animal) //All types dervice from animal, so makes more sense to use that here.
        {
            //Hold all the animals so it is available for future activities
            _animalsQue.Enqueue(animal);
            Console.WriteLine($"{animal.GetType().Name} has entered the Emydex farm"); //Using get type here,types are the name of the animal
        }

        //TEST 2
        public void MakeNoise()
        {
            //Test 2 : Modify this method to make the animals talk
            foreach (var animal in _animalsQue) //All animals can talk, so loop though everything and call talk
            {
                animal.Talk();
            }
        }

        //TEST 3
        public void MilkAnimals()
        {
            Console.WriteLine("Cannot identify the farm animals which can be milked");
        }

        //TEST 4
        public void ReleaseAllAnimals()
        {
            Console.WriteLine("There are still animals in the farm, farm is not free");
        }
    }
}