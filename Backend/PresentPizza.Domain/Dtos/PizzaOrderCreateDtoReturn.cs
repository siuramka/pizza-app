namespace PresentPizza.Domain.Dtos;

public class PizzaOrderCreateDtoReturn
{
    public int Id { get; set; }
    public string Size { get; set; } = "";
    public double TotalCost { get; set; }
}