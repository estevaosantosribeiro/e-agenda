using EAgenda.Dominio.Compartilhado;
using EAgenda.Dominio.ModuloContato;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using EAgenda.Infraestrutura.Arquivos.ModuloContato;
using Microsoft.AspNetCore.Mvc;
using static EAgenda.WebApp.Models.FormularioContatoViewModel;

namespace EAgenda.WebApp.Controllers
{
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
    }
}
