using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiMvc.ViewModels
{
    public class EstoqueViewModel
    {
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade deve ser maior ou igual a zero")]
        public int Quantidade { get; set; }

        [Required]
        public DateTime DataAtualizacao { get; set; }
    }
}