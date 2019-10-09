using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TEste.Models;

namespace TEste.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //https://localhost:44308/Home/Cliente?nome=fulano&idade=20&email=ful@ful.com
            
        [HttpGet]
        public IActionResult Cliente()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Cliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var repositorio = new Repositorio();
                repositorio.Cadastrar(cliente);
                return RedirectToAction("Lista");
            }
            else
            {
                return View(cliente);
            }
        }

        public IActionResult Lista()
        {
            var repositorio = new Repositorio();
            var listaDeClientes = repositorio.Listar();
            return View(listaDeClientes);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
