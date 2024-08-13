using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLanchonete.Migrations
{
    public partial class PreencherCategorias : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert Into Categorias (Nome, Descricao)" + "Values ('Natural','Feito com ingredientes naturais')");
           
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias "); 
        }
    }
}
