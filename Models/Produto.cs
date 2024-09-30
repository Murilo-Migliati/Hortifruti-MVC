using System;
using System.Collections.Generic;

namespace HortifrutiMvc.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public double Preco { get; set; }

    public int? FornecedorId { get; set; }

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual Fornecedor? Fornecedor { get; set; }

    public virtual ICollection<ItensVenda> ItensVenda { get; set; } = new List<ItensVenda>();
}
