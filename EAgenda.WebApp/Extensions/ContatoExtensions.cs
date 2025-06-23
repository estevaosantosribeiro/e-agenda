using EAgenda.Dominio.ModuloContato;
using EAgenda.WebApp.Models;

namespace EAgenda.WebApp.Extensions;

public static class ContatoExtensions 
{
    public static DetalhesContatoViewModel ParaDetalhesVm(this Contato contato)
    {
        return new DetalhesContatoViewModel(
            contato.Id, 
            contato.Nome, 
            contato.Email, 
            contato.Telefone, 
            contato.Cargo, 
            contato.Empresa);
    }
    public static Contato ParaEntidade(this FormularioContatoViewModel contatoVm )
    {
        return new Contato(
            contatoVm.Nome, 
            contatoVm.Email, 
            contatoVm.Telefone, 
            contatoVm.Cargo, 
            contatoVm.Empresa);
    }
}

