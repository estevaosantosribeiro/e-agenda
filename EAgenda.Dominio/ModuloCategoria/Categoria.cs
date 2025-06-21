using EAgenda.Dominio.Compartilhado;
using EAgenda.Dominio.ModuloDespesa;

namespace EAgenda.Dominio.ModuloCategoria;

public class Categoria : EntidadeBase<Categoria>
{
    public string Titulo { get; set; }
    public List<Despesa> Despesas { get; set; } = new List<Despesa>();

    public Categoria() { }

    public Categoria(string titulo)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
    }

    public override void AtualizarRegistro(Categoria registroEditado)
    {
        Titulo = registroEditado.Titulo;
        Despesas = registroEditado.Despesas;
    }

    public void AdicionarDespesa(Despesa despesa)
    {
        if (Despesas == null)
            Despesas = new List<Despesa>();

        if (!Despesas.Any(d => d.Id == despesa.Id))
            Despesas.Add(despesa);
    }


    public void RemoverDespesa(Despesa despesa)
    {
        if (Despesas == null)
            return;

        Despesas.RemoveAll(d => d.Id == despesa.Id);
    }

}
