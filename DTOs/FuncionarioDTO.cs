using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiMvc.DTOs
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        public string? Cargo { get; set; }

        public int? DadosPessoaisId { get; set; }
    }
}