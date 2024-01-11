using Microsoft.AspNetCore.Mvc;
using PresentPizza.Business.Services;
using PresentPizza.DataAccess.Repositories;
using PresentPizza.Domain.Dtos;
using PresentPizza.Domain.Models;

namespace PresentPizza.API.Controllers;

[ApiController]
[Route("/api/pizzas/orders")]
public class PizzaOrderController : ControllerBase
{
    private ToppingRepository _toppingRepository;
    private PizzaOrderRepository _pizzaOrderRepository;
    private PizzaOrderToppingRepository _pizzaOrderToppingRepository;
    private PizzaOrderService _pizzaOrderService;

    public PizzaOrderController(ToppingRepository toppingRepository, PizzaOrderRepository pizzaOrderRepository,
        PizzaOrderToppingRepository pizzaOrderToppingRepository, PizzaOrderService pizzaOrderService)
    {
        _toppingRepository = toppingRepository;
        _pizzaOrderRepository = pizzaOrderRepository;
        _pizzaOrderToppingRepository = pizzaOrderToppingRepository;
        _pizzaOrderService = pizzaOrderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pizzaOrdersWithToppings = await _pizzaOrderRepository.GetManyAsync();

        return Ok(pizzaOrdersWithToppings.Select(powt => new PizzaOrderDto
        {
            Id = powt.Id, Size = powt.PizzaSize.ToString(), TotalCost = powt.TotalCost,
            Toppings = powt.PizzaOrderToppings.Select(pot => pot.Topping.Name).ToList()
        }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(PizzaOrderCreateDto pizzaOrderCreateDto)
    {
        var isParsed = Enum.TryParse(pizzaOrderCreateDto.Size, true, out PizzaSize pizzaSize);

        if (!isParsed || pizzaOrderCreateDto.Toppings.Count == 0)
        {
            return BadRequest();
        }

        var pizzaOrder = new PizzaOrder { PizzaSize = pizzaSize };
        await _pizzaOrderRepository.CreateAsync(pizzaOrder);

        foreach (var toppingNames in pizzaOrderCreateDto.Toppings)
        {
            var existingTopping = await _toppingRepository.GetAsync(toppingNames);

            if (existingTopping == null)
                continue;

            await _pizzaOrderToppingRepository.CreateAsync(new PizzaOrderTopping
                { PizzaOrderId = pizzaOrder.Id, ToppingId = existingTopping.Id });
        }

        var pizzaOrderCost = _pizzaOrderService.CalculatePizzaCost(pizzaOrder);

        pizzaOrder.TotalCost = pizzaOrderCost;

        await _pizzaOrderRepository.UpdateAsync(pizzaOrder); //update pizza order cost

        return CreatedAtAction(nameof(Create), new PizzaOrderCreateDtoReturn
        {
            Id = pizzaOrder.Id, Size = pizzaOrder.PizzaSize.ToString(), TotalCost = pizzaOrder.TotalCost
        });
    }
}