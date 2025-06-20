using EAgenda.Dominio.Compartilhado;
using EAgenda.Dominio.Modulo_Compromissos;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using EAgenda.Infraestrutura.Arquivos.ModuloCompromisso;
using EAgenda.WebApp.Extensions;
using EAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAgenda.WebApp.Controllers
{
    [Route("compromissos")]
    public class CompromissoController : Controller
    {
        private readonly IrepositorioCompromisso repositorio;
        private readonly ContextoDados contextodados;
        public CompromissoController()
        {
            contextodados = new ContextoDados(true);
            repositorio = new RepositorioCompromisso(contextodados);
        }

        public IActionResult Index()
        {
            var registroSelecionado = repositorio.SelecionarRegistros();
            var visualizarVM = new VisualizarCompromissoViewModel(registroSelecionado);

            return View(visualizarVM);
        }
        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var cadastrarVM = new CadastrarCompromissoViewModel();

            return View(cadastrarVM);
        }

        [HttpPost("cadastrar")]

        public IActionResult Cadastrar(CadastrarCompromissoViewModel cadastrarVm)
        {
            var entidade = cadastrarVm.ParaEntidade();
            repositorio.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{Id:Guid}")]

        public IActionResult Editar(Guid id)
        {
            var registroSelecionado = repositorio.SelecionarRegistroPorId(id);

            var editarVM = new EditarCompromissoViewModel(registroSelecionado.Id, registroSelecionado.Assunto, registroSelecionado.DataDeOcorrencia, registroSelecionado.HoraDeInicio, registroSelecionado.HoraDeTermino, registroSelecionado.TipoDeOcorrido);

           return View(editarVM);
        }
        [HttpPost("editar/{Id:Guid}")]

        public IActionResult Editar(Guid id, EditarCompromissoViewModel editarVM)
        {
            var entidade = editarVM.ParaEntidade();

            repositorio.EditarRegistro(id, entidade);

            return RedirectToAction(nameof(Index));
        }
    }

    
}
