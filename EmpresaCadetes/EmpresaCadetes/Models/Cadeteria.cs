using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaCadetes.Entidades
{
    public class Cadeteria
    {
        private string nombre;
        //private List<Cadete> misCadetes;
        public Cadeteria(string nombre)
        {
            this.nombre = nombre;
        }

        public string Nombre { get => nombre; set => nombre = value; }
     
    }
}
