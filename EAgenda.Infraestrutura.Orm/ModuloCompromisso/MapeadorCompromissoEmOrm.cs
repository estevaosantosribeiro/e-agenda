using EAgenda.Dominio.Modulo_Compromissos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAgenda.Infraestrutura.Orm.ModuloCompromisso;

public class MapeadorCompromissoEmOrm : IEntityTypeConfiguration<Compromisso>
{
    public void Configure(EntityTypeBuilder<Compromisso> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Assunto)
            .IsRequired();

        builder.Property(x => x.DataDeOcorrencia)
            .IsRequired();

        builder.Property(x => x.HoraDeInicio)
            .IsRequired();

        builder.Property(x => x.HoraDeTermino)
            .IsRequired();

        builder.Property(x => x.TipoDeCompromisso)
            .IsRequired();

        builder.Property(x => x.Local)
            .IsRequired(false);

        builder.Property(x => x.Link)
            .IsRequired(false);

        builder.HasOne(cmp => cmp.Contato)
            .WithMany(ct => ct.Compromissos);
    }
}
