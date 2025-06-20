using EAgenda.Dominio.Modulo_Compromissos;
using EAgenda.Dominio.ModuloContato;
using EAgenda.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace EAgenda.WebApp.Models;

public class FormularioCompromissoViewModel
{
    public string Assunto { get; set; }
    public DateOnly DataDeOcorrencia { get; set; }
    public TimeSpan HoraDeInicio { get; set; }
    public TimeSpan HoraDeTermino { get; set; }
    public string TipoDeOcorrido { get; set; }
}
public class CadastrarCompromissoViewModel : FormularioCompromissoViewModel
{
    public CadastrarCompromissoViewModel() { }

    public CadastrarCompromissoViewModel(string assunto, DateOnly dataDeOcorrencia, TimeSpan horaDeInico, TimeSpan horaDeTermino, string tipoDeOcorrido) : this()
    {
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeInico;
        HoraDeTermino = horaDeTermino;
        TipoDeOcorrido = tipoDeOcorrido;
    }
}
public class EditarCompromissoViewModel : FormularioCompromissoViewModel
{
    public Guid Id { get; set; }

    public EditarCompromissoViewModel() { }

    public EditarCompromissoViewModel(Guid id, string assunto, DateOnly dataDeOcorrencia, TimeSpan horaDeInicio, TimeSpan horaDeTermino, string tipoDeOcorrido) : this()
    {
        Id = id;
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeInicio;
        HoraDeTermino = horaDeTermino;
        TipoDeOcorrido = tipoDeOcorrido;
    }
}

public class VisualizarCompromissoViewModel
{
    public VisualizarCompromissoViewModel() { }

    public List<DetalhesCompromissoViewModel> Registros;

    public VisualizarCompromissoViewModel(List<Compromisso> compromisso)
    {
        Registros = new List<DetalhesCompromissoViewModel>();

        foreach (var c in compromisso)
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
    public string TipoDeOcorrido { get; set; }


    public DetalhesCompromissoViewModel(Guid id, string assunto, DateOnly dataDeOcorrencia, TimeSpan horaDeIncio, TimeSpan horaDeTermino, string tipodeocorrido)
    {
        Id = id;
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeIncio;
        HoraDeTermino = horaDeTermino;
        TipoDeOcorrido = tipodeocorrido;

    }
}
    public class ExcluirCompromissoViewModel
    {
        public Guid Id { get; set; }
        public string Assunto { get; set; }
        public ExcluirCompromissoViewModel() { }

        public ExcluirCompromissoViewModel(Guid id, string assunto) : this()
        {
            Id = id;
            Assunto = assunto;

        }
    }

