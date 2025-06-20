using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloDespesa;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using EAgenda.Infraestrutura.Arquivos.ModuloCategoria;
using EAgenda.Infraestrutura.Arquivos.ModuloDespesa;
using EAgenda.WebApp.Extensions;
using EAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAgenda.WebApp.Controllers;

[Route("despesas")]
public class DespesaController : Controller
{
    private readonly ContextoDados contextoDados;
    private readonly IRepositorioDespesa repositorioDespesa;
    private readonly IRepositorioCategoria repositorioCategoria;

    public DespesaController()
    {
        contextoDados = new ContextoDados(true);
        repositorioDespesa = new RepositorioDespesaEmArquivo(contextoDados);
        repositorioCategoria = new RepositorioCategoriaEmArquivo(contextoDados);
    }

    public IActionResult Index()
    {
        var registros = repositorioDespesa.SelecionarRegistros();

        var visualizarVM = new VisualizarDespesasViewModel(registros);

        return View(visualizarVM);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarDespesaViewModel();

        var categoriasDisponiveis = repositorioCategoria.SelecionarRegistros();

        cadastrarVM.CategoriasDisponiveis = categoriasDisponiveis;

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    [ValidateAntiForgeryToken]
    public ActionResult Cadastrar(CadastrarDespesaViewModel cadastrarVM)
    {
        cadastrarVM.CategoriasDisponiveis = repositorioCategoria.SelecionarRegistros();

        ModelState.Remove(nameof(cadastrarVM.CategoriasDisponiveis));

        if (!ModelState.IsValid)
        {
            return View(cadastrarVM);
        }

        var categoriasSelecionadas = cadastrarVM
       .CategoriasSelecionadas
       .Select(id => repositorioCategoria.SelecionarRegistroPorId(id))
       .ToList();

        var entidade = cadastrarVM.ParaEntidade(categoriasSelecionadas);

        foreach (var categoria in categoriasSelecionadas)
        {
            categoria.AdicionarDespesa(entidade);
        }

        repositorioDespesa.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }
}
