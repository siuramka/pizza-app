using System.Text.Json.Serialization;
using PresentPizza.Domain.Dtos;

namespace PresentPizza.Domain.Models;

public class PizzaOrder
{
    public int Id { get; set; }
    public PizzaSize PizzaSize { get; set; }
    public List<PizzaOrderTopping> PizzaOrderToppings { get; set; } = new();
    public double TotalCost { get; set; }
}