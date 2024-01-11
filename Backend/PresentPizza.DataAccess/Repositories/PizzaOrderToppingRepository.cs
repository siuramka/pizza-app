using Microsoft.EntityFrameworkCore;
using PresentPizza.Domain.Models;

namespace PresentPizza.DataAccess.Repositories;

public class PizzaOrderToppingRepository
{
    private readonly PresentPizzaContext _context;

    public PizzaOrderToppingRepository(PresentPizzaContext context)
    {
        _context = context;
    }

    public async Task<List<PizzaOrderTopping>> GetManyAsync(int pizzaOrderId)
    {
        return await _context.PizzaOrderToppings.Where(pot => pot.PizzaOrderId == pizzaOrderId).ToListAsync();
    }
    public async Task CreateAsync(PizzaOrderTopping pizzaOrderTopping)
    {
        await _context.AddAsync(pizzaOrderTopping);
        await _context.SaveChangesAsync();
    }
}