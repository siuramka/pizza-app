using Microsoft.AspNetCore.Mvc;
using PresentPizza.DataAccess.Repositories;
using PresentPizza.Domain.Dtos.Toppings;

namespace PresentPizza.API.Controllers;

[ApiController]
[Route("/api/toppings")]
public class ToppingsController : ControllerBase
{
    private ToppingRepository _toppingRepository;

    public ToppingsController(ToppingRepository toppingRepository)
    {
        _toppingRepository = toppingRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allToppings = await _toppingRepository.GetMany();

        return Ok(allToppings.Select(t => new ToppingDto { Id = t.Id, Name = t.Name }));
    }
}