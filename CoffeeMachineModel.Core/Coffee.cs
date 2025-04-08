using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineModel.Core
{
    public class Coffee
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (value == "")
                    throw new ArgumentException("Coffee name cannot be empty");
                name = value;
            }
        }
        public Coffee(string name)
        {
            Name = name;
        }
    }
}
