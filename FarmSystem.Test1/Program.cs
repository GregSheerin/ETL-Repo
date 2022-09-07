using System;
using FarmSystem.Test1.Models;
using FarmSystem.Test1.Models.MilkableAnimal;

namespace FarmSystem.Test1
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Excercise1();
            Excercise2();
            Excercise3();
            Excercise4();
            Console.ReadKey();
        }

        /************************************************************************************************************
        Exercise 1 : Apply OOP concepts (abstraction and encapsulation) to the classes 
        modify the code to get the output below
        Cow has entered the farm
        Hen has entered the farm
        Horse has entered the farm
        Sheep has entered the farm
        ***************************************************************************************************************/
        private static void Excercise1()
        {
            Console.WriteLine("Exercise 1 : Press any key when it is time to open the Farm to animals\n");
            Console.ReadKey();

            var _ = InitFarmSystem(); //only need to init it here, on init they all enter the farm, so can discard

            Console.ReadKey();
        }

        /***************************************************************************************************************
         Test Excercise 2
         If you have completed the first test excercise, you can continue with the second one
         Modify the program and EmydexFarmSystem.MakeNoise() method to get the below output
         Expected Test 2 Program Output

         Exercise 2 : Press any key to scare the animals in the farm
            Cow has entered the farm
            Hen has entered the farm
            Horse has entered the farm
            Sheep has entered the farm
            Cow says Moo!
            Hen says CLUCKAAAAAWWWWK!
            Horse says Neigh!
            Sheep says baa!
         *****************************************************************************************************************/
        private static void Excercise2()
        {
            //TODO : Apply OOP concepts and modify the code below to get the required output 
            Console.WriteLine("Exercise 2 : Press any key to scare the animals in the farm\n");
            Console.ReadKey();

            var farm = InitFarmSystem(); //Now I need the farm, so assign it instead of discard
            farm.MakeNoise();

            Console.ReadKey();
        }

        /*****************************************************************************************************************
        Test Excercise 3
        If you have completed the previous test excercise, you can continue with this one 
        The project includes an interface IMilkableAnimal. Make use of this interface to implement on the relevant classes
        so that calling the EmydexFarmSystem.MilkAnimals() method to get the below output

        Expected Test 3 Program Output

        Exercise 3 : Press any key when it is time to milk animals
        Cow has entered the farm
        Hen has entered the farm
        Horse has entered the farm
        Sheep has entered the farm
        Cow was milked!
        ************************************************************************************************************/
        private static void Excercise3()
        {
            //TODO : Apply OOP concepts and modify the code below to get the required output 
            Console.WriteLine("Exercise 3 : Press any key when it is time to milk animals\n");
            Console.ReadKey();

            var farm = InitFarmSystem();
            farm.MilkAnimals();

            Console.ReadKey();
        }

        /****************************************************************************************************
        Test Excercise 4
        Modify the EmydexFarmSystem.ReleaseAllAnimals() so that all animals are released (simply clear the collection )
        Expose an event on the FarmSystem FarmEmpty which is invoked once all the animals are released
        Subscribe to that event in the main to get the expected output

        Expected Test 4 Program Output

        Exercise 4: Press any key to free all animals
        Cow has entered the farm
        Hen has entered the farm
        Horse has entered the farm
        Sheep has entered the farm
        Cow has left the farm
        Hen has left the farm
        Horse has left the farm
        Sheep has left the farm
        Emydex Farm is now empty
        ********************************************************************************************************************/
        private static void Excercise4()
        {
            Console.WriteLine("Exercise 4: Press any key to free all animals\n");
            Console.ReadKey();

            var farm = InitFarmSystem();
            farm.FarmEmpty += OnFarmEmptied; //subscribe onto the event with a handler declared below

            farm.ReleaseAllAnimals();

            Console.ReadKey();
        }

        //Since we are always dealing with the same collection of animals, can set up the EmydexFarm here and reuse
        private static EmydexFarmSystem InitFarmSystem()
        {
            var farm = new EmydexFarmSystem();

            var cow = new Cow(Guid.NewGuid());
            farm.Enter(cow);

            var hen = new Hen(Guid.NewGuid());
            farm.Enter(hen);

            var horse = new Horse(Guid.NewGuid());
            farm.Enter(horse);

            var sheep = new Sheep(Guid.NewGuid());
            farm.Enter(sheep);

            return farm;
        }

        //Delegate to be passed on to the farm system, will be invoked once the farm is emptied
        public static void OnFarmEmptied(object sender, EventArgs e)
        {
            Console.WriteLine("Emydex Farm is now empty");
        }
    }

}
