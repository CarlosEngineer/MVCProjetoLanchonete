using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLanchonete.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage ="O nome do lanche deve ser informado!")]
        [Display(Name ="Nome do lanche :) ")]
        [StringLength(80,MinimumLength =10,ErrorMessage ="O {0} deve ter no minimo {1} e o no maximo {2}. ")]
        public string Nome  { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado!")]
        [Display(Name = "Descrição do lanche :) ")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no minimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no maximo {1} caracteres.")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado!")]
        [Display(Name = "Descrição do lanche :) ")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no minimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no maximo {1} caracteres.")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage ="Informe o preço do lanche.")]
        [Display(Name ="Preço")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1,999.99,ErrorMessage ="O PREÇO DEVE ESTAR ENTRE 1 E 999.99")]
        public decimal Preco { get; set; }

        [Display(Name ="CAMINHO IMAGEM NORMAL ")]
        [StringLength(200,ErrorMessage ="O {0} deve ter no maximo {1} caracteres ")]
        public string ImagemUrl { get; set; }

        [Display(Name = "CAMINHO IMAGEM NORMAL ")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no maximo {1} caracteres ")]
        public string ImagemThumbNailUrl { get; set; }

        [Display(Name =" Quer colocar como favorito ? :) ")]
        public bool IsLanchePreferido { get; set; }
        [Display(Name ="Estoque")]
        public bool EmEstoque { get; set; }
        public int CategoriaId { get;set; }
        public virtual Categoria Categoria { get; set; }
    }
}
