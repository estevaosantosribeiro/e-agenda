using EAgenda.Dominio.Compartilhado;
using EAgenda.Dominio.Modulo_Compromissos;
using EAgenda.Dominio.ModuloContato;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using EAgenda.Infraestrutura.Arquivos.ModuloCompromisso;
using EAgenda.Infraestrutura.Arquivos.ModuloContato;
using EAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EAgenda.WebApp.Controllers
{
    [Route("compromissos")]
    public class CompromissoController : Controller
    {
        private readonly IrepositorioCompromisso repositorio;
        private readonly ContextoDados contextodados;
        private readonly IRepositorioContato contatos;

        public CompromissoController()
        {
            contextodados = new ContextoDados(true);
            repositorio = new RepositorioCompromisso(contextodados);
            contatos = new RepositorioContatoEmArquivo(contextodados);
        }

        public IActionResult Index()
        {
            var registros = repositorio.SelecionarRegistros();
            var visualizarVM = new VisualizarCompromissoViewModel(registros);

            return View(visualizarVM);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var cadastrarVM = new CadastrarCompromissoViewModel();
            cadastrarVM.Contatos = contatos.SelecionarRegistros();

            return View(cadastrarVM);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(CadastrarCompromissoViewModel cadastrarVm)
        {
            if (cadastrarVm.HoraDeTermino <= cadastrarVm.HoraDeInicio)
                ModelState.AddModelError(nameof(cadastrarVm.HoraDeTermino), "A hora de término deve ser maior que a hora de início.");

            if (!ModelState.IsValid)
            {
                cadastrarVm.Contatos = contatos.SelecionarRegistros();
                return View(cadastrarVm);
            }

            List<Contato> contatosSelecionados = new();

            if (cadastrarVm.ContatoId != null)
            {
                var contatoSelecionado = contatos.SelecionarRegistroPorId(cadastrarVm.ContatoId.Value);
                if (contatoSelecionado != null)
                    contatosSelecionados.Add(contatoSelecionado);
            }

            string linkLocal;

            if (cadastrarVm.TipoDeCompromisso == "Remoto")
            {
                linkLocal = cadastrarVm.Link;
            }
            else
            {
                linkLocal = cadastrarVm.Link;
            }

            var entidade = new Compromisso(
                Guid.NewGuid(),
                cadastrarVm.Assunto,
                cadastrarVm.DataDeOcorrencia,
                cadastrarVm.HoraDeInicio,
                cadastrarVm.HoraDeTermino,
                cadastrarVm.TipoDeCompromisso,
                linkLocal,   // Local opcional
                linkLocal,    // Link opcional
                contatosSelecionados // Contato opcional
            );

            repositorio.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:guid}")]
        public IActionResult Editar(Guid id)
        {
            var registroSelecionado = repositorio.SelecionarRegistroPorId(id);

            Guid contatoId = Guid.Empty;
            if (registroSelecionado.Contatos != null && registroSelecionado.Contatos.Count > 0)
                contatoId = registroSelecionado.Contatos[0].Id;

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
                contatos.SelecionarRegistros()
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
                editarVM.Contatos = contatos.SelecionarRegistros();
                return View(editarVM);
            }

            List<Contato> contatosSelecionados = new();

            if (editarVM.ContatoId != null)
            {
                var contatoSelecionado = contatos.SelecionarRegistroPorId(editarVM.ContatoId.Value);
                if (contatoSelecionado != null)
                    contatosSelecionados.Add(contatoSelecionado);
            }

            var entidade = editarVM.ParaEntidade();
            entidade.Contatos = contatosSelecionados;

            repositorio.EditarRegistro(id, entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            var registroSelecionado = repositorio.SelecionarRegistroPorId(id);
            var excluirVm = new ExcluirCompromissoViewModel(registroSelecionado.Id, registroSelecionado.Assunto);

            return View(excluirVm);
        }

        [HttpPost("excluir/{id:guid}")]
        public IActionResult ExcluirConfirmado(Guid id, ExcluirCompromissoViewModel excluirVM)
        {
            repositorio.ExcluirRegistro(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
