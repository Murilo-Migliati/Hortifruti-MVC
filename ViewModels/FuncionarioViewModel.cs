using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiMvc.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        public string? Cargo { get; set; }

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