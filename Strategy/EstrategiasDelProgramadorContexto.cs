using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class EstrategiasDelProgramadorContexto
    {
        private IProgramador oProgramador;

        public enum Comportamiento
        {
            PatronesDiseño, EscribirCodigo
        }

        public EstrategiasDelProgramadorContexto()
        {   //Por defecto
            this.oProgramador = new EstrategiaPatronesDiseño();
        }

        //public void EstablecerPatronesDiseño()
        //{   //oProgramadror se transforma en EstrategiaPatronesDiseño() gracias a que es una interface.
        //    this.oProgramador = new EstrategiaPatronesDiseño();
        //}

        //public void EstablecerEscribirCodigo()
        //{
        //    this.oProgramador = new EstrategiaEscribirCodigo();
        //}

        public void Programar(Comportamiento opcion)
        {
            switch (opcion)
            {
                case Comportamiento.PatronesDiseño:
                    {
                        this.oProgramador = new EstrategiaPatronesDiseño();
                    }
                    break;
                case Comportamiento.EscribirCodigo:
                    {
                        this.oProgramador = new EstrategiaEscribirCodigo();
                    }
                    break;
                default:
                    break;
            }

            this.oProgramador.Programar();
        }
    }
}
