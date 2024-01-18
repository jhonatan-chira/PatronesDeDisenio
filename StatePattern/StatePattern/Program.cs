using System;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ServidorContext oServidor = new ServidorContext();
            oServidor.State = new DisponibleServerState();

            oServidor.AtenderSolicitud();

            oServidor.State = new SaturadoServerState();
            oServidor.AtenderSolicitud();
            oServidor.AtenderSolicitud();

            oServidor.State = new SuperSaturadoServerState();
            oServidor.AtenderSolicitud();
            oServidor.AtenderSolicitud();

            oServidor.State = new CaidoServerState();
            oServidor.AtenderSolicitud();
            oServidor.AtenderSolicitud();

            oServidor.State = new DisponibleServerState();
            oServidor.AtenderSolicitud();
            oServidor.AtenderSolicitud();
        }
    }
}
