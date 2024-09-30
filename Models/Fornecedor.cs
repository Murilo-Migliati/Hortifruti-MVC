using System;
using System.Collections.Generic;

namespace HortifrutiMvc.Models;

public partial class Fornecedor
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public int? DadosPessoaisId { get; set; }

    public virtual DadosPessoais? DadosPessoais { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
