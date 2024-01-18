using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    class DisponibleServerState : ServerState
    {
        public override void Respuesta()
        {
            Console.WriteLine("Respuesta 200");
        }
    }
}
