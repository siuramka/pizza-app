using PresentPizza.Domain.Models;

namespace PresentPizza.Business.PizzaPriceHandler;

public abstract class PizzaPriceHandler
{
    private PizzaPriceHandler? _next;

    public void SetNext(PizzaPriceHandler next)
    {
        _next = next;
    }

    public abstract double CalculateSum(PizzaOrder pizzaOrder, double totalSum);

    protected double GetSum(PizzaOrder pizzaOrder, double totalSum)
    {
        return _next == null ? totalSum : _next.CalculateSum(pizzaOrder, totalSum);
    }
}