using Microsoft.EntityFrameworkCore;
using PresentPizza.Domain.Models;

namespace PresentPizza.DataAccess.Repositories;

public class PizzaOrderRepository
{
    private PresentPizzaContext _presentPizzaContext;

    public PizzaOrderRepository(PresentPizzaContext presentPizzaContext)
    {
        _presentPizzaContext = presentPizzaContext;
    }

    public async Task<List<PizzaOrder>> GetManyAsync()
    {
        return await _presentPizzaContext.Pizzas.Include(po => po.PizzaOrderToppings)
            .ThenInclude(pot => pot.Topping)
            .ToListAsync();
    }

    public async Task CreateAsync(PizzaOrder pizzaOrder)
    {
        await _presentPizzaContext.AddAsync(pizzaOrder);
        await _presentPizzaContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PizzaOrder pizzaOrder)
    {
        _presentPizzaContext.Update(pizzaOrder);
        await _presentPizzaContext.SaveChangesAsync();
    }
}