namespace GoodHamburgerAPI.Services;

using global::GoodHamburgerAPI.DTOs;
using global::GoodHamburgerAPI.Models;

public class PedidoService
{
    public Pedido Criar(PedidoDTO dto)
    {
        decimal preco = dto.Sanduiche switch
        {
            "X Burger" => 5.0m,
            "X Egg" => 4.5m,
            "X Bacon" => 7.0m,
            _ => throw new Exception("Sanduíche inválido")
        };

        decimal subtotal = preco;

        if (dto.TemBatata) subtotal += 2.0m;
        if (dto.TemRefrigerante) subtotal += 2.5m;

        decimal desconto = 0;

        if (dto.TemBatata && dto.TemRefrigerante) desconto = 0.20m;
        else if (dto.TemRefrigerante) desconto = 0.15m;
        else if (dto.TemBatata) desconto = 0.10m;

        return new Pedido
        {
            Sanduiche = dto.Sanduiche,
            TemBatata = dto.TemBatata,
            TemRefrigerante = dto.TemRefrigerante,
            Subtotal = subtotal,
            Desconto = subtotal * desconto,
            Total = subtotal - (subtotal * desconto)
        };
    }
}
