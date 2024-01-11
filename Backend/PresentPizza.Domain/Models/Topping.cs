namespace PresentPizza.Domain.Models;

public class Topping
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    
    public List<PizzaOrderTopping> PizzaOrderToppings { get; set; } = new();

}