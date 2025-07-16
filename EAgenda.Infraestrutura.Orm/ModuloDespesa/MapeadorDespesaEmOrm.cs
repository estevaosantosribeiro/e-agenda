using EAgenda.Dominio.ModuloDespesa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAgenda.Infraestrutura.Orm.ModuloDespesa;

public class MapeadorDespesaEmOrm : IEntityTypeConfiguration<Despesa>
{
    public void Configure(EntityTypeBuilder<Despesa> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Descricao)
            .IsRequired();

        builder.Property(x => x.Valor)
            .IsRequired();

        builder.Property(x => x.DataOcorrencia)
            .IsRequired();

        builder.Property(x => x.FormaPagamento)
            .IsRequired();

        builder.HasMany(d => d.Categorias)
            .WithMany(c => c.Despesas);
    }
}
