using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Estructurales
{
    // La clase Facade proporciona una interfaz simple para la lógica compleja de uno 
    // o varios subsistemas. The Facade delega las solicitudes del cliente al 
    // objetos apropiados dentro del subsistema. La Fachada también es responsable 
    // para gestionar su ciclo de vida. Todo esto protege al cliente de la 
    // complejidad no deseada del subsistema.
    public class Facade
    {
        protected Subsystem1 _subsystem1;

        protected Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            this._subsystem1 = subsystem1;
            this._subsystem2 = subsystem2;
        }

        // Los métodos de Facade son atajos convenientes para la sofisticada 
        // funcionalidad de los subsistemas. Sin embargo, los clientes sólo llegan a un 
        // fracción de las capacidades de un subsistema.
        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += this._subsystem1.operation1();
            result += this._subsystem2.operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += this._subsystem1.operationN();
            result += this._subsystem2.operationZ();
            return result;
        }
    }

    // El Subsistema puede aceptar solicitudes ya sea de fachada o del cliente 
    // directamente. En cualquier caso, para el Subsistema, la Fachada es un 
    // cliente, y no forma parte del Subsistema.
    public class Subsystem1
    {
        public string operation1()
        {
            return "Subsystem1: Ready!\n";
        }

        public string operationN()
        {
            return "Subsystem1: Go!\n";
        }
    }

    // Algunas fachadas pueden funcionar con múltiples subsistemas al mismo tiempo.
    public class Subsystem2
    {
        public string operation1()
        {
            return "Subsystem2: Get ready!\n";
        }

        public string operationZ()
        {
            return "Subsystem2: Fire!\n";
        }
    }


    //class Client
    //{
    //    // El código del cliente trabaja con subsistemas complejos a través de un simple 
    //    // interfaz proporcionada por Facade. Cuando una fachada gestiona el ciclo de vida 
    //    // del subsistema, es posible que el cliente ni siquiera sepa sobre la existencia 
    //    // del subsistema. Este enfoque le permite mantener la complejidad bajo control.
    //    public static void ClientCode(Facade facade)
    //    {
    //        Console.Write(facade.Operation());
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // Es posible que el código del cliente ya tenga algunos de los objetos del subsistema 
    //        // creado. En este caso, podría valer la pena inicializar el 
    //        // Fachada con estos objetos en lugar de dejar que la Fachada cree nuevas instancias.
    //        Subsystem1 subsystem1 = new Subsystem1();
    //        Subsystem2 subsystem2 = new Subsystem2();
    //        Facade facade = new Facade(subsystem1, subsystem2);
    //        Client.ClientCode(facade);
    //    }
    //}
}
