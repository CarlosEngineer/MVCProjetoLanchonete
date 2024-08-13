using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLanchonete.Migrations
{
    public partial class PreencherLanches : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Lanches (Nome, DescricaoCurta, DescricaoDetalhada,Preco, ImagemUrl, ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId)"
                + "Values ('NaturaLanche','Lanche leve e gostoso','salada tomate queijo natural molho natural', 6.50, '~/Image/3.jpg','~/Image/3.jpg',1,1,1 )");

            mb.Sql("Insert into Lanches (Nome, DescricaoCurta, DescricaoDetalhada,Preco, ImagemUrl, ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId)"
                + "Values ('BurguerHome','Lembre de sua casa com ele ','2 hamburgures tomate queijo molho especial bacon ovo picles', 10.50, 'https://images.app.goo.gl/1cpCdez38LxuNGG79','https://images.app.goo.gl/1cpCdez38LxuNGG79',1,1,2 )");

            mb.Sql("Insert into Lanches (Nome, DescricaoCurta, DescricaoDetalhada,Preco, ImagemUrl, ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId)"
                + "Values ('SweteDreams','lanche com 3 burguers', 'queijo prata bacon molho de iogurte peppers', 18.50, 'https://images.app.goo.gl/LCTCVAL6Zp4QZgKs9','https://images.app.goo.gl/LCTCVAL6Zp4QZgKs9',1,1,1 )");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Lanches ");
        }
    }
}
