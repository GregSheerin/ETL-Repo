using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSystem.Test1.Models
{
    public abstract class Animal
    {
        private string _id;
        private int _noOfLegs = 4;

        public Animal(Guid id, int noOfLegs)
        {
            Id = id.ToString();
            NoOfLegs = noOfLegs;
            NoOfLegs = noOfLegs;
        }

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
    }
}
