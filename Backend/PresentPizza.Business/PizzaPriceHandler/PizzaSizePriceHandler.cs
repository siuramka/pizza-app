using PresentPizza.Business.PizzaPriceSizeCalculator;
using PresentPizza.Domain.Models;

namespace PresentPizza.Business.PizzaPriceHandler;

public class PizzaSizePriceHandler : PizzaPriceHandler
{
    private IPizzaSizePriceCalculator _pizzaSizePriceCalculator;

    public PizzaSizePriceHandler(IPizzaSizePriceCalculator pizzaSizePriceCalculator)
    {
        _pizzaSizePriceCalculator = pizzaSizePriceCalculator;
    }

    public override double CalculateSum(PizzaOrder pizzaOrder, double totalSum)
    {
        totalSum += _pizzaSizePriceCalculator.CalculateSizeCost();

        return GetSum(pizzaOrder, totalSum);
    }
}