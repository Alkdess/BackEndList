using Microsoft.EntityFrameworkCore;
//using Listado.API.Models;

namespace Listado.API.Models{
  public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<Personas> Personas {get; set;}
  }
}