using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiMvc.ViewModels
{
    public class ItensVendaViewModel
    {
        public int Id { get; set; }

        [Required]
        public int VendaId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Preço deve ser maior ou igual a zero")]
        public double Preco { get; set; }
    }
}