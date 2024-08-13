using ProjetoLanchonete.Models;

namespace ProjetoLanchonete.ViewModels
{
    public class lancheIndexViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
