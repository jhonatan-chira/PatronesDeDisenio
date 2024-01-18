using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Estructurales
{
    // La interfaz del Componente base define operaciones que pueden ser alteradas por decoradores.
    public abstract class Component
    {
        public abstract string Operation();
    }

    // Los componentes concretos proporcionan implementaciones predeterminadas de las operaciones. 
    // Puede haber varias variaciones de estas clases.
    class ConcreteComponent : Component
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    // La clase Decorador base sigue la misma interfaz que los otros componentes.
    // El objetivo principal de esta clase es definir la interfaz envoltorio 
    // para todos los decoradores concretos. La implementación predeterminada del 
    // código empaquetado puede incluir un campo para almacenar un componente empaquetado y 
    // los medios para inicializarlo.
    abstract class Decorator : Component
    {
        protected Component _component;

        public Decorator(Component component)
        {
            this._component = component;
        }

        public void SetComponent(Component component)
        {
            this._component = component;
        }

        // El Decorador delega todo el trabajo al componente empaquetado.
        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    // Los decoradores concretos llaman al objeto envuelto y modifican su resultado en alguna manera.
    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component comp) : base(comp)
        {
        }

        // Los decoradores pueden llamar a la implementación principal de la operación, en lugar 
        // de llamar directamente al objeto envuelto. Este enfoque simplifica la
        // extensión de las clases de decorador.
        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    //  Los decoradores pueden ejecutar su comportamiento antes o después de la
    //  llamada a un objeto envuelto.
    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }

    public class Client
    {
        // El código del cliente funciona con todos los objetos que utilizan
        // la interfaz Component. De esta manera puede permanecer independiente
        // de las clases concretas de componentes con los que trabaja.
        public void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Client client = new Client();

    //        var simple = new ConcreteComponent();
    //        Console.WriteLine("Cliente: Obtengo un componente simple:");
    //        client.ClientCode(simple);
    //        Console.WriteLine();

    //        // ...y también los decoradores
    //        // Observe cómo los decoradores pueden envolver no solo componentes
    //        // simples sino también a otros decoradores.
    //        ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
    //        ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
    //        Console.WriteLine("Cliente: Ahora tengo un componente decorado:");
    //        client.ClientCode(decorator2);
    //    }
    //}
}
