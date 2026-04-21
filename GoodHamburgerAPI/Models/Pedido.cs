namespace GoodHamburgerAPI.Models;

public class Pedido
{
    public int Id { get; set; }
    public string Sanduiche { get; set; } = string.Empty;
    public bool TemBatata { get; set; }
    public bool TemRefrigerante { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Desconto { get; set; }
    public decimal Total { get; set; }
}
