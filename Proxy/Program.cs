using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IServidor servidor = new ProxyServidor();
            servidor.Request();
        }
    }
}