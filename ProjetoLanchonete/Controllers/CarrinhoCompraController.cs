using Microsoft.AspNetCore.Mvc;
using ProjetoLanchonete.Models;
using ProjetoLanchonete.Repositories.Interfaces;
using ProjetoLanchonete.ViewModels;

namespace ProjetoLanchonete.Controllers
{
	public class CarrinhoCompraController : Controller
	{
		private readonly ILancheRepositories _lancheRepositories;
		private readonly CarrinhoCompra _CarrinhoCompra;

        public CarrinhoCompraController(ILancheRepositories lancheRepositories, CarrinhoCompra carrinhoCompra)
        {
			_lancheRepositories = lancheRepositories;
			_CarrinhoCompra = carrinhoCompra;

		}
        public IActionResult Index()
		{
			var itens = _CarrinhoCompra.GetCarrinhoCompraItems();
			_CarrinhoCompra.CarrinhoCompraItems = itens;

			var carrinhoCompraVM = new CarrinhoCompraViewModel
			{
				CarrinhoCompra = _CarrinhoCompra,
				CarrinhoCompraTotal = _CarrinhoCompra.GetCarrinhoCompraTotal()
			};


			return View(carrinhoCompraVM);
		}

		public IActionResult AdicionarItemNoCarrinho(int lancheId) 
		{
			var lancheSelecionado = _lancheRepositories.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

			if(lancheSelecionado != null)
			{
				_CarrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);

			}

						return RedirectToAction("Index");
					}

		public RedirectToActionResult RemoverItemNoCarrinho(int lancheId)
		{
			var lancheSelecionado = _lancheRepositories.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

			if (lancheSelecionado != null)
			{
				_CarrinhoCompra.RemoverDoCarrinho(lancheSelecionado);

			}

			return RedirectToAction("Index");
		}
	}
}
