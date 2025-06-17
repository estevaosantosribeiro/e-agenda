using EAgenda.Dominio.Compartilhado;
using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloContato;
using EAgenda.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EAgenda.WebApp.Models
{
    public abstract class FormularioContatoViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
    }
    public class VisualizarContatosViewModel
    {
        public VisualizarContatosViewModel()
        {

        }
        public List<DetalhesContatoViewModel> Registros { get; set; }

        public VisualizarContatosViewModel(List<Contato> contatos)
        {
            Registros = new List<DetalhesContatoViewModel>();

            foreach (var c in contatos)
                Registros.Add(c.ParaDetalhesVm());

        }

    }
    public class CadastrarContatoViewModel : FormularioContatoViewModel
    {
        public CadastrarContatoViewModel() { }

        public CadastrarContatoViewModel(string nome, string email, string telefone, string cargo, string empresa)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Email = email;
            Cargo = cargo;
            Empresa = empresa;
        }

    }

    public class DetalhesContatoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }

        public DetalhesContatoViewModel(Guid id, string nome, string email, string telefone, string cargo, string empresa)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cargo = cargo;
            Empresa = empresa;
        }
    }

}

