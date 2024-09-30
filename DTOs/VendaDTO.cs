using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiMvc.DTOs
{
    public class VendaDTO
    {
        public int Id { get; set; }

        public int? ClienteId { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Total deve ser maior ou igual a zero")]
        public double Total { get; set; }
    }
}