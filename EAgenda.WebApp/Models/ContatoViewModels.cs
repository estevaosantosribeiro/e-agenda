﻿using EAgenda.Dominio.ModuloContato;
using EAgenda.WebApp.Extensions;
using System.ComponentModel.DataAnnotations;

namespace EAgenda.WebApp.Models;

public abstract class FormularioContatoViewModel
{
    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo \"Email\" é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo \"Email\" deve ser um email válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo \"Telefone\" é obrigatório.")]
    [RegularExpression(@"\(\d{2}\) \d{4,5}-\d{4}", ErrorMessage = "O telefone deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.")]
    public string Telefone { get; set; }

    public string? Cargo { get; set; }
    public string? Empresa { get; set; }
}

public class VisualizarContatosViewModel
{
    public List<DetalhesContatoViewModel> Registros { get; set; } = new List<DetalhesContatoViewModel>();

    public VisualizarContatosViewModel() { }

    public VisualizarContatosViewModel(List<Contato> contatos)
    {
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
        Cargo = cargo;
        Empresa = empresa;
    }

    public Contato ParaEntidade()
    {
        return new Contato(Nome, Email, Telefone, Cargo, Empresa);
    }
}

public class EditarContatoViewModel : FormularioContatoViewModel
{
    public Guid Id { get; set; }

    public EditarContatoViewModel() { }

    public EditarContatoViewModel(Guid id, string nome, string email, string telefone, string cargo, string empresa)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Cargo = cargo;
        Empresa = empresa;
    }

    public Contato ParaEntidade()
    {
        var contato = new Contato(Nome, Email, Telefone, Cargo, Empresa);
        contato.Id = Id;
        return contato;
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

public class ExcluirContatoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public bool TemCompromissos { get; set; } = false;

    public ExcluirContatoViewModel() { }

    public ExcluirContatoViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
