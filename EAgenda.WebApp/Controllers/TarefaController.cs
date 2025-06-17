using EAgenda.Dominio.ModuloTarefa;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using EAgenda.Infraestrutura.Arquivos.ModuloTarefa;
using EAgenda.WebApp.Extensions;
using EAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAgenda.WebApp.Controllers;

[Route("tarefas")]
public class TarefaController : Controller
{
    private readonly ContextoDados contexto;
    private readonly IRepositorioTarefa repositorioTarefa;

    public TarefaController()
    {
        contexto = new ContextoDados(true);
        repositorioTarefa = new RepositorioTarefaEmArquivo(contexto);
    }

    [HttpGet]
    public IActionResult Index(string status)
    {
        List<Tarefa> registros;

        switch (status)
        {
            case "pendentes":
                registros = repositorioTarefa.SelecionarTarefasPendentes();
                break;
            case "concluidas":
                registros = repositorioTarefa.SelecionarTarefasConcluidas();
                break;
            case "prioridades":
                registros = repositorioTarefa.SelecionarTarefasPorPrioridade();
                break;
            default:
                registros = repositorioTarefa.SelecionarRegistros();
                break;
        }

        var visualizarVM = new VisualizarTarefasViewModel(registros);

        return View(visualizarVM);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarTarefaViewModel();

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(CadastrarTarefaViewModel cadastrarVM)
    {
        var entidade = cadastrarVM.ParaEntidade();

        repositorioTarefa.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public IActionResult Editar(Guid id)
    {
        var registro = repositorioTarefa.SelecionarRegistroPorId(id);

        var editarVM = new EditarTarefaViewModel
        {
            Id = registro.Id,
            Titulo = registro.Titulo,
            Prioridade = registro.Prioridade,
            DataCriacao = registro.DataCriacao
        };

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(Guid id, EditarTarefaViewModel editarVM)
    {
        var entidade = editarVM.ParaEntidade();

        repositorioTarefa.EditarRegistro(id, entidade);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id)
    {
        var registro = repositorioTarefa.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirTarefaViewModel
        {
            Id = registro.Id,
            Titulo = registro.Titulo
        };

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id, ExcluirTarefaViewModel excluirVM)
    {
        repositorioTarefa.ExcluirRegistro(id);
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("detalhes/{id:guid}")]
    public IActionResult Detalhes(Guid id)
    {
        var registro = repositorioTarefa.SelecionarRegistroPorId(id);

        var detalhesVM = new DetalhesTarefaViewModel(
            id, 
            registro.Titulo, 
            registro.Prioridade, 
            registro.DataCriacao, 
            registro.DataConclusao, 
            registro.EstaConcluida, 
            registro.PercentualConcluido, 
            registro.ItensTarefas);

        return View(detalhesVM);
    }

    [HttpPost, Route("/tarefas/{id:guid}/adicionar-item")]
    public IActionResult AdicionarTarefa(Guid id, AdicionarItemTarefaViewModel adicionarVM)
    {
        var registro = repositorioTarefa.SelecionarRegistroPorId(id);

        var novoItem = new ItemTarefa(adicionarVM.Titulo, registro);

        registro.ItensTarefas.Add(novoItem);

        contexto.Salvar();

        var detalhesVM = new DetalhesTarefaViewModel(
            id,
            registro.Titulo,
            registro.Prioridade,
            registro.DataCriacao,
            registro.DataConclusao,
            registro.EstaConcluida,
            registro.PercentualConcluido,
            registro.ItensTarefas);

        return View("Detalhes", detalhesVM);
    }

    [HttpPost, Route("/tarefas/{id:guid}/remover-item/{idItem:guid}")]
    public IActionResult RemoverTarefa(Guid id, Guid idItem)
    {
        var registro = repositorioTarefa.SelecionarRegistroPorId(id);
        
        foreach (var i in registro.ItensTarefas)
        {
            if (i.Id == idItem)
            {
                registro.ItensTarefas.Remove(i);
                break;
            }
        }
        
        contexto.Salvar();
        
        var detalhesVM = new DetalhesTarefaViewModel(
            id,
            registro.Titulo,
            registro.Prioridade,
            registro.DataCriacao,
            registro.DataConclusao,
            registro.EstaConcluida,
            registro.PercentualConcluido,
            registro.ItensTarefas);
        
        return View("Detalhes", detalhesVM);
    }

    [HttpPost, Route("/tarefas/{id:guid}/concluir-item/{idItem:guid}")]
    public IActionResult Concluir(Guid id, Guid idItem)
    {
        var registro = repositorioTarefa.SelecionarRegistroPorId(id);

        foreach (var i in registro.ItensTarefas)
        {
            if (i.Id == idItem)
            {
                i.EstaConcluida = true;
                break;
            }
        }

        contexto.Salvar();

        var detalhesVM = new DetalhesTarefaViewModel(
            id,
            registro.Titulo,
            registro.Prioridade,
            registro.DataCriacao,
            registro.DataConclusao,
            registro.EstaConcluida,
            registro.PercentualConcluido,
            registro.ItensTarefas);

        return View("Detalhes", detalhesVM);
    }

    [HttpPost, Route("/tarefas/{id:guid}/desconcluir-item/{idItem:guid}")]
    public IActionResult DesConcluir(Guid id, Guid idItem)
    {
        var registro = repositorioTarefa.SelecionarRegistroPorId(id);

        foreach (var i in registro.ItensTarefas)
        {
            if (i.Id == idItem)
            {
                i.EstaConcluida = false;
                break;
            }
        }

        contexto.Salvar();

        var detalhesVM = new DetalhesTarefaViewModel(
            id,
            registro.Titulo,
            registro.Prioridade,
            registro.DataCriacao,
            registro.DataConclusao,
            registro.EstaConcluida,
            registro.PercentualConcluido,
            registro.ItensTarefas);

        return View("Detalhes", detalhesVM);
    }
    
    
    [HttpPost, Route("/tarefas/{id:guid}/concluir-tarefa")]
    public IActionResult Concluir(Guid id)
    {
        var registro = repositorioTarefa.SelecionarRegistroPorId(id);

        registro.EstaConcluida = true;
        registro.DataConclusao = DateTime.Now;

        contexto.Salvar();

        var detalhesVM = new DetalhesTarefaViewModel(
            id,
            registro.Titulo,
            registro.Prioridade,
            registro.DataCriacao,
            registro.DataConclusao,
            registro.EstaConcluida,
            registro.PercentualConcluido,
            registro.ItensTarefas);

        return View("Detalhes", detalhesVM);
    }

    [HttpPost, Route("/tarefas/{id:guid}/desconcluir-tarefa")]
    public IActionResult DesConcluir(Guid id)
    {
        var registro = repositorioTarefa.SelecionarRegistroPorId(id);

        registro.EstaConcluida = false;
        registro.DataConclusao = DateTime.MinValue;

        contexto.Salvar();

        var detalhesVM = new DetalhesTarefaViewModel(
            id,
            registro.Titulo,
            registro.Prioridade,
            registro.DataCriacao,
            registro.DataConclusao,
            registro.EstaConcluida,
            registro.PercentualConcluido,
            registro.ItensTarefas);

        return View("Detalhes", detalhesVM);
    }
}
