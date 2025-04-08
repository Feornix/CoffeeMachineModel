using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineModel.Core
{
    public class CoffeeRecipe
    {
        private string name;
        private int water;
        private int milk;
        private int beans;

        public string Name
        {
            get { return name; }
            private set
            {
                if (value == "")
                    throw new ArgumentException("Coffee recipe name cannot be empty");
                name = value;
            }
        }

        public int Water
        {
            get { return water; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("The amount of water in a recipe cannot be negative");
                water = value;
            }
        }
        public int Milk
        {
            get { return milk; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("The amount of milk in a recipe cannot be negative");
                milk = value;
            }
        }

        public int Beans
        {
            get { return beans; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("The number of beans in a recipe cannot be negative");
                beans = value;
            }
        }

        public CoffeeRecipe(string name, int water, int milk, int beans)
        {
            Name = name;
            Water = water;
            Milk = milk;
            Beans = beans;
        }
    }
}
