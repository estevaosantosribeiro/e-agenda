using EAgenda.Dominio.Compartilhado;

namespace EAgenda.Dominio.ModuloTarefa;

public class ItemTarefa : EntidadeBase<ItemTarefa>
{
    public string Titulo { get; set; }
    public bool EstaConcluida { get; set; }
    public Tarefa Tarefa { get; set; }

    public override void AtualizarRegistro(ItemTarefa registroEditado)
    {
        throw new NotImplementedException();
    }
}
