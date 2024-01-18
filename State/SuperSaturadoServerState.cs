using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class SuperSaturadoServerState : ServerState
    {
        public override void Respuesta()
        {
            Task.Delay(1000);
            Console.WriteLine("Respuesta 200 con un delaye de 1000");
        }
    }
}
