namespace GoodHamburgerAPI.DTOs;

public class PedidoDTO
{
    public string Sanduiche { get; set; } = string.Empty;
    public bool TemBatata { get; set; }
    public bool TemRefrigerante { get; set; }
}