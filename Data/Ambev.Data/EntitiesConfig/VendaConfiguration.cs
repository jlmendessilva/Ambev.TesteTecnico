using Ambev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace b3digitas.Infra.Data.EntitiesConfiguration
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Numero)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("timestamp without time zone");

            builder.Property(p => p.DataAtualizacao)
                .HasColumnType("timestamp without time zone");

            builder.Property(p => p.ClienteId)
                .IsRequired();

            builder.Property(p => p.Filial)
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .HasPrecision(10, 2);

        }
    }
}
