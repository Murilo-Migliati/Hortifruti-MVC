using System;
using System.Collections.Generic;

namespace HortifrutiMvc.Models;

public partial class Funcionario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Cargo { get; set; }

    public int? DadosPessoaisId { get; set; }

    public virtual DadosPessoais? DadosPessoais { get; set; }
}
