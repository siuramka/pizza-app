namespace PresentPizza.Domain.Dtos;

public class PizzaOrderDto
{
    public int Id { get; set; }
    public double TotalCost { get; set; }
    public string Size { get; set; }
    public List<string> Toppings { get; set; }
}