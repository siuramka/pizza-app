using PresentPizza.Domain.Models;

namespace PresentPizza.Business.PizzaPriceHandler;

public class PizzaToppingPriceHandler : PizzaPriceHandler
{
    private const double PricePerTopping = 1;
    public override double CalculateSum(PizzaOrder pizzaOrder, double totalSum)
    {
        totalSum += pizzaOrder.PizzaOrderToppings.Count * PricePerTopping;
        
        return GetSum(pizzaOrder, totalSum);
    }
}