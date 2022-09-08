using System;

namespace FarmSystem.Test1.Models
{
    public abstract class Animal : IAnimal
    {
        private string _id;
        private int _noOfLegs;
        private AnimalSounds _sound;

        public Animal(Guid id, int noOfLegs, AnimalSounds sound)
        {
            Id = id.ToString();
            NoOfLegs = noOfLegs; //passed in from children type. Cow will always have 4 legs, but could create a snake class,inherit this class, and assign 0 for the base controcutor
            _sound = sound;
        }

        public string Id
        {
            get { return _id; }
            set //TODO: Convert the ID to use GUID? Need to think about that one, user would have to convert it to a string before setting
            {
                _id = value;
            }
        }

        public int NoOfLegs
        {
            get
            {
                return _noOfLegs;
            }
            set
            {
                _noOfLegs = value;
            }
        }

        //Since the Walk and Run methods the extact same for each anima(bar the name), can implent it here and use it for the classes(virutal so overwriting is possible)
        //NOTE on the run/walk methods. They are unsed in the exercises, keeping them in as I think pulling out the core functionalty is a part of the exercises
        //If it is the case were I am wrong here, I would remove these unsed methods entierly
        public virtual string Run()
        {
            return $"{GetType().Name} is running"; //Using get type here,types are the name of the animal
        }
        public virtual string Talk()
        {
            return $"{GetType().Name} says {_sound}!"; //Extract out the sound in the constrctor, use it here
        }
        public virtual string Walk()
        {
            return $"{GetType().Name} is walking"; //Using get type here,types are the name of the animal
        }
    }
}
