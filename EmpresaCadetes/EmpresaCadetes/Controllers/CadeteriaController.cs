﻿using EmpresaCadetes.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;

namespace EmpresaCadetes.Controllers
{
    public class CadeteriaController : Controller
    {
        private readonly ILogger<CadeteriaController> _logger;
       
        private readonly Cadeteria micadeteria;
        private readonly DBCadeteria db;
        static int id = 0;


        public CadeteriaController(ILogger<CadeteriaController> logger,Cadeteria micadeteria,DBCadeteria db)
        {
            _logger = logger;
           
            this.micadeteria = micadeteria;
            this.db = db;
            _logger.LogDebug(1, "NLog injected into HomeController");

        }

        public IActionResult CargarCadetes(string nombre,string dire,string telefono)
        {
            id = micadeteria.MisCadetes.Count;
            Cadete newCadete = new Cadete(id,nombre,dire,telefono);
            micadeteria.AgregarCadetes(newCadete);
            db.SaveCadete(newCadete);

            _logger.LogInformation("Hello, this is the Cargar Cadetes!");
            id++;
            return View(newCadete);
        }
        public IActionResult FormularioCadete()
        {

            return View();
        }
        
        public IActionResult CadetesConPedidos()
        {

            return View(micadeteria);
        }

        public IActionResult PagarCadete(int idCadete)
        {
            Cadete micadete = micadeteria.MisCadetes.Where(cade => cade.Id == idCadete).First();
            
            return Redirect("CadetesConPedidos");
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            return View(micadeteria.MisCadetes);
        }
        public IActionResult EliminarCadete(int idCadete)
        {
            Cadete miCadete = micadeteria.MisCadetes.Where(cad => cad.Id == idCadete).First();
            micadeteria.MisCadetes.Remove(miCadete);
            db.DeleteCadetes(miCadete.Id);
            return Redirect("Index");
        }
    }
}
