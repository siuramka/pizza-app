using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PresentPizza.Domain.Models;

namespace PresentPizza.DataAccess;

public class PresentPizzaContext : DbContext
{
    public PresentPizzaContext(DbContextOptions<PresentPizzaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PizzaOrderTopping>()
            .HasKey(pt => new { pt.PizzaOrderId, pt.ToppingId });

        modelBuilder.Entity<PizzaOrder>()
            .Property(p => p.PizzaSize)
            .HasConversion<string>();
    }

    public DbSet<PizzaOrder> Pizzas { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<PizzaOrderTopping> PizzaOrderToppings { get; set; }
}