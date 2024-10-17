using Ambev.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ambev.Data.EntitiesConfig
{
    public class ItemVendaConfiguration : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(i => i.VendaId)
            .IsRequired();

            builder.Property(p => p.ProdutoId)
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .IsRequired();

            builder.Property(p => p.ValorUnitario)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(p => p.Desconto)
                .HasPrecision(10, 2);

            builder.HasOne(i => i.Venda)
            .WithMany() 
            .HasForeignKey(i => i.VendaId);
        }
    }
}
