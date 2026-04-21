using GoodHamburgerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburgerAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Pedido> Pedidos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}