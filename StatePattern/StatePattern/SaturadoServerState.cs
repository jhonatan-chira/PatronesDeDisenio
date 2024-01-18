using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class SaturadoServerState : ServerState
    {
        public override void Respuesta()
        {
            Task.Delay(500);
            Console.WriteLine("Respuesta 200 con un delaye de 500");
        }
    }
}
