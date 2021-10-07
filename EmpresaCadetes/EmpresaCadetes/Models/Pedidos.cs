using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaCadetes.Entidades;
namespace EmpresaCadetes.Entidades
{
    public class Pedidos
    {
        private int numero;
        private string observacion;
        private Cliente newCliente;
        private string estado;
     

        public Pedidos(int numero, string observacion, string estado,string nombre,string direcion, string telefono)
        {
            this.numero = numero;
            this.observacion = observacion;
            this.newCliente = new Cliente(numero,nombre,direcion,telefono);
            this.estado = estado;
        }

        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente NewCliente { get => newCliente; set => newCliente = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
