using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    public class CaidoServerState : ServerState
    {
        public override void Respuesta()
        {
            Console.WriteLine("Respuesta 503");
        }
    }
}
