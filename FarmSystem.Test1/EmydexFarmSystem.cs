using System;
using System.Linq;
using System.Collections.Generic;
using FarmSystem.Test1.Models;
using FarmSystem.Test2.Models.MilkableAnimal;

namespace FarmSystem.Test1
{
    public class EmydexFarmSystem
    {
        private readonly Queue<Animal> _animalsQue;

        public EmydexFarmSystem()
        {
            _animalsQue = new Queue<Animal>();
        }

        private EventHandler _farmEmptyEvent;
        public event EventHandler farmEmptyEvent
        {
            add
            {
                _farmEmptyEvent += value;
            }
            remove
            {
                _farmEmptyEvent -= value;
            }
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
            var milkableAnimals = _animalsQue.OfType<IMilkableAnimal>(); //grab all the milkable animals

            if (!milkableAnimals.Any()) //if there isnt any, then we can return early, warn the user that there are no milk producing animals
            {
                Console.WriteLine("Cannot identify the farm animals which can be milked");
                return;
            }

            //Otherwise, just loop though and call ProduceMilk
            foreach (var animal in milkableAnimals)
            {
                animal.ProduceMilk();
            }
        }

        //TEST 4
        public void ReleaseAllAnimals()
        {
            //While we still have animals to leave the farm
            while (_animalsQue.Any())
            {
                var animal = _animalsQue.Dequeue(); //deque to get the animal in quest
                Console.WriteLine($"{animal.GetType().Name} has left the farm"); //let the user know the animal just left
            }

            //Once we know we dont have anything left in the que,we can raise the event
            OnFarmEmpty();
        }

        private void OnFarmEmpty()
        {
            //null check to make sure we are acutaly invoking anything
            //invoke method requires object and event args, send this and empty args, no use in the acutal delegate
            _farmEmptyEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}