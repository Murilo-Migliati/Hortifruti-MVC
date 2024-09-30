using System;
using System.Collections.Generic;

namespace HortifrutiMvc.Models;
public partial class DadosPessoais
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Fornecedor> Fornecedors { get; set; } = new List<Fornecedor>();

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}
