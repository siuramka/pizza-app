namespace PresentPizza.Business.PizzaPriceSizeCalculator;

public class SmallPizzaSizePriceCalculator : IPizzaSizePriceCalculator
{
    public double CalculateSizeCost()
    {
        return 8;
    }
}