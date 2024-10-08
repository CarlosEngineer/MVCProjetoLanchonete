﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLanchonete.Models
{

    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [StringLength(100,ErrorMessage ="O Tamanho maximo é de 100 caracteres :) ")]
        [Required(ErrorMessage ="Informe o nome da Categoria :)")]
        [Display(Name ="Nome")]
        public string Nome { get; set; }
        [StringLength(200, ErrorMessage = "O Tamanho maximo é de 200 caracteres :) ")]
        [Required(ErrorMessage = "Informe a descrição da Categoria :)")]
        [Display(Name = "Nome")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set;}
    }
}
