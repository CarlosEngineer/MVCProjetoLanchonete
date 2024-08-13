using Microsoft.EntityFrameworkCore;
using ProjetoLanchonete.Context;
using ProjetoLanchonete.Models;
using ProjetoLanchonete.Repositories.Interfaces;

namespace ProjetoLanchonete.Repositories
{
    public class LancheRepositories : ILancheRepositories
    {
        private readonly AppDbContext _context;

        public LancheRepositories(AppDbContext contexto)
        {
            _context = contexto;
        }   
    
        IEnumerable<Lanche> ILancheRepositories.Lanches => _context.Lanches.Include(l => l.Categoria);

        IEnumerable<Lanche> ILancheRepositories.LanchesPreferido => _context.Lanches.
                            Where(f => f.IsLanchePreferido).Include(l => l.Categoria);

        Lanche ILancheRepositories.GetLancheById(int LancheId)
        {
           return _context.Lanches.FirstOrDefault(i => i.LancheId == LancheId);
        }
    }
}
