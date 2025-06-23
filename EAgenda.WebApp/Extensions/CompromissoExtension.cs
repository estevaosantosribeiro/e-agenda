using EAgenda.Dominio.Modulo_Compromissos;
using EAgenda.WebApp.Models;

namespace EAgenda.WebApp.Extensions;

public static class CompromissoExtension
{
    public static DetalhesCompromissoViewModel ParaDetalhesVm(this Compromisso compromisso)
    {
        return new DetalhesCompromissoViewModel(
            compromisso.Id,
            compromisso.Assunto,
            compromisso.DataDeOcorrencia,
            compromisso.HoraDeInicio, 
            compromisso.HoraDeTermino, 
            compromisso.TipoDeCompromisso, 
            compromisso.Local, 
            compromisso.Link, 
            compromisso.Contatos);
    }
    public static Compromisso ParaEntidade(this FormularioCompromissoViewModel compromissoVM)
    {
        return new Compromisso(
            compromissoVM.Assunto, 
            compromissoVM.DataDeOcorrencia, 
            compromissoVM.HoraDeInicio, 
            compromissoVM.HoraDeTermino, 
            compromissoVM.TipoDeCompromisso, 
            compromissoVM.Local, 
            compromissoVM.Link, 
            compromissoVM.Contatos);
    }
}
