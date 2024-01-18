using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class PastelComposite : Component
    {
        private List<Component> ingredientes = new List<Component>();

        public decimal CostoTotal
        {
            get
            {
                decimal costo = 0;
                foreach (var oElemento in ingredientes)
                {
                    if (oElemento.GetType().Name == "PastelComposite")
                        costo += ((PastelComposite)oElemento).CostoTotal;
                    else
                        costo += oElemento.Costo;
                }
               
                return costo;

            }
        }

        public void Add(Component oElemento)
        {
            ingredientes.Add(oElemento);
        }

        public void Remove(Component oElemento)
        {
            ingredientes.Remove(oElemento);
        }

        public PastelComposite(string Nombre, decimal Costo=0) : base(Nombre, Costo)
        {
        }


    }
}
