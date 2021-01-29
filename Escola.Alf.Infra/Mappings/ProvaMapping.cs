using Escola.Alf.Domain.ComplexType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Alf.Infra.Mappings
{
    public class ProvaMapping : IEntityTypeConfiguration<Prova>
    {
        public void Configure(EntityTypeBuilder<Prova> builder)
        {
            builder.ToTable("Provas");

            builder.Property(p => p.Nota)
                .IsRequired();

            builder.Property(p => p.Questoes)
                .IsRequired();
        }
    }
}
