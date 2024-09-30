using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HortifrutiMvc.Models;

namespace HortifrutiMvc.Data
{
    public partial class HortifrutiMvcContext : DbContext
    {
        public HortifrutiMvcContext()
        {
        }

        public HortifrutiMvcContext(DbContextOptions<HortifrutiMvcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<DadosPessoais> DadosPessoais { get; set; }

        public virtual DbSet<Estoque> Estoques { get; set; }

        public virtual DbSet<Fornecedor> Fornecedors { get; set; }

        public virtual DbSet<Funcionario> Funcionarios { get; set; }

        public virtual DbSet<ItensVenda> ItensVenda { get; set; }

        public virtual DbSet<Produto> Produtos { get; set; }

        public virtual DbSet<Venda> Venda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=E:\\Data\\HortifrutiMvc.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Cpf, "IX_Cliente_CPF").IsUnique();

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.HasOne(d => d.DadosPessoais).WithMany(p => p.Clientes).HasForeignKey(d => d.DadosPessoaisId);
            });

            modelBuilder.Entity<DadosPessoais>(entity =>
            {
                entity.HasIndex(e => e.Email, "IX_DadosPessoaiss_Email").IsUnique();
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.ToTable("Estoque");

                entity.HasIndex(e => e.ProdutoId, "idx_estoque_produtoid");

                entity.Property(e => e.DataAtualizacao).HasColumnType("DATE");

                entity.HasOne(d => d.Produto).WithMany(p => p.Estoques)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.ToTable("Fornecedor");

                entity.HasIndex(e => e.Cnpj, "IX_Fornecedor_CNPJ").IsUnique();

                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

                entity.HasOne(d => d.DadosPessoais).WithMany(p => p.Fornecedors).HasForeignKey(d => d.DadosPessoaisId);
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("Funcionario");

                entity.HasOne(d => d.DadosPessoais).WithMany(p => p.Funcionarios).HasForeignKey(d => d.DadosPessoaisId);
            });

            modelBuilder.Entity<ItensVenda>(entity =>
            {
                entity.HasIndex(e => e.ProdutoId, "idx_itensvenda_produtoid");

                entity.HasIndex(e => e.VendaId, "idx_itensvenda_vendaid");

                entity.HasOne(d => d.Produto).WithMany(p => p.ItensVenda)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Venda).WithMany(p => p.ItensVenda)
                    .HasForeignKey(d => d.VendaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.HasIndex(e => new { e.Nome, e.FornecedorId }, "IX_Produto_Nome_FornecedorId").IsUnique();

                entity.HasOne(d => d.Fornecedor).WithMany(p => p.Produtos).HasForeignKey(d => d.FornecedorId);
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("DATE");

                entity.HasOne(d => d.Cliente).WithMany(p => p.Venda).HasForeignKey(d => d.ClienteId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
