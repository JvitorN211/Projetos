using Agenda___IATEC.Models;
using Agenda___IATEC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Agenda___IATEC.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventoRepositorio _eventoRepositorio;
        public EventosController(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }
        public IActionResult Index()
        {
            List<EventosModel> eventos = _eventoRepositorio.BuscarPublicos();

            return View(eventos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            EventosModel evento = _eventoRepositorio.ListarPorId(id);
            return View(evento);
        }
        public IActionResult ExcluirConfirmacao(int id)
        {
            EventosModel evento = _eventoRepositorio.ListarPorId(id);
            return View(evento);
        }
        public IActionResult Excluir(int id)
        {
            try
            {
                bool excluido = _eventoRepositorio.Excluir(id);
                
                if(excluido)
                {
                    TempData["MensagemSucesso"] = "Evento Excluído com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos excluir seu evento!";
                }

                return RedirectToAction("Index", "Home");
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu evento. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AdicionarConfirmacao(int id)
        {
            EventosModel evento = _eventoRepositorio.ListarPorId(id);
            return View(evento);
        }

        public IActionResult Dashboard()
        {
            List<EventosModel> eventos = _eventoRepositorio.BuscarPublicos();

            return View(eventos);
        }

        [HttpPost]
        public IActionResult Criar(EventosModel evento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _eventoRepositorio.Adicionar(evento);
                    TempData["MensagemSucesso"] = "Evento Criado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }

                return View(evento);
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, Não conseguimos criar seu evento, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Alterar(EventosModel evento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _eventoRepositorio.Atualizar(evento);
                    TempData["MensagemSucesso"] = "Evento Alterado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }

                return View("Editar", evento);
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, Não conseguimos Atualizar seu evento, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
