using EAgenda.Dominio.Compartilhado;

namespace EAgenda.Dominio.ModuloCategoria;

public class Categoria : EntidadeBase<Categoria>
{
    public string Titulo { get; set; }
    public string Despesas { get; set; }

    public Categoria() { }

    public Categoria(string titulo, string despesas)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Despesas = despesas;
    }

    public override void AtualizarRegistro(Categoria registroEditado)
    {
        Titulo = registroEditado.Titulo;
        Despesas = registroEditado.Despesas;
    }
}
