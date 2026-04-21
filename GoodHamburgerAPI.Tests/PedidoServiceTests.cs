using GoodHamburgerAPI.DTOs;
using GoodHamburgerAPI.Services;
using Xunit;

public class PedidoServiceTests
{
    private readonly PedidoService _service = new();

    [Fact]
    public void Deve_Aplicar_20_Porcento_Quando_Tem_Tudo()
    {
        var dto = new PedidoDTO
        {
            Sanduiche = "X Burger",
            TemBatata = true,
            TemRefrigerante = true
        };

        var pedido = _service.Criar(dto);

        Assert.True(pedido.Desconto > 0);
        Assert.Equal(0.2m, pedido.Desconto);
    }

    [Fact]
    public void Deve_Aplicar_15_Porcento_Sanduiche_E_Refrigerante()
    {
        var dto = new PedidoDTO
        {
            Sanduiche = "X Egg",
            TemBatata = false,
            TemRefrigerante = true
        };

        var pedido = _service.Criar(dto);

        Assert.Equal(0.15m, pedido.Desconto);
    }

    [Fact]
    public void Deve_Aplicar_10_Porcento_Sanduiche_E_Batata()
    {
        var dto = new PedidoDTO
        {
            Sanduiche = "X Bacon",
            TemBatata = true,
            TemRefrigerante = false
        };

        var pedido = _service.Criar(dto);

        Assert.Equal(0.10m, pedido.Desconto);
    }

    [Fact]
    public void Nao_Deve_Permitir_Sanduiche_Invalido()
    {
        var dto = new PedidoDTO
        {
            Sanduiche = "X Tudo",
            TemBatata = true,
            TemRefrigerante = true
        };

        Assert.Throws<Exception>(() => _service.Criar(dto));
    }
}