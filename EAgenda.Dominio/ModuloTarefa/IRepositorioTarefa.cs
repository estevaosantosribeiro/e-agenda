using EAgenda.Dominio.Compartilhado;

namespace EAgenda.Dominio.ModuloTarefa;

public interface IRepositorioTarefa : IRepositorio<Tarefa>
{ 
    List<Tarefa> SelecionarTarefasPendentes();
    List<Tarefa> SelecionarTarefasConcluidas();
    List<Tarefa> SelecionarTarefasPorPrioridade();
}
