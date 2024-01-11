using PresentPizza.Domain.Models;

namespace PresentPizza.Domain.Dtos;

public class PizzaOrderCreateDto
{
    public string Size { get; set; } = "";
    public List<string> Toppings { get; set; } = new List<string>();
    
}