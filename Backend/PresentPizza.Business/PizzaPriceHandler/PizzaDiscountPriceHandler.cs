using PresentPizza.Domain.Models;

namespace PresentPizza.Business.PizzaPriceHandler;

public class PizzaDiscountPriceHandler : PizzaPriceHandler
{
    public override double CalculateSum(PizzaOrder pizzaOrder, double totalSum)
    {
        double discountSize = 0.1;
        double minimumToppingCount = 3;

        if (pizzaOrder.PizzaOrderToppings.Count > minimumToppingCount)
        {
            totalSum *= 1 - discountSize;
        }

        return GetSum(pizzaOrder, totalSum);
    }
}