using System;
using System.Collections.Generic;

namespace HortifrutiMvc.Models;

public partial class Estoque
{
    public int Id { get; set; }

    public int ProdutoId { get; set; }

    public int Quantidade { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public virtual Produto Produto { get; set; } = null!;
}
