using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineModel.Core
{
    interface ICoffeeMachine
    {
        Coffee BrewCoffee(string name);
    }
}
