namespace PresentPizza.Business.PizzaPriceSizeCalculator;

public class LargePizzaSizePriceCalculator : IPizzaSizePriceCalculator
{
    public double CalculateSizeCost()
    {
        return 12;
    }
}