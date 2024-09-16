using MeuRobo.Controllers.Base;
using MeuRobo.Models;
using MeuRoboNegocios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MeuRobo.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExecutorRepository _executorRepository;

        public HomeController(ILogger<HomeController> logger, IExecutorRepository executorRepository)
        {
            _logger = logger;
            _executorRepository = executorRepository;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Privacy(string nome )
        {
            if (!string.IsNullOrEmpty(nome))
            {
               List<string> listaTitulo = _executorRepository.Execute(nome);
               ViewBag.Titulo = listaTitulo;
                return RedirectToAction("Index", "Cursos");
            }
            else
            {
                MessageError("O campo de pesquisa não pode estar em Branco", "warning");
                return View("Index");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
