using GoodHamburgerAPI.Data;
using GoodHamburgerAPI.DTOs;
using GoodHamburgerAPI.Models;
using GoodHamburgerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburgerAPI.Controllers;

[ApiController]
[Route("api/pedidos")]
public class PedidosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly PedidoService _service;

    public PedidosController(AppDbContext context, PedidoService service)
    {
        _context = context;
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] PedidoDTO dto)
    {
        try
        {
            var pedido = _service.Criar(dto);

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscarPorId), new { id = pedido.Id }, pedido);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
        => Ok(await _context.Pedidos.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);

        if (pedido == null)
            return NotFound("Pedido não encontrado");

        return Ok(pedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] PedidoDTO dto)
    {
        var pedidoExistente = await _context.Pedidos.FindAsync(id);

        if (pedidoExistente == null)
            return NotFound("Pedido não encontrado");

        try
        {
            var atualizado = _service.Criar(dto);

            pedidoExistente.Sanduiche = atualizado.Sanduiche;
            pedidoExistente.TemBatata = atualizado.TemBatata;
            pedidoExistente.TemRefrigerante = atualizado.TemRefrigerante;
            pedidoExistente.Subtotal = atualizado.Subtotal;
            pedidoExistente.Desconto = atualizado.Desconto;
            pedidoExistente.Total = atualizado.Total;

            await _context.SaveChangesAsync();

            return Ok(pedidoExistente);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);

        if (pedido == null)
            return NotFound("Pedido não encontrado");

        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}