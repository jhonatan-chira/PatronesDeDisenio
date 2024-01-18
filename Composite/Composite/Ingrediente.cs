using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Ingrediente : Component
    {
        public int Cantidad { get; set; }
        public string Unidad { get; set; }

        public Ingrediente(string Nombre, decimal Costo,int Cantidad, string Unidad) 
            : base(Nombre, Costo)
        {
            this.Cantidad = Cantidad;
            this.Unidad = Unidad;
        }
    }
}
