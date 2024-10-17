using Ambev.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace b3digitas.Infra.Data.EntitiesConfiguration
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Data)
                .HasColumnType("timestamp without time zone");

            builder.Property(p => p.ClienteId)
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(p => p.Filial)
                .IsRequired();

            builder.Property(p => p.Cancelado)
                .IsRequired();

            builder.HasMany(p => p.Itens)
                .WithOne()
                .HasForeignKey("VendaId"); 


        }
    }
}
