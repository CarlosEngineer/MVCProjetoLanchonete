using ProjetoLanchonete.Models;

namespace ProjetoLanchonete.Repositories.Interfaces
{
    public interface ILancheRepositories
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferido { get; }
        Lanche GetLancheById(int LancheId);
            

    }
}
