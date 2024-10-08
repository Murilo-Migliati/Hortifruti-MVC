﻿// <auto-generated />
using System;
using HortifrutiMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HortifrutiMvc.Data.Migrations
{
    [DbContext(typeof(HortifrutiMvcContext))]
    [Migration("20240926200727_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("HortifrutiMvc.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("CPF");

                    b.Property<int?>("DadosPessoaisId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DadosPessoaisId");

                    b.HasIndex(new[] { "Cpf" }, "IX_Cliente_CPF")
                        .IsUnique();

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("HortifrutiMvc.Models.DadosPessoais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_DadosPessoaiss_Email")
                        .IsUnique();

                    b.ToTable("DadosPessoais");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("DATE");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProdutoId" }, "idx_estoque_produtoid");

                    b.ToTable("Estoque", (string)null);
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("CNPJ");

                    b.Property<int?>("DadosPessoaisId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DadosPessoaisId");

                    b.HasIndex(new[] { "Cnpj" }, "IX_Fornecedor_CNPJ")
                        .IsUnique();

                    b.ToTable("Fornecedor", (string)null);
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DadosPessoaisId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DadosPessoaisId");

                    b.ToTable("Funcionario", (string)null);
                });

            modelBuilder.Entity("HortifrutiMvc.Models.ItensVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Preco")
                        .HasColumnType("REAL");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VendaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProdutoId" }, "idx_itensvenda_produtoid");

                    b.HasIndex(new[] { "VendaId" }, "idx_itensvenda_vendaid");

                    b.ToTable("ItensVenda");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FornecedorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Preco")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex(new[] { "Nome", "FornecedorId" }, "IX_Produto_Nome_FornecedorId")
                        .IsUnique();

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("DATE");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Cliente", b =>
                {
                    b.HasOne("HortifrutiMvc.Models.DadosPessoais", "DadosPessoais")
                        .WithMany("Clientes")
                        .HasForeignKey("DadosPessoaisId");

                    b.Navigation("DadosPessoais");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Estoque", b =>
                {
                    b.HasOne("HortifrutiMvc.Models.Produto", "Produto")
                        .WithMany("Estoques")
                        .HasForeignKey("ProdutoId")
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Fornecedor", b =>
                {
                    b.HasOne("HortifrutiMvc.Models.DadosPessoais", "DadosPessoais")
                        .WithMany("Fornecedors")
                        .HasForeignKey("DadosPessoaisId");

                    b.Navigation("DadosPessoais");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Funcionario", b =>
                {
                    b.HasOne("HortifrutiMvc.Models.DadosPessoais", "DadosPessoais")
                        .WithMany("Funcionarios")
                        .HasForeignKey("DadosPessoaisId");

                    b.Navigation("DadosPessoais");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.ItensVenda", b =>
                {
                    b.HasOne("HortifrutiMvc.Models.Produto", "Produto")
                        .WithMany("ItensVenda")
                        .HasForeignKey("ProdutoId")
                        .IsRequired();

                    b.HasOne("HortifrutiMvc.Models.Venda", "Venda")
                        .WithMany("ItensVenda")
                        .HasForeignKey("VendaId")
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Produto", b =>
                {
                    b.HasOne("HortifrutiMvc.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Venda", b =>
                {
                    b.HasOne("HortifrutiMvc.Models.Cliente", "Cliente")
                        .WithMany("Venda")
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Cliente", b =>
                {
                    b.Navigation("Venda");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.DadosPessoais", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Fornecedors");

                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Fornecedor", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Produto", b =>
                {
                    b.Navigation("Estoques");

                    b.Navigation("ItensVenda");
                });

            modelBuilder.Entity("HortifrutiMvc.Models.Venda", b =>
                {
                    b.Navigation("ItensVenda");
                });
#pragma warning restore 612, 618
        }
    }
}
