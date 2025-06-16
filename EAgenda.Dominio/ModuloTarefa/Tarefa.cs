using EAgenda.Dominio.Compartilhado;

namespace EAgenda.Dominio.ModuloTarefa;

public class Tarefa : EntidadeBase<Tarefa>
{
    public string Titulo { get; set; }
    public Prioridade Prioridade { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }
    public bool EstaConcluida { get; set; }
    public List<ItemTarefa> ItensTarefas { get; set; }
    public decimal PercentualConcluido { get 
        {
            if (ItensTarefas == null || ItensTarefas.Count == 0)
                return 0;

            int concluidos = 0;

            foreach (var item in ItensTarefas)
            {
                if (item.EstaConcluida)
                    concluidos++;
            }

            decimal total = ItensTarefas.Count;
            decimal concluido = concluidos;

            return (concluido / total) * 100;
        } 
    }
    
    public Tarefa() { }

    public Tarefa(
        string titulo, 
        Prioridade prioridade, 
        DateTime dataCriacao) : this()
    {
        Titulo = titulo;
        Prioridade = prioridade;
        DataCriacao = dataCriacao;
        EstaConcluida = false;
    }
    
    public void Concluir()
    {
        EstaConcluida = true;
        DataConclusao = DateTime.Now;
    }

    public override void AtualizarRegistro(Tarefa registroEditado)
    {
        Titulo = registroEditado.Titulo;
        Prioridade = registroEditado.Prioridade;
        DataCriacao = registroEditado.DataCriacao;
    }
}
