using System;
using System.Collections.Generic;

namespace HortifrutiMvc.Models;

public partial class ItensVenda
{
    public int Id { get; set; }

    public int VendaId { get; set; }

    public int ProdutoId { get; set; }

    public int Quantidade { get; set; }

    public double Preco { get; set; }

    public virtual Produto Produto { get; set; } = null!;

    public virtual Venda Venda { get; set; } = null!;
}
