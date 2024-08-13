using Microsoft.AspNetCore.Mvc;
using ProjetoLanchonete.Models;
using ProjetoLanchonete.Repositories.Interfaces;
using ProjetoLanchonete.ViewModels;

namespace ProjetoLanchonete.Controllers
{
    public class LancheController : Controller
    {

        private readonly ILancheRepositories _LancheRepositories;

        public LancheController(ILancheRepositories lancheRepositories)
        {
            _LancheRepositories = lancheRepositories;
        }

        public IActionResult Index()    
        {
            //         ViewData["titulo"] = "Todos os Lanches ";
            //         ViewData["Data"] = DateTime.Now;

            //         var lanches = _LancheRepositories.Lanches ;

            //var totalLanches = lanches.Count();

            //         ViewBag.Total = "Total de Lanches:";
            //         ViewBag.TotalLanches = totalLanches;

            //return View(lanches);

            var lancheIndexViewModel = new lancheIndexViewModel();
            lancheIndexViewModel.Lanches = _LancheRepositories.Lanches;
            lancheIndexViewModel.CategoriaAtual = "Categoria Atual";

            return View (lancheIndexViewModel);
        }
    }
}
