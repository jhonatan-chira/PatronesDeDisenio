using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class EstrategiaEscribirCodigo : IProgramador
    {
        public void Programar()
        {
            Console.WriteLine("Tipear código con buenas prácticas.");
        }
    }
}
