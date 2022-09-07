using System;

namespace FarmSystem.Test1.Models
{
    public abstract class Animal : IAnimal
    {
        private string _id;
        private int _noOfLegs;

        public Animal(Guid id, int noOfLegs)
        {
            Id = id.ToString();
            NoOfLegs = noOfLegs;
        }

        //No need to touch these for test 1
        public string Id
        {
            get { return _id; }
            set
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

        //Dont want actual implentations in the base class,want to enforce other classes using this common funconailty
        public abstract void Run();
        public abstract void Talk();
    }
}
