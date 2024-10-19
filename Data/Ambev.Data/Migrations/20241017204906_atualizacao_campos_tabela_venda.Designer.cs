﻿// <auto-generated />
using System;
using Ambev.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ambev.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241017204906_atualizacao_campos_tabela_venda")]
    partial class atualizacao_campos_tabela_venda
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ambev.Domain.Entities.ItemVenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<decimal>("Desconto")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "desconto");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uuid")
                        .HasAnnotation("Relational:JsonPropertyName", "produtoid");

                    b.Property<decimal>("Quantidade")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "quantidade");

                    b.Property<decimal>("ValorUnitario")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "valorunitario");

                    b.Property<Guid>("VendaId")
                        .HasColumnType("uuid")
                        .HasAnnotation("Relational:JsonPropertyName", "vendaid");

                    b.HasKey("Id");

                    b.HasIndex("VendaId");

                    b.ToTable("ItensVenda");

                    b.HasAnnotation("Relational:JsonPropertyName", "itens");
                });

            modelBuilder.Entity("Ambev.Domain.Entities.Venda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<bool>("Cancelado")
                        .HasColumnType("boolean")
                        .HasAnnotation("Relational:JsonPropertyName", "cancelado");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uuid")
                        .HasAnnotation("Relational:JsonPropertyName", "clienteid");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("Relational:JsonPropertyName", "dataatualizacao");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("Relational:JsonPropertyName", "datacadastro");

                    b.Property<Guid>("Filial")
                        .HasColumnType("uuid")
                        .HasAnnotation("Relational:JsonPropertyName", "filial");

                    b.Property<bool>("Finalizada")
                        .HasColumnType("boolean")
                        .HasAnnotation("Relational:JsonPropertyName", "finalizada");

                    b.Property<decimal>("ValorTotal")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "valortotal");

                    b.HasKey("Id");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("Ambev.Domain.Entities.ItemVenda", b =>
                {
                    b.HasOne("Ambev.Domain.Entities.Venda", "Venda")
                        .WithMany("Itens")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("Ambev.Domain.Entities.Venda", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
