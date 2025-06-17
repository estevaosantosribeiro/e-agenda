using EAgenda.Dominio.Compartilhado;
using EAgenda.Dominio.ModuloContato;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using EAgenda.Infraestrutura.Arquivos.ModuloContato;
using EAgenda.WebApp.Extensions;
using EAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;



namespace EAgenda.WebApp.Controllers
{
    [Route("contatos")]
    public class ContatoController : Controller
    {
        private readonly ContextoDados contextoDados;
        private readonly IRepositorioContato repositorioContato;
        public ContatoController()
        {
            contextoDados = new ContextoDados(true);
            repositorioContato = new RepositorioContatoEmArquivo(contextoDados);
        }
       
        public IActionResult Index()
        {

            var registros = repositorioContato.SelecionarRegistros();

            var visualizarVm = new VisualizarContatosViewModel(registros);


            return View(visualizarVm);
        }
        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var CadastrarVm = new CadastrarContatoViewModel();

            return View(CadastrarVm);
        }
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(CadastrarContatoViewModel ContatoVm)
        {
            var entidade = ContatoVm.ParaEntidade();

            repositorioContato.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }
       
    }
}
