using Microsoft.EntityFrameworkCore;
using ProjetoLanchonete.Models;

namespace ProjetoLanchonete.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {
            
        }

       public DbSet<Categoria> Categorias { get; set; }
       public DbSet<Lanche> Lanches { get; set; }
       public DbSet<CarrinhoCompraItem> carrinhoCompraItems { get; set; }
    }
}
