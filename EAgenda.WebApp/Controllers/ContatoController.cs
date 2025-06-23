using EAgenda.Dominio.ModuloContato;
using EAgenda.Dominio.Modulo_Compromissos;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using EAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAgenda.WebApp.Controllers;

[Route("contatos")]
public class ContatoController : Controller
{
    private readonly IRepositorioContato repositorioContato;
    private readonly IRepositorioCompromisso repositorioCompromisso;
    private readonly ContextoDados contextoDados;

    public ContatoController(
        ContextoDados contexto, 
        IRepositorioContato repositorioContato, 
        IRepositorioCompromisso repositorioCompromisso)
    {
        contextoDados = contexto;
        this.repositorioContato = repositorioContato;
        this.repositorioCompromisso = repositorioCompromisso;
    }

    public IActionResult Index()
    {
        var contatos = repositorioContato.SelecionarRegistros();
        var vm = new VisualizarContatosViewModel(contatos);
        return View(vm);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        return View(new CadastrarContatoViewModel());
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarContatoViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        // Verifica duplicidade de email ou telefone
        var contatosExistentes = repositorioContato.SelecionarRegistros();

        if (contatosExistentes.Any(c => c.Email.Equals(vm.Email, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError("Email", "Já existe um contato cadastrado com esse email.");
            return View(vm);
        }

        if (contatosExistentes.Any(c => c.Telefone == vm.Telefone))
        {
            ModelState.AddModelError("Telefone", "Já existe um contato cadastrado com esse telefone.");
            return View(vm);
        }

        repositorioContato.CadastrarRegistro(vm.ParaEntidade());

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public IActionResult Editar(Guid id)
    {
        var contato = repositorioContato.SelecionarRegistroPorId(id);

        if (contato == null)
            return NotFound();

        var vm = new EditarContatoViewModel(contato.Id, contato.Nome, contato.Email, contato.Telefone, contato.Cargo, contato.Empresa);

        return View(vm);
    }

    [HttpPost("editar/{id:guid}")]
    public IActionResult Editar(Guid id, EditarContatoViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var contatosExistentes = repositorioContato.SelecionarRegistros().Where(c => c.Id != id);

        if (contatosExistentes.Any(c => c.Email.Equals(vm.Email, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError("Email", "Já existe um contato cadastrado com esse email.");
            return View(vm);
        }

        if (contatosExistentes.Any(c => c.Telefone == vm.Telefone))
        {
            ModelState.AddModelError("Telefone", "Já existe um contato cadastrado com esse telefone.");
            return View(vm);
        }

        repositorioContato.EditarRegistro(id, vm.ParaEntidade());

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id)
    {
        var contato = repositorioContato.SelecionarRegistroPorId(id);

        if (contato == null)
            return NotFound();

        // Verifica se contato tem compromissos vinculados
        var compromissosDoContato = repositorioCompromisso.SelecionarRegistros()
            .Where(c => c.Contatos.Any(ct => ct.Id == id)).ToList();

        var vm = new ExcluirContatoViewModel(contato.Id, contato.Nome)
        {
            TemCompromissos = compromissosDoContato.Any()
        };

        return View(vm);
    }

    [HttpPost("excluir/{id:guid}")]
    public IActionResult ExcluirConfirmado(Guid id, ExcluirContatoViewModel vm)
    {
        var compromissosDoContato = repositorioCompromisso.SelecionarRegistros()
            .Where(c => c.Contatos.Any(ct => ct.Id == id)).ToList();

        if (compromissosDoContato.Any())
        {
            TempData["ErroExclusao"] = "Não é possível excluir o contato porque ele possui compromissos vinculados.";
            return RedirectToAction(nameof(Excluir), new { id });
        }

        repositorioContato.ExcluirRegistro(id);

        return RedirectToAction(nameof(Index));
    }
}
