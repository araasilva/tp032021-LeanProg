using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaCadetes.Entidades;

namespace EmpresaCadetes.Controllers
{
    public class CadeteriaController : Controller
    {
        private readonly ILogger<CadeteriaController> _logger;
        private readonly List<Cadete> listacadetes;
        static int id = 0;

        public CadeteriaController(ILogger<CadeteriaController> logger,List<Cadete> Listacadetes)
        {
            _logger = logger;
             listacadetes = Listacadetes;
            _logger.LogDebug(1, "NLog injected into HomeController");

        }

        public IActionResult CargarCadetes(string nombre,string dire,string telefono)
        {
            
            Cadete newCadete = new Cadete(id,nombre,dire,telefono);
            listacadetes.Add(newCadete);
            //_logger.LogInformation("Hello, this is the Cargar Cadetes!");
            id++;
            return View(newCadete);
        }
        public IActionResult FormularioCadete()
        {

            return View();
        }
      

        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            return View(listacadetes);
        }
    }
}
