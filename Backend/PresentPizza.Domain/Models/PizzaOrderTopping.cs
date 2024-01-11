﻿namespace PresentPizza.Domain.Models;

public class PizzaOrderTopping
{
    public int PizzaOrderId { get; set; }
    public PizzaOrder PizzaOrder { get; set; }
    
    public int ToppingId { get; set; } 
    public Topping Topping { get; set; }
}