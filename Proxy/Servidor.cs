using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Servidor : IServidor
    {
        public void Request()
        {
            Console.WriteLine("Solicitud al servidor real");
        }
    }
}
