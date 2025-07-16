using EAgenda.Dominio.Modulo_Compromissos;
using EAgenda.Dominio.ModuloCompromissos;
using EAgenda.Dominio.ModuloContato;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using EAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAgenda.WebApp.Controllers;

[Route("compromissos")]
public class CompromissoController : Controller
{
    private readonly ContextoDados contextoDados;
    private readonly IRepositorioCompromisso repositorioCompromisso;
    private readonly IRepositorioContato repositorioContato;

    public CompromissoController(
        ContextoDados contexto,
        IRepositorioCompromisso repositorioCompromisso,
        IRepositorioContato repositorioContato)
    {
        contextoDados = contexto;
        this.repositorioCompromisso = repositorioCompromisso;
        this.repositorioContato = repositorioContato;
    }

    public IActionResult Index()
    {
        var registros = repositorioCompromisso.SelecionarRegistros();
        var visualizarVM = new VisualizarCompromissoViewModel(registros);
        return View(visualizarVM);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarCompromissoViewModel
        {
            Contatos = repositorioContato.SelecionarRegistros()
        };

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarCompromissoViewModel cadastrarVm)
    {
        if (cadastrarVm.HoraDeTermino <= cadastrarVm.HoraDeInicio)
            ModelState.AddModelError(nameof(cadastrarVm.HoraDeTermino), "A hora de término deve ser maior que a hora de início.");

        if (!ModelState.IsValid)
        {
            cadastrarVm.Contatos = repositorioContato.SelecionarRegistros();
            return View(cadastrarVm);
        }

        Contato? contatoSelecionado = null;

        if (cadastrarVm.ContatoId != null)
            contatoSelecionado = repositorioContato.SelecionarRegistroPorId(cadastrarVm.ContatoId.Value);

        var compromisso = new Compromisso(
            Guid.NewGuid(),
            cadastrarVm.Assunto,
            cadastrarVm.DataDeOcorrencia,
            cadastrarVm.HoraDeInicio,
            cadastrarVm.HoraDeTermino,
            cadastrarVm.TipoDeCompromisso,
            cadastrarVm.Local,
            cadastrarVm.Link,
            contatoSelecionado
        );

        repositorioCompromisso.CadastrarRegistro(compromisso);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public IActionResult Editar(Guid id)
    {
        var registroSelecionado = repositorioCompromisso.SelecionarRegistroPorId(id);

        Guid contatoId = registroSelecionado.Contato?.Id ?? Guid.Empty;

        var editarVM = new EditarCompromissoViewModel(
            registroSelecionado.Id,
            registroSelecionado.Assunto,
            registroSelecionado.DataDeOcorrencia,
            registroSelecionado.HoraDeInicio,
            registroSelecionado.HoraDeTermino,
            registroSelecionado.TipoDeCompromisso,
            registroSelecionado.Local,
            registroSelecionado.Link,
            contatoId,
            repositorioContato.SelecionarRegistros()
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    public IActionResult Editar(Guid id, EditarCompromissoViewModel editarVM)
    {
        if (editarVM.HoraDeTermino <= editarVM.HoraDeInicio)
            ModelState.AddModelError(nameof(editarVM.HoraDeTermino), "A hora de término deve ser maior que a hora de início.");

        if (!ModelState.IsValid)
        {
            editarVM.Contatos = repositorioContato.SelecionarRegistros();
            return View(editarVM);
        }

        var entidade = editarVM.ParaEntidade();

        if (editarVM.ContatoId != null)
            entidade.Contato = repositorioContato.SelecionarRegistroPorId(editarVM.ContatoId.Value);

        repositorioCompromisso.EditarRegistro(id, entidade);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id)
    {
        var registroSelecionado = repositorioCompromisso.SelecionarRegistroPorId(id);
        var excluirVm = new ExcluirCompromissoViewModel(registroSelecionado.Id, registroSelecionado.Assunto);
        return View(excluirVm);
    }

    [HttpPost("excluir/{id:guid}")]
    public IActionResult ExcluirConfirmado(Guid id, ExcluirCompromissoViewModel excluirVM)
    {
        repositorioCompromisso.ExcluirRegistro(id);
        return RedirectToAction(nameof(Index));
    }
}
