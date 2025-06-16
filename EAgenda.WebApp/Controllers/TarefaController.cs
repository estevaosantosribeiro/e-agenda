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
        var registros = repositorioTarefa.SelecionarRegistros();

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
}
