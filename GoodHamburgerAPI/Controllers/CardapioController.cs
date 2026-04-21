using Microsoft.AspNetCore.Mvc;

namespace GoodHamburgerAPI.Controllers;

[ApiController]
[Route("api/cardapio")]
public class CardapioController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Sanduiches = new[]
            {
                new { Nome = "X Burger", Preco = 5.0 },
                new { Nome = "X Egg", Preco = 4.5 },
                new { Nome = "X Bacon", Preco = 7.0 }
            },
            Acompanhamentos = new
            {
                Batata = 2.0,
                Refrigerante = 2.5
            }
        });
    }
}