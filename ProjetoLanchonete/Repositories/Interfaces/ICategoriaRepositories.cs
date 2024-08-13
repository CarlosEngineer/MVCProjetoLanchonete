using ProjetoLanchonete.Models;

namespace ProjetoLanchonete.Repositories.Interfaces
{
    public interface ICategoriaRepositories
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
