using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PresentPizza.Domain.Models;

namespace PresentPizza.DataAccess.Repositories;

public class ToppingRepository
{
    private PresentPizzaContext _presentPizzaContext;

    public ToppingRepository(PresentPizzaContext presentPizzaContext)
    {
        _presentPizzaContext = presentPizzaContext;
    }

    public async Task<Topping?> GetAsync(string toppingName)
    {
        return await _presentPizzaContext.Toppings.FirstOrDefaultAsync(t =>
            t.Name.Equals(toppingName, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<List<Topping>> GetMany()
    {
        return await _presentPizzaContext.Toppings.ToListAsync();
    }
    
    public async Task CreateAsync(Topping topping)
    {
        await _presentPizzaContext.Toppings.AddAsync(topping);
        await _presentPizzaContext.SaveChangesAsync();
    }

}