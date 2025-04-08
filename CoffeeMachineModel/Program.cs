using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachineModel.Core;

namespace CoffeeMachineModel.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int water, milk, beans;
            string name;
            Console.WriteLine("Enter the amount of water in the coffee machine:");
            water = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the amount of milk in the coffee machine:");
            milk = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of beans in the coffee machine:");
            beans = Convert.ToInt32(Console.ReadLine());
            CoffeeMachine coffeeMachine = new CoffeeMachine(water, milk, beans);
            Console.WriteLine("Enter the name of the coffee:");
            name = Console.ReadLine();
            Coffee coffee = coffeeMachine.BrewCoffee(name);
            Console.WriteLine($"Your {coffee.Name} is ready.");
            Console.ReadKey();
        }
    }
}
