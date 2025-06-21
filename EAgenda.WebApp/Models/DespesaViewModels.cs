using System.ComponentModel.DataAnnotations;
using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloDespesa;
using EAgenda.WebApp.Extensions;

namespace EAgenda.WebApp.Models;

public class FormularioDespesaViewModel
{
    [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo \"Descrição\" precisa conter ao menos 3 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo \"Descrição\" precisa conter no máximo 100 caracteres.")]
    public string Descricao { get; set; }
    public DateTime DataOcorrencia { get; set; }
    [Required(ErrorMessage = "O campo \"Valor\" é obrigatório.")]
    public int Valor { get; set; }
    [Required(ErrorMessage = "O campo \"Forma de Pagamento\" é obrigatório.")]
    public string FormaPagamento { get; set; }
    [Required(ErrorMessage = "O campo \"Categorias\" é obrigatório.")]
    public List<Guid> CategoriasSelecionadas { get; set; }
    public List<Categoria> CategoriasDisponiveis { get; set; }
}

public class CadastrarDespesaViewModel : FormularioDespesaViewModel
{
    public CadastrarDespesaViewModel() { }

    public CadastrarDespesaViewModel(
        string descricao,
        DateTime dataOcorrencia,
        int valor,
        string formaPagamento,
        List<Categoria> categoriasDisponiveis,
        List<Guid> categoriasSelecionadas
    ) : this()
    {
        Descricao = descricao;
        DataOcorrencia = dataOcorrencia;
        Valor = valor;
        FormaPagamento = formaPagamento;
        CategoriasDisponiveis = categoriasDisponiveis;
        CategoriasSelecionadas = categoriasSelecionadas;
    }
}

public class EditarDespesaViewModel : FormularioDespesaViewModel
{
    public Guid Id { get; set; }

    public EditarDespesaViewModel() { }

    public EditarDespesaViewModel(
        Guid id,
        string descricao,
        DateTime dataOcorrencia,
        int valor,
        string formaPagamento,
        List<Categoria> categoriasDisponiveis,
        List<Guid> categoriasSelecionadas
    )
    {
        Id = id;
        Descricao = descricao;
        DataOcorrencia = dataOcorrencia;
        Valor = valor;
        FormaPagamento = formaPagamento;
        CategoriasDisponiveis = categoriasDisponiveis;
        CategoriasSelecionadas = categoriasSelecionadas;
    }
}

public class ExcluirDespesaViewModel
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }

    public ExcluirDespesaViewModel() { }

    public ExcluirDespesaViewModel(Guid id, string descricao)
    {
        Id = id;
        Descricao = descricao;
    }
}

public class VisualizarDespesasViewModel
{
    public List<DetalhesDespesaViewModel> Registros { get; set; }

    public VisualizarDespesasViewModel(List<Despesa> despesas)
    {
        Registros = new List<DetalhesDespesaViewModel>();

        foreach (var d in despesas)
            Registros.Add(d.ParaDetalhesVM());
    }
}

public class DetalhesDespesaViewModel
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public int Valor { get; set; }
    public string FormaPagamento { get; set; }
    public List<Categoria> Categorias { get; set; }

    public DetalhesDespesaViewModel(
        Guid id, 
        string descricao, 
        DateTime dataOcorrencia, 
        int valor,
        string formaPagamento,
        List<Categoria> categorias
    )
    {
        Id = id;
        Descricao = descricao;
        DataOcorrencia = dataOcorrencia;
        Valor = valor;
        FormaPagamento = formaPagamento;
        Categorias = categorias;
    }
}
