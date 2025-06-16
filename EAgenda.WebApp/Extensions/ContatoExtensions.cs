using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloContato;
using EAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using static EAgenda.WebApp.Models.FormularioContatoViewModel;

namespace EAgenda.WebApp.Extensions
{
    public static class ContatoExtensions 
    {
        public static DetalhesContatoViewModel ParaDetalhesVm(this Contato contato)
        {
            return new DetalhesContatoViewModel(contato.Id, contato.Nome, contato.Email, contato.Telefone, contato.Cargo, contato.Empresa);
        }
    }
}

