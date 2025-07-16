using EAgenda.Dominio.ModuloContato;
using EAgenda.Dominio.Modulo_Compromissos;
using System.ComponentModel.DataAnnotations;
using EAgenda.WebApp.Extensions;

namespace EAgenda.WebApp.Models;

public class FormularioCompromissoViewModel
{
    [Required(ErrorMessage = "O campo \"Assunto\" é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo deve conter ao menos 3 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo deve conter no máximo 100 caracteres.")]
    public string Assunto { get; set; }

    [Required(ErrorMessage = "O campo \"Data de ocorrência\" é obrigatório.")]
    public DateOnly DataDeOcorrencia { get; set; }

    [Required(ErrorMessage = "O campo \"Hora de início\" é obrigatório.")]
    public TimeSpan HoraDeInicio { get; set; } = TimeSpan.Parse("15:00");

    [Required(ErrorMessage = "O campo \"Hora de término\" é obrigatório.")]
    public TimeSpan HoraDeTermino { get; set; }

    [Required(ErrorMessage = "O campo \"Tipo de compromisso\" é obrigatório.")]
    public string TipoDeCompromisso { get; set; }

    public string? Local { get; set; }

    public string Link { get; set; }

    public Guid? ContatoId { get; set; }

    public Contato? Contato { get; set; }

    public List<Contato> Contatos { get; set; } = new();
}

public class CadastrarCompromissoViewModel : FormularioCompromissoViewModel
{
    public CadastrarCompromissoViewModel() { }

    public CadastrarCompromissoViewModel(
        string assunto,
        DateOnly dataDeOcorrencia,
        TimeSpan horaDeInicio,
        TimeSpan horaDeTermino,
        string tipoDeCompromisso,
        string local,
        string link,
        Guid contatoId,
        List<Contato> contatos) : this()
    {
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeInicio;
        HoraDeTermino = horaDeTermino;
        TipoDeCompromisso = tipoDeCompromisso;
        Local = local;
        Link = link;
        ContatoId = contatoId;
        Contatos = contatos ?? new();
    }
}

public class EditarCompromissoViewModel : FormularioCompromissoViewModel
{
    public Guid Id { get; set; }

    public EditarCompromissoViewModel() { }

    public EditarCompromissoViewModel(
        Guid id,
        string assunto,
        DateOnly dataDeOcorrencia,
        TimeSpan horaDeInicio,
        TimeSpan horaDeTermino,
        string tipoDeCompromisso,
        string local,
        string link,
        Guid contatoId,
        List<Contato> contatos) : this()
    {
        Id = id;
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeInicio;
        HoraDeTermino = horaDeTermino;
        TipoDeCompromisso = tipoDeCompromisso;
        Local = local;
        Link = link;
        ContatoId = contatoId;
        Contatos = contatos ?? new();
    }

    public Compromisso ParaEntidade()
    {
        return new Compromisso(
            Id,
            Assunto,
            DataDeOcorrencia,
            HoraDeInicio,
            HoraDeTermino,
            TipoDeCompromisso,
            Local,
            Link,
            null!
        );
    }
}

public class VisualizarCompromissoViewModel
{
    public List<DetalhesCompromissoViewModel> Registros { get; set; } = new();

    public VisualizarCompromissoViewModel() { }

    public VisualizarCompromissoViewModel(List<Compromisso> compromissos)
    {
        foreach (var c in compromissos)
            Registros.Add(c.ParaDetalhesVm());
    }
}

public class DetalhesCompromissoViewModel
{
    public Guid Id { get; set; }
    public string Assunto { get; set; }
    public DateOnly DataDeOcorrencia { get; set; }
    public TimeSpan HoraDeInicio { get; set; }
    public TimeSpan HoraDeTermino { get; set; }
    public string TipoDeCompromisso { get; set; }
    public string Local { get; set; }
    public string Link { get; set; }
    public Contato? Contato { get; set; }

    public DetalhesCompromissoViewModel(
        Guid id,
        string assunto,
        DateOnly dataDeOcorrencia,
        TimeSpan horaDeInicio,
        TimeSpan horaDeTermino,
        string tipoDeCompromisso,
        string local,
        string link,
        Contato? contato)
    {
        Id = id;
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeInicio;
        HoraDeTermino = horaDeTermino;
        TipoDeCompromisso = tipoDeCompromisso;
        Local = local;
        Link = link;
        Contato = contato;
    }
}

public class ExcluirCompromissoViewModel
{
    public Guid Id { get; set; }
    public string Assunto { get; set; }

    public ExcluirCompromissoViewModel() { }

    public ExcluirCompromissoViewModel(Guid id, string assunto)
    {
        Id = id;
        Assunto = assunto;
    }
}
