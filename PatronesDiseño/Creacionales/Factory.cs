using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Creacionales
{

    // La clase Product es la clase base para todos los productos.
    abstract class Product
    {
        public abstract void Operation();
    }

    // La clase ConcreteProductA es una de las clases concretas que implementa la clase Product.
    class ConcreteProductA : Product
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteProductA.Operation()");
        }
    }

    // La clase ConcreteProductB es otra de las clases concretas que implementa la clase Product.
    class ConcreteProductB : Product
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteProductB.Operation()");
        }
    }

    // La clase Creator es la clase base para la fábrica.
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    // La clase ConcreteCreatorA es una de las clases concretas que implementa la clase Creator.
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    // La clase ConcreteCreatorB es otra de las clases concretas que implementa la clase Creator.
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Ejemplo de patrón de diseño Simple Factory\n");

    //        // Creamos una instancia de ConcreteCreatorA.
    //        Creator creatorA = new ConcreteCreatorA();
    //        Console.WriteLine("Instanciando ConcreteCreatorA...");
    //        Product productA = creatorA.FactoryMethod();
    //        productA.Operation();

    //        // Creamos una instancia de ConcreteCreatorB.
    //        Creator creatorB = new ConcreteCreatorB();
    //        Console.WriteLine("Instanciando ConcreteCreatorB...");
    //        Product productB = creatorB.FactoryMethod();
    //        productB.Operation();

    //        Console.ReadKey();
    //    }
    //}

}
