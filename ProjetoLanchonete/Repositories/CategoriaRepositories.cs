using ProjetoLanchonete.Context;
using ProjetoLanchonete.Models;
using ProjetoLanchonete.Repositories.Interfaces;

namespace ProjetoLanchonete.Repositories
{
    public class CategoriaRepositories : ICategoriaRepositories
    {
        private readonly AppDbContext _context;
        public CategoriaRepositories(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}   
