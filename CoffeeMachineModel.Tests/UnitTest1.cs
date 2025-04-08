using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CoffeeMachineModel.Core;

namespace CoffeeMachineModel.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void EmptyCoffeeName()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new Coffee(""));
            Assert.AreEqual("Coffee name cannot be empty", ex.Message);
        }

        [TestMethod]
        public void NormalCoffeeName()
        {
            var instance = new Coffee("Americano");
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void EmptyCoffeeRecipeName()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new CoffeeRecipe("", 100, 100, 100));
            Assert.AreEqual("Coffee recipe name cannot be empty", ex.Message);
        }

        [TestMethod]
        public void NegativeAmountOfWaterInCoffeeRecipe()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new CoffeeRecipe("Americano", -100, 100, 100));
            Assert.AreEqual("The amount of water in a recipe cannot be negative", ex.Message);
        }

        [TestMethod]
        public void NegativeAmountOfMilkInCoffeeRecipe()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new CoffeeRecipe("Americano", 100, -100, 100));
            Assert.AreEqual("The amount of milk in a recipe cannot be negative", ex.Message);
        }

        [TestMethod]
        public void NegativeNumberOfBeansInCoffeeRecipe()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new CoffeeRecipe("Americano", 100, 100, -100));
            Assert.AreEqual("The number of beans in a recipe cannot be negative", ex.Message);
        }

        [TestMethod]
        public void NormalCoffeeRecipe()
        {
            var instance = new CoffeeRecipe("Americano", 100, 100, 100);
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void NegativeAmountOfWaterInCoffeeMachine()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new CoffeeMachine(-1, 1000, 100));
            Assert.AreEqual("The amount of water in the coffee machine cannot be negative", ex.Message);
        }

        [TestMethod]
        public void NegativeAmountOfMilkInCoffeeMachine()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new CoffeeMachine(1000, -1, 100));
            Assert.AreEqual("The amount of milk in the coffee machine cannot be negative", ex.Message);
        }

        [TestMethod]
        public void NegativeNumberOfBeansInCoffeeMachine()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new CoffeeMachine(1000, 1000, -1));
            Assert.AreEqual("The number of beans in a coffee machine cannot be negative", ex.Message);
        }

        [TestMethod]
        public void EmptyListOfCoffeeRecipesInCoffeeMachine()
        {
            List<CoffeeRecipe> coffeeRecipes = new List<CoffeeRecipe>();
            var ex = Assert.ThrowsException<ArgumentException>(() => new CoffeeMachine(1000, 1000, 100, coffeeRecipes));
            Assert.AreEqual("The list of coffee recipes cannot be empty", ex.Message);
        }

        [TestMethod]
        public void NormalCoffeeMachine()
        {
            var instance = new CoffeeMachine(1000, 1000, 100);
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void UnknownCoffeeRecepie()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine(49, 1000, 100);
            var ex = Assert.ThrowsException<InvalidOperationException>(() => coffeeMachine.BrewCoffee("Tea"));
            Assert.AreEqual("Unknown coffee recipe", ex.Message);
        }

        [TestMethod]
        public void NotEnoughWaterForCoffee()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine(49, 1000, 100);
            var ex = Assert.ThrowsException<InvalidOperationException>(() => coffeeMachine.BrewCoffee("Latte"));
            Assert.AreEqual("Not enough water", ex.Message);
        }

        [TestMethod]
        public void NotEnoughMilkForCoffee()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine(1000, 30, 100);
            var ex = Assert.ThrowsException<InvalidOperationException>(() => coffeeMachine.BrewCoffee("Latte"));
            Assert.AreEqual("Not enough milk", ex.Message);
        }

        [TestMethod]
        public void NotEnoughBeansForCoffee()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine(1000, 1000, 6);
            var ex = Assert.ThrowsException<InvalidOperationException>(() => coffeeMachine.BrewCoffee("Latte"));
            Assert.AreEqual("Not enough beans", ex.Message);
        }

        [TestMethod]
        public void SuccessfulCoffeeMaking()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine(1000, 1000, 100);
            var instance = coffeeMachine.BrewCoffee("Latte");
            Assert.IsNotNull(instance);
        }
    }
}
