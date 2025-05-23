﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineModel.Core
{
    public class CoffeeMachine : ICoffeeMachine
    {
        public List<CoffeeRecipe> CoffeeRecipes { get; private set; }
        public Dictionary<string, int> Resources { get; private set; }

        public CoffeeMachine(int water, int milk, int beans)
        {
            Resources = new Dictionary<string, int>();
            if (water < 0)
                throw new ArgumentException("The amount of water in the coffee machine cannot be negative");
            Resources.Add("water", water);
            if (milk < 0)
                throw new ArgumentException("The amount of milk in the coffee machine cannot be negative");
            Resources.Add("milk", milk);
            if (beans < 0)
                throw new ArgumentException("The number of beans in a coffee machine cannot be negative");
            Resources.Add("beans", beans);
            CoffeeRecipes = new List<CoffeeRecipe>();
            CoffeeRecipes.Add(new CoffeeRecipe("Espresso", 50, 0, 7));
            CoffeeRecipes.Add(new CoffeeRecipe("Americano", 150, 0, 7));
            CoffeeRecipes.Add(new CoffeeRecipe("Cappuccino", 50, 100, 7));
            CoffeeRecipes.Add(new CoffeeRecipe("Latte", 50, 150, 7));
        }

        public CoffeeMachine(int water, int milk, int beans, List<CoffeeRecipe> coffeeRecipes)
        {
            Resources = new Dictionary<string, int>();
            if (water < 0)
                throw new ArgumentException("The amount of water in the coffee machine cannot be negative");
            Resources.Add("water", water);
            if (milk < 0)
                throw new ArgumentException("The amount of milk in the coffee machine cannot be negative");
            Resources.Add("milk", milk);
            if (beans < 0)
                throw new ArgumentException("The number of beans in a coffee machine cannot be negative");
            Resources.Add("beans", beans);
            if (coffeeRecipes.Count == 0)
                throw new ArgumentException("The list of coffee recipes cannot be empty");
            CoffeeRecipes = coffeeRecipes;
        }

        private void UseResource(string name, int number)
        {
            if (Resources[name] < number)
                throw new InvalidOperationException($"Not enough {name}");
            Resources[name] -= number;
        }

        public Coffee BrewCoffee(string name)
        {
            foreach (CoffeeRecipe coffeeRecipe in CoffeeRecipes)
            {
                if (name == coffeeRecipe.Name)
                {
                    UseResource("water", coffeeRecipe.Water);
                    UseResource("milk", coffeeRecipe.Milk);
                    UseResource("beans", coffeeRecipe.Beans);
                    Coffee coffee = new Coffee(coffeeRecipe.Name);
                    return coffee;
                }
            }
            throw new InvalidOperationException("Unknown coffee recipe");
        }
    }
}
