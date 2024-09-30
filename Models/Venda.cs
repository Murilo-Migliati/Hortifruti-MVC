using System;
using System.Collections.Generic;

namespace HortifrutiMvc.Models;

public partial class Venda
{
    public int Id { get; set; }

    public int? ClienteId { get; set; }

    public DateTime Data { get; set; }

    public double Total { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<ItensVenda> ItensVenda { get; set; } = new List<ItensVenda>();
}
