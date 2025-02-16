﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly DBCadeteria db;
        private readonly Cadeteria cadeteria;
        int idpedidos=0;
        public PedidosController(ILogger<PedidosController> logger,DBCadeteria Db,Cadeteria Cadeteria)
        {
            _logger = logger;
              db = Db;
            cadeteria = Cadeteria;
            _logger.LogDebug(1, "NLog injected into Pedidos Controller");

        }
        public IActionResult AgregarPedidos(string obs,string nombrec,string direc,string telefonoc,string estado)
        {
            
            if (cadeteria.MisPedidos.Count==0)
            {
                idpedidos = 1;
            }
            else
            {
                idpedidos = cadeteria.MisPedidos.Last().Numero + 1;
            }

            Pedidos newPedido;
            newPedido = new Pedidos(idpedidos, obs, estado, nombrec, direc, telefonoc);
            cadeteria.MisPedidos.Add(newPedido);
            db.SavePedidos(newPedido);
            idpedidos++;
            return View(newPedido);
        }
        public IActionResult FormularioPedido()
        {
            //Vista para cargar pedidos
            return View();
        }

        public IActionResult MostrarPedidos()
        {
               //VISTA PARA MOSTRAR PEDIDOS
            return View(cadeteria);
        }

        //cambiar Estado de un pedido a entregado para pagar al cadete
        public IActionResult ModificarEstado(int idPedido)
        {
            if (controlarPedidosconCadetes(idPedido))
            {
            Pedidos pedido = cadeteria.MisPedidos.Where(p => p.Numero==idPedido).First();
            pedido.Estado = "ENTREGADO";
            db.ModificarEstadoPedido(cadeteria.MisPedidos);
            foreach (var cade in cadeteria.MisCadetes)
            {
                foreach (var pedi in cade.Listapedidos)
                {
                    if (pedi.Numero==idPedido)
                    {
                        pedi.Estado = "ENTREGADO";
                    }
                }
            }

            db.ModificarListaCadeteApedido(cadeteria.MisCadetes);
            return Redirect("MostrarPedidos");
            }
            else
            {
                return Redirect("MostrarPedidos");
            }
        }

        //controlarPEDIDO EN CADETE
        private bool controlarPedidosconCadetes(int idpedido)
        {
            bool resultado = false;
            foreach (var cade in cadeteria.MisCadetes)
            {
                foreach (var pedi in cade.Listapedidos)
                {
                    if (pedi.Numero == idpedido)
                    {
                        resultado = true;
                    }
                }
            }
            return resultado;
        }
        //AGREGAR PEDIDO A CADETE
        public IActionResult PedidoAcadete(int idPedido,int idCadete)
        {
           QuitarPedido(idPedido);
            Cadete miCadete = cadeteria.MisCadetes.Where(a => a.Id == idCadete).First();
     
            Pedidos unPedido = cadeteria.MisPedidos.Where(p => p.Numero == idPedido).First();
            unPedido.Estado = "ENVIADO";
            db.ModificarEstadoPedido(cadeteria.MisPedidos);
            db.ModificarListaCadeteApedido(cadeteria.MisCadetes);
            miCadete.Listapedidos.Add(unPedido);
       
            return Redirect("MostrarPedidos");
        }
        //Funcion quitar pedido
        private void QuitarPedido(int idPedido)
        {
            Pedidos pedido = cadeteria.MisPedidos.Where(pe => pe.Numero == idPedido).First();
            cadeteria.MisCadetes.ForEach(cad => cad.Listapedidos.Remove(pedido));
        }

        public IActionResult EliminarPedido(int idPedido)
        {
            QuitarPedido(idPedido);
            cadeteria.MisPedidos.RemoveAll(p =>p.Numero==idPedido); //borro pedido de mi lista actual
            db.DeletePedidos(idPedido); //borro el pedido de mi base de datos
            db.ModificarListaCadeteApedido(cadeteria.MisCadetes); // y modifico mi lista cadetes
            return Redirect("MostrarPedidos");
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            return View();
        }
    }
}
