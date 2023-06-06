using Escolar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escolar.Infrastructure.EntitiesConfiguration
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Mae).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Serie);
            builder.Property(p => p.ImagemUrl).HasMaxLength(250);
            builder.Property(p => p.ExAluno);
            
            builder.HasOne(e => e.Escola).WithMany(e => e.Alunos)
                .HasForeignKey(e => e.EscolaId);
            
        }
    }
}
