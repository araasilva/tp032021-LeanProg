using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaCadetes.Entidades
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direcion;
        private string telefono;
        static private List<Pedidos> listapedidos;

        public Cadete(int id, string nombre, string direcion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direcion = direcion;
            this.telefono = telefono;
            listapedidos = new List<Pedidos>();
        }

        public void AgregarListadepeditos(Pedidos pedidosparaelCadete)
        {
            listapedidos.Add(pedidosparaelCadete);
        
        }
        public void QuitarListadepeditos(Pedidos pedido)
        {
            if (listapedidos.Contains(pedido))
            {
                listapedidos.Remove(pedido);
            }
            

        }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direcion { get => direcion; set => direcion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedidos> Listapedidos { get => listapedidos; set => listapedidos = value; }
    }
}
