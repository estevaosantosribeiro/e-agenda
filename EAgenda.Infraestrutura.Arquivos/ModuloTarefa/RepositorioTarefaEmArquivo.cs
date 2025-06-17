using EAgenda.Dominio.ModuloTarefa;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;

namespace EAgenda.Infraestrutura.Arquivos.ModuloTarefa;

public class RepositorioTarefaEmArquivo : RepositorioBaseEmArquivo<Tarefa>, IRepositorioTarefa
{
    public RepositorioTarefaEmArquivo(ContextoDados contexto) : base(contexto) { }

    public List<Tarefa> SelecionarTarefasConcluidas()
    {
        var tarefasConcluidas = new List<Tarefa>();

        foreach (var i in registros)
            if (i.EstaConcluida) tarefasConcluidas.Add(i);

        return tarefasConcluidas;
    }

    public List<Tarefa> SelecionarTarefasPendentes()
    {
        var tarefasPendentes = new List<Tarefa>();
        
        foreach (var i in registros)
            if (!i.EstaConcluida) tarefasPendentes.Add(i);

        return tarefasPendentes;
    }

    public List<Tarefa> SelecionarTarefasPorPrioridade()
    {
        var tarefasPorPrioridade = registros;

        tarefasPorPrioridade.Sort(CompararTarefasPorPrioridade);

        return tarefasPorPrioridade;
    }

    private int CompararTarefasPorPrioridade(Tarefa tarefa1, Tarefa tarefa2)
    {
        return tarefa2.Prioridade.CompareTo(tarefa1.Prioridade);
    }

    protected override List<Tarefa> ObterRegistros()
    {
        return contexto.Tarefas;
    }
}
