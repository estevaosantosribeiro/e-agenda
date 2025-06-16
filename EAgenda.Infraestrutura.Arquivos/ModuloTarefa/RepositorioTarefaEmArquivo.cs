using EAgenda.Dominio.ModuloTarefa;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;

namespace EAgenda.Infraestrutura.Arquivos.ModuloTarefa;

public class RepositorioTarefaEmArquivo : RepositorioBaseEmArquivo<Tarefa>
{
    public RepositorioTarefaEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Tarefa> ObterRegistros()
    {
        return contexto.Tarefas;
    }
}
