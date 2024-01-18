using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ProxyServidor : IServidor
    {
        private Servidor _servidor;

        public ProxyServidor()
        {
            _servidor = new Servidor();
        }

        public void Request()
        {
            Console.WriteLine("Manejo de petición");
            Console.WriteLine("Escribir log");
            _servidor.Request();
            Console.WriteLine("OK");
        }
    }
}
