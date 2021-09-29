using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaCadetes.Entidades;
using NLog.Web;

namespace EmpresaCadetes.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly List<Cadete> listacadetes;
        private readonly List<Pedidos> listapedidos;
        static int idpedidos=0;
        public PedidosController(ILogger<PedidosController> logger, List<Cadete> Listacadetes, List<Pedidos> Listapedidos)
        {
            _logger = logger;
            listacadetes = Listacadetes;
            listapedidos = Listapedidos;
            _logger.LogDebug(1, "NLog injected into Pedidos Controller");

        }
        public IActionResult AgregarPedidos(string obs,string nombrec,string direc,string telefonoc)
        {
            //int cantidadcadetes=listacadetes.Count();
            Cliente newCliente = new Cliente(idpedidos,nombrec,direc,telefonoc);
            Pedidos newPedido = new Pedidos(idpedidos,obs,newCliente,telefonoc);
            //_logger.LogInformation("Hello, this is the Cargar Cadetes!");
            listapedidos.Add(newPedido);
            idpedidos++;
            return View(newPedido);
        }
        public IActionResult FormularioPedido()
        {
            //_logger.LogInformation("Hello, this is the Cargar Cadetes!");
            return View();
        }

        public IActionResult MostrarPedidos()
        {
            //_logger.LogInformation("Hello, this is the index!");
            return View(listapedidos);
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            return View();
        }
    }
}
