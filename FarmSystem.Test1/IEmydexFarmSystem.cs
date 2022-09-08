using FarmSystem.Test1.Models;

namespace FarmSystem.Test1
{
    public interface IEmydexFarmSystem
    {
        void Enter(Animal animal);
        void MakeNoise();
        void MilkAnimals();
    }
}