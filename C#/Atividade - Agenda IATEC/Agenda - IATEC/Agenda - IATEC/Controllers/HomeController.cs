using Agenda___IATEC.Models;
using Agenda___IATEC.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agenda___IATEC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventoRepositorio _eventoRepositorio;
        public HomeController(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }

        public IActionResult Index()
        {
            List<EventosModel> eventos = _eventoRepositorio.BuscarPublicos();

            return View(eventos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}