using Escola.Alf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Alf.Infra.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            builder.Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("Data de Nascimento")
                .IsRequired();
        }
    }
}
