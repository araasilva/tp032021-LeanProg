using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaCadetes.Entidades
{
    public class Pago
    {
        private string fecha;
        private string nombreCadete;
        private float valor;
        private int codigo;
        public Pago(string fecha, string nombreCadete, float valor, int codigo)
        {
            this.Codigo = codigo;
            this.Fecha = fecha;
            this.NombreCadete = nombreCadete;
            this.Valor = valor;
        }

        public string Fecha { get => fecha; set => fecha = value; }
        public string NombreCadete { get => nombreCadete; set => nombreCadete = value; }
        public float Valor { get => valor; set => valor = value; }
        public int Codigo { get => codigo; set => codigo = value; }
    }
}
