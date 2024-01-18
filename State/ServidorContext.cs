using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class ServidorContext
    {
        private ServerState state;

        public ServerState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public void AtenderSolicitud()
        {
            state.Respuesta();
        }
    }
}
