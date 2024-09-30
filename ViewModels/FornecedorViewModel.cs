using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiMvc.ViewModels
{
    public class FornecedorViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [RegularExpression(@"\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}", ErrorMessage = "CNPJ inválido")]
        public string Cnpj { get; set; } = null!;

        public int? DadosPessoaisId { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = null!;

        [Required]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; } = null!;
    }
}