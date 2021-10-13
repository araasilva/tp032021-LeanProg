using EmpresaCadetes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaCadetes.Entidades
{
    public class Cadeteria
    {
     
        private List<Cadete> misCadetes;
        private List<Pedidos> misPedidos;
        private List<Cliente> misclientes;
        

        
        public Cadeteria()
        {
            misCadetes = new List<Cadete>();
            misclientes = new List<Cliente>();
            misPedidos = new List<Pedidos>();
        }
      
        public List<Cadete> MisCadetes { get => misCadetes; set => misCadetes = value; }
        public List<Pedidos> MisPedidos { get => misPedidos; set => misPedidos = value; }
        public List<Cliente> Misclientes { get => misclientes; set => misclientes = value; }


        public void AgregarCadetes(Cadete cadete)
        {
           
            misCadetes.Add(cadete);
        }
        public void AgregarPedidos(Pedidos P)
        {
           misPedidos.Add(P);
        }
        public void AgregarClientes(Cliente CClient)
        {
            misclientes.Add(CClient);
        }
    }
}
