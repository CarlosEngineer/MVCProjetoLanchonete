using Microsoft.EntityFrameworkCore;
using ProjetoLanchonete.Context;

namespace ProjetoLanchonete.Models
{
	public class CarrinhoCompra
	{
        private readonly AppDbContext _context;
        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }
        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //Define uma sessao
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("carrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessao 
            session.SetString("carrinhoId", carrinhoId);

            //retorna o carrinho  com o contexto e o id atribuido ou embutido 
            return new CarrinhoCompra(context)

            {  
                CarrinhoCompraId =  carrinhoId
            };

        }


        public void AdicionarAoCarrinho(Lanche lanche) 
        {
            var CarrinhoCompraItem = _context.carrinhoCompraItems.SingleOrDefault(
                s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

            if (CarrinhoCompraItem == null) 
            {
                CarrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };

                _context.carrinhoCompraItems.Add(CarrinhoCompraItem);

            }

            else
            {
                CarrinhoCompraItem.Quantidade++;

            }

            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
			var CarrinhoCompraItem = _context.carrinhoCompraItems.SingleOrDefault(
			                s => s.Lanche.LancheId == lanche.LancheId &&
                            s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (CarrinhoCompraItem != null)
            {
				if (CarrinhoCompraItem.Quantidade > 1)
				{
					CarrinhoCompraItem.Quantidade--;
					quantidadeLocal = CarrinhoCompraItem.Quantidade;
				}
				else
				{
					_context.carrinhoCompraItems.Remove(CarrinhoCompraItem);
				}
			}
            _context.SaveChanges();
            return quantidadeLocal;

		}

        public List<CarrinhoCompraItem> GetCarrinhoCompraItems() 
        {
            return CarrinhoCompraItems ??
                (CarrinhoCompraItems =
                _context.carrinhoCompraItems
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
               .Include(s => s.Lanche)
               .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhosItens = _context.carrinhoCompraItems
                                            .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _context.carrinhoCompraItems.RemoveRange(carrinhosItens);
            _context.SaveChanges();

        }

        public decimal GetCarrinhoCompraTotal()
        {
            var Total = _context.carrinhoCompraItems
                        .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                        .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
            return Total;
        }
    }
}
