using PresentPizza.Domain.Models;

namespace PresentPizza.DataAccess;

public class DataSeeder
{
    private PresentPizzaContext _presentPizzaContext;

    public DataSeeder(PresentPizzaContext presentPizzaContext)
    {
        _presentPizzaContext = presentPizzaContext;
    }

    public async Task SeedData()
    {
        _presentPizzaContext.Toppings.Add( new Topping { Id = 1, Name = "Cheese" });
        _presentPizzaContext.Toppings.Add( new Topping { Id = 2, Name = "Pepperoni" });
        _presentPizzaContext.Toppings.Add(  new Topping { Id = 3, Name = "Sausage" });
        _presentPizzaContext.Toppings.Add( new Topping { Id = 4, Name = "Questionable meat" });
        _presentPizzaContext.Toppings.Add( new Topping { Id = 5, Name = "Vegetarian soy meat" });
        _presentPizzaContext.Toppings.Add( new Topping { Id = 6, Name = "Tomatoes" });

        await _presentPizzaContext.SaveChangesAsync();
    }
}