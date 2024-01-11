using PresentPizza.Business.Services;
using PresentPizza.Domain.Models;

namespace PresentPizza.Tests;

public class Tests
{
    [Test]
    [TestCase(PizzaSize.Small, 8.0)]
    [TestCase(PizzaSize.Medium, 10.0)]
    [TestCase(PizzaSize.Large, 12.0)]
    public void CalculatePizzaCost_ShouldReturnCorrectCost_WhenGivenPizzaOrderWithSize(PizzaSize pizzaSize,
        double expectedCost)
    {
        var pizzaOrder = new PizzaOrder { PizzaSize = pizzaSize };
        var pizzaOrderService = new PizzaOrderService();

        var result = pizzaOrderService.CalculatePizzaCost(pizzaOrder);

        Assert.AreEqual(expectedCost, result);
    }

    [Test]
    public void CalculatePizzaCost_ShouldReturnCorrectCost_WhenGivenLargePizzaOrderAndFourToppingsResultWithDiscount()
    {
        var pizzaOrder = new PizzaOrder
        {
            Id = 1, PizzaSize = PizzaSize.Large,
            PizzaOrderToppings = new List<PizzaOrderTopping>
            {
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 1, Name = "Cheese" } },
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 2, Name = "Sausage" } },
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 2, Name = "Pepperoni" } },
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 2, Name = "Real meat" } }
            }
        };

        var pizzaOrderService = new PizzaOrderService();

        var result = pizzaOrderService.CalculatePizzaCost(pizzaOrder);

        Assert.AreEqual(14.4, result);
    }

    [Test]
    public void CalculatePizzaCost_ShouldReturnCorrectCost_WhenGivenMediumPizzaOrderAndFourToppingsResultWithDiscount()
    {
        var pizzaOrder = new PizzaOrder
        {
            Id = 1, PizzaSize = PizzaSize.Medium,
            PizzaOrderToppings = new List<PizzaOrderTopping>
            {
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 1, Name = "Cheese" } },
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 2, Name = "Sausage" } },
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 3, Name = "Pepperoni" } },
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 4, Name = "Real meat" } }
            }
        };

        var pizzaOrderService = new PizzaOrderService();

        var result = pizzaOrderService.CalculatePizzaCost(pizzaOrder);

        Assert.AreEqual(12.6, result);
    }

    [Test]
    public void CalculatePizzaCost_ShouldReturnCorrectCost_WhenGivenMediumPizzaOrderAndFiveToppingsResultWithDiscount()
    {
        var pizzaOrder = new PizzaOrder
        {
            Id = 1, PizzaSize = PizzaSize.Medium,
            PizzaOrderToppings = new List<PizzaOrderTopping>
            {
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 1, Name = "Cheese" } },
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 2, Name = "Sausage" } },
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 3, Name = "Pepperoni" } },
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 4, Name = "Real meat" } },
                new PizzaOrderTopping { PizzaOrderId = 1, Topping = new Topping { Id = 5, Name = "Real meat" } }
            }
        };

        var pizzaOrderService = new PizzaOrderService();

        var result = pizzaOrderService.CalculatePizzaCost(pizzaOrder);

        Assert.AreEqual(13.5, result);
    }
}