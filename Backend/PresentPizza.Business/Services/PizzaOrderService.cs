using PresentPizza.Business.PizzaPriceHandler;
using PresentPizza.Business.PizzaPriceSizeCalculator;
using PresentPizza.DataAccess.Repositories;
using PresentPizza.Domain.Models;

namespace PresentPizza.Business.Services;

public class PizzaOrderService
{
    public double CalculatePizzaCost(PizzaOrder pizzaOrder)
    {
        IPizzaSizePriceCalculator pizzaSizePriceCalculator = GetPizzaSizeCalculator(pizzaOrder);

        var sizePriceHandler = new PizzaSizePriceHandler(pizzaSizePriceCalculator);
        var toppingPriceHandler = new PizzaToppingPriceHandler();
        var discountPriceHandler = new PizzaDiscountPriceHandler();

        sizePriceHandler.SetNext(toppingPriceHandler);
        toppingPriceHandler.SetNext(discountPriceHandler);

        int pizzaCostSum = 0;

        return sizePriceHandler.CalculateSum(pizzaOrder, pizzaCostSum);
    }

    private IPizzaSizePriceCalculator GetPizzaSizeCalculator(PizzaOrder pizzaOrder)
    {
        switch (pizzaOrder.PizzaSize)
        {
            case PizzaSize.Small:
                return new SmallPizzaSizePriceCalculator();
            case PizzaSize.Medium:
                return new MediumPizzaSizePriceCalculator();
            case PizzaSize.Large:
                return new LargePizzaSizePriceCalculator();
            default:
                throw new Exception();
        }
    }
}