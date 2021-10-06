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
        private readonly Cadeteria micadeteria;
        static int idpedidos=0;
        public PedidosController(ILogger<PedidosController> logger, Cadeteria micadeteria)
        {
            _logger = logger;
            this.micadeteria = micadeteria;
            _logger.LogDebug(1, "NLog injected into Pedidos Controller");

        }
        public IActionResult AgregarPedidos(string obs,string nombrec,string direc,string telefonoc,string estado)
        {
            //int cantidadcadetes=listacadetes.Count();
            Cliente newCliente = new Cliente(idpedidos,nombrec,direc,telefonoc);
           // listaClientes.Add(newCliente);
            micadeteria.Misclientes.Add(newCliente);
            Pedidos newPedido = new Pedidos(idpedidos,obs,newCliente,estado);
            //_logger.LogInformation("Hello, this is the Cargar Cadetes!");
            // listapedidos.Add(newPedido);
            // micadeteria.AgregarPedidos(listapedidos);
            micadeteria.MisPedidos.Add(newPedido);
            idpedidos++;
            return View(newPedido);
        }
        public IActionResult FormularioPedido()
        {
            //_logger.LogInformation("Hello, this is the Cargar Cadetes!");
            return View();
        }

        public IActionResult MostrarPedidos(int idPedidos,int idCadete)
        {
            //_logger.LogInformation("Hello, this is the index!");
            return View(micadeteria);
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            return View();
        }
    }
}
