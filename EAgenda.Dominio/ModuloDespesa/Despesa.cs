using EAgenda.Dominio.Compartilhado;
using EAgenda.Dominio.ModuloCategoria;

namespace EAgenda.Dominio.ModuloDespesa;

public class Despesa : EntidadeBase<Despesa>
{
    public string Descricao { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public int Valor { get; set; }
    public string FormaPagamento { get; set; }
    public List<Categoria> Categorias { get; set; }

    public Despesa() { }

    public Despesa(
        string descricao, 
        DateTime dataOcorrencia, 
        int valor, 
        string formaPagamento, 
        List<Categoria> categorias
    )
    {
        Id = Guid.NewGuid();
        Descricao = descricao;
        DataOcorrencia = dataOcorrencia;
        Valor = valor;
        FormaPagamento = formaPagamento;
        Categorias = categorias;
    }

    public override void AtualizarRegistro(Despesa registroEditado)
    {
        Descricao = registroEditado.Descricao;
        DataOcorrencia = registroEditado.DataOcorrencia;
        Valor = registroEditado.Valor;
        FormaPagamento = registroEditado.FormaPagamento;
        Categorias = registroEditado.Categorias;
    }
}
