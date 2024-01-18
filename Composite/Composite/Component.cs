using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    abstract class Component
    {
        public string Nombre { get; set; }
        public decimal Costo { get; set; }

        public Component(string Nombre, decimal Costo)
        {
            this.Nombre = Nombre;
            this.Costo = Costo;
        }
    }
}
