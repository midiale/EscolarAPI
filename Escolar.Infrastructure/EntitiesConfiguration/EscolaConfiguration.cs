using Escolar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escolar.Infrastructure.EntitiesConfiguration
{
    public class EscolaConfiguration : IEntityTypeConfiguration<Escola>
    {
        public void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ImagemUrl).HasMaxLength(100).IsRequired();

            builder.HasData(
              new Escola(1, "Caminhos do Saber", "ccs.jpg"),
              new Escola(2, "Jean Piaget", "jp.jpg"),
              new Escola(3, "Cultura", "cult.jpg")
            );
        }
    }
}
