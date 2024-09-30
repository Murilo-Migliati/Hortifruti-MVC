using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiMvc.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
        public double Preco { get; set; }

        public int? FornecedorId { get; set; }

        [Required]
        [StringLength(100)]
        public string FornecedorNome { get; set; } = null!;
    }
}