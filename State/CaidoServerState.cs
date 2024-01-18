using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class CaidoServerState : ServerState
    {
        public override void Respuesta()
        {
            Console.WriteLine("Respuesta 503");
        }
    }
}
