﻿using Ambev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ambev.Data.EntitiesConfig
{
    public class ItemVendaConfiguration : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.VendaId)
            .IsRequired();

            builder.Property(p => p.ProdutoId)
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(p => p.ValorUnitario)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(p => p.Desconto)
                .HasPrecision(10, 2);

            builder.HasOne(p => p.Venda)
            .WithMany(v => v.Itens) 
            .HasForeignKey(p => p.VendaId);
        }
    }
}
