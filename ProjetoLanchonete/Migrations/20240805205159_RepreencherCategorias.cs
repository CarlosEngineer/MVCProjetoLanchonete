using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLanchonete.Migrations
{
    public partial class RepreencherCategorias : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert Into Categorias (Nome, Descricao)" + "Values ('Artesanal','Feito com ingredientes caseiros')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias ");
        }
    }
}
