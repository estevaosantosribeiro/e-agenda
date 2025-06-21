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

    [HttpGet("editar/{id:guid}")]
    public IActionResult Editar(Guid id)
    {
        var despesaSelecionada = repositorioDespesa.SelecionarRegistroPorId(id);

        if (despesaSelecionada == null)
            return NotFound();

        var categoriasDisponiveis = repositorioCategoria.SelecionarRegistros();

        var editarVM = new EditarDespesaViewModel(
            id,
            despesaSelecionada.Descricao,
            despesaSelecionada.DataOcorrencia ?? DateTime.Now,
            despesaSelecionada.Valor,
            despesaSelecionada.FormaPagamento,
            categoriasDisponiveis,
            despesaSelecionada.Categorias.Select(c => c.Id).ToList()
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(Guid id, EditarDespesaViewModel editarVM)
    {
        editarVM.CategoriasDisponiveis = repositorioCategoria.SelecionarRegistros();

        ModelState.Remove(nameof(editarVM.CategoriasDisponiveis));

        if (!ModelState.IsValid)
            return View(editarVM);

        var categoriasSelecionadas = editarVM
            .CategoriasSelecionadas
            .Select(id => repositorioCategoria.SelecionarRegistroPorId(id))
            .ToList();

        var despesaAntiga = repositorioDespesa.SelecionarRegistroPorId(id);

        foreach (var categoria in contextoDados.Categorias)
            categoria.RemoverDespesa(despesaAntiga);

        var novaDespesa = editarVM.ParaEntidade(categoriasSelecionadas);
        novaDespesa.Id = id;

        foreach (var categoria in categoriasSelecionadas)
            categoria.AdicionarDespesa(novaDespesa);

        repositorioDespesa.EditarRegistro(id, novaDespesa);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id)
    {
        var despesaSelecionada = repositorioDespesa.SelecionarRegistroPorId(id);

        if (despesaSelecionada == null)
            return NotFound();

        var excluirVM = new ExcluirDespesaViewModel(despesaSelecionada.Id, despesaSelecionada.Descricao);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult ExcluirConfirmado(Guid id)
    {
        var despesaSelecionada = repositorioDespesa.SelecionarRegistroPorId(id);

        if (despesaSelecionada == null)
            return NotFound();

        foreach (var categoria in despesaSelecionada.Categorias)
            categoria.RemoverDespesa(despesaSelecionada);

        repositorioDespesa.ExcluirRegistro(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("detalhes/{id:guid}")]
    public IActionResult Detalhes(Guid id)
    {
        var despesa = repositorioDespesa.SelecionarRegistroPorId(id);

        if (despesa == null)
            return NotFound();

        var detalhesVM = new DetalhesDespesaViewModel(
            despesa.Id,
            despesa.Descricao,
            despesa.DataOcorrencia ?? DateTime.Now,
            despesa.Valor,
            despesa.FormaPagamento,
            despesa.Categorias
        );

        return View(detalhesVM);
    }

}
