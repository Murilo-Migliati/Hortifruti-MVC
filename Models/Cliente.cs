using System;
using System.Collections.Generic;

namespace HortifrutiMvc.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public int? DadosPessoaisId { get; set; }

    public virtual DadosPessoais? DadosPessoais { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
