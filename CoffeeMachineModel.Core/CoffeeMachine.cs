using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineModel.Core
{
    class CoffeeMachine: ICoffeeMachine
    {
        public List<CoffeeRecipe> CoffeeRecipes { get; private set; }
        public Dictionary<string, int> Resources { get; private set; }
    }
}
