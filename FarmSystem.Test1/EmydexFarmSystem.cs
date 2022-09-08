using System;
using System.Linq;
using System.Collections.Generic;
using FarmSystem.Test1.Models;
using FarmSystem.Test2.Models.MilkableAnimal;

namespace FarmSystem.Test1
{
    public class EmydexFarmSystem : IEmydexFarmSystem
    {
        private readonly Queue<Animal> _animalsQue; //declare the que here

        public EmydexFarmSystem()
        {
            _animalsQue = new Queue<Animal>(); //init it here in the conctructor.
        }

        private EventHandler _farmEmpty;
        public event EventHandler FarmEmpty //add and remove for event handler
        {
            add
            {
                _farmEmpty += value;
            }
            remove
            {
                _farmEmpty -= value;
            }
        }

        //TEST 1
        public void Enter(Animal animal) //All types dervice from animal, so makes more sense to use that here.
        {
            _animalsQue.Enqueue(animal);//add the naimal to the que
            Console.WriteLine($"{animal.GetType().Name} has entered the Emydex farm"); //Using get type here,types are the name of the animal
        }

        //TEST 2
        public void MakeNoise()
        {
            foreach (var animal in _animalsQue) //All animals can talk, so loop though everything and call talk
            {
                Console.WriteLine(animal.Talk()); //all animals will return X says sound, so just write each out to the console(reasoning for this in ReadMe)
            }
        }

        //TEST 3
        public void MilkAnimals()
        {
            var milkableAnimals = _animalsQue.OfType<IMilkableAnimal>(); //use linq to get all the animals that implement IMilkableAnimal

            if (!milkableAnimals.Any()) //if there isnt any, then we can return early, warn the user that there are no milk producing animals
            {
                Console.WriteLine("Cannot identify the farm animals which can be milked");
                return;
            }

            //Otherwise, just loop though and call ProduceMilk
            foreach (var animal in milkableAnimals)
            {
                Console.WriteLine(animal.ProduceMilk());//all animals will return X says sound, so just write each out to the console(reasoning for this in ReadMe)
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

        //Would of put this in the release all animals method, but this could be resued for another method
        //EG Animals break out, could be called at the end of that logic
        private void OnFarmEmpty()
        {
            //invoke method requires object and event args, send this and empty args, no use in the acutal delegate
            //null check to make sure we are acutaly invoking anything, this will do nothing if the field is empty
            _farmEmpty?.Invoke(this, EventArgs.Empty);
        }
    }
}