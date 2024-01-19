namespace ChainOfResponsibility
{
    public class Program 
    { 

        // Interfaz para manejar solicitudes
        public interface IAprobador
        {
            void ManejarSolicitud(double monto);
            void EstablecerSiguienteAprobador(IAprobador siguiente);
        }

        // Clase base para los aprobadores
        public abstract class Aprobador : IAprobador
        {
            protected IAprobador SiguienteAprobador;

            public void EstablecerSiguienteAprobador(IAprobador siguiente)
            {
                SiguienteAprobador = siguiente;
            }

            public abstract void ManejarSolicitud(double monto);
        }

        // Nivel de autoridad: Supervisor
        public class Supervisor : Aprobador
        {
            public override void ManejarSolicitud(double monto)
            {
                if (monto <= 1000 && monto > 600)
                {
                    Console.WriteLine("Solicitud aprobada por el Supervisor.");
                }
                else if (SiguienteAprobador != null)
                {
                    SiguienteAprobador.ManejarSolicitud(monto);
                }
                else
                {
                    Console.WriteLine("Nadie puede manejar la solicitud.");
                }
            }
        }

        // Nivel de autoridad: Gerente
        public class Gerente : Aprobador
        {
            public override void ManejarSolicitud(double monto)
            {
                if (monto > 1000 && monto <= 5000)
                {
                    Console.WriteLine("Solicitud aprobada por el Gerente.");
                }
                else if (SiguienteAprobador != null)
                {
                    SiguienteAprobador.ManejarSolicitud(monto);
                }
                else
                {
                    Console.WriteLine("Nadie puede manejar la solicitud.");
                }
            }
        }

        // Nivel de autoridad: Director
        public class Director : Aprobador
        {
            public override void ManejarSolicitud(double monto)
            {
                if (monto > 5000)
                {
                    Console.WriteLine("Solicitud aprobada por el Director.");
                }
                else
                {
                    Console.WriteLine("Nadie puede manejar la solicitud.");
                }
            }
        }

        // Uso del patrón Chain of Responsibility
        class Programa
        {
            public static void Main(string[] args)
            {
                // Configurar la cadena de responsabilidad
                IAprobador supervisor = new Supervisor();
                IAprobador gerente = new Gerente();
                IAprobador director = new Director();

                supervisor.EstablecerSiguienteAprobador(gerente);
                gerente.EstablecerSiguienteAprobador(director);

                // Enviar solicitudes
                supervisor.ManejarSolicitud(800);     // Aprobada por el Supervisor
                supervisor.ManejarSolicitud(2500);    // Aprobada por el Gerente
                supervisor.ManejarSolicitud(10000);   // Aprobada por el Director
                supervisor.ManejarSolicitud(500);     // Nadie puede manejar la solicitud
            }
        }
    }
}