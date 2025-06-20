using EAgenda.Dominio.ModuloDespesa;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;

namespace EAgenda.Infraestrutura.Arquivos.ModuloDespesa;

public class RepositorioDespesaEmArquivo : RepositorioBaseEmArquivo<Despesa>, IRepositorioDespesa
{
    public RepositorioDespesaEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Despesa> ObterRegistros()
    {
        return contexto.Despesas;
    }
}
