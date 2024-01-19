using System;

namespace TemplateMethod
{
    // La Clase Abstracta define un método de plantilla que contiene una estructura
    // de algún algoritmo, compuesto por llamadas a operaciones primitivas
    // (generalmente) abstractas.
    //
    // Las subclases concretas deben implementar estas operaciones, pero dejan el
    // método de plantilla en sí intacto.
    abstract class ClaseAbstracta
    {
        // El método de plantilla define la estructura de un algoritmo.
        public void MetodoPlantilla()
        {
            this.OperacionBase1();
            this.OperacionesRequeridas1();     //Método abstracto a ser implementado por las subclases concretas.
            this.OperacionBase2();
            this.Gancho1();     //Implementación vacía
            this.OperacionRequerida2();
            this.OperacionBase3();
            this.Gancho2();
        }

        // Estas operaciones ya tienen implementaciones.
        protected void OperacionBase1()
        {
            Console.WriteLine("ClaseAbstracta dice: Estoy haciendo la mayor parte del trabajo");
        }

        protected void OperacionBase2()
        {
            Console.WriteLine("ClaseAbstracta dice: Pero dejo que las subclases anulen algunas operaciones");
        }

        protected void OperacionBase3()
        {
            Console.WriteLine("ClaseAbstracta dice: Pero de todos modos estoy haciendo la mayor parte del trabajo");
        }

        // Estas operaciones deben ser implementadas en las subclases.
        protected abstract void OperacionesRequeridas1();

        protected abstract void OperacionRequerida2();

        // Estos son "ganchos". Las subclases pueden anularlos, pero no es
        // obligatorio ya que los ganchos ya tienen una implementación predeterminada
        // (pero vacía). Los ganchos proporcionan puntos de extensión adicionales en
        // lugares cruciales del algoritmo.
        protected virtual void Gancho1() { }

        protected virtual void Gancho2() { }
    }

    // Las clases concretas deben implementar todas las operaciones abstractas de la
    // clase base. También pueden anular algunas operaciones con una
    // implementación predeterminada.
    class ClaseConcreta1 : ClaseAbstracta
    {
        protected override void OperacionesRequeridas1()
        {
            Console.WriteLine("ClaseConcreta1 dice: Implementé Operacion1");
        }

        protected override void OperacionRequerida2()
        {
            Console.WriteLine("ClaseConcreta1 dice: Implementé Operacion2");
        }
    }

    // Por lo general, las clases concretas anulan solo una fracción de las operaciones
    // de la clase base.
    class ClaseConcreta2 : ClaseAbstracta
    {
        protected override void OperacionesRequeridas1()
        {
            Console.WriteLine("ClaseConcreta2 dice: Implementé Operacion1");
        }

        protected override void OperacionRequerida2()
        {
            Console.WriteLine("ClaseConcreta2 dice: Implementé Operacion2");
        }

        protected override void Gancho1()
        {
            Console.WriteLine("ClaseConcreta2 dice: Gancho1 sobrescrito");
        }
    }

    class Cliente
    {
        // El código del cliente llama al método de plantilla para ejecutar el algoritmo.
        // El código del cliente no tiene que conocer la clase concreta de un objeto con el
        // que trabaja, siempre y cuando trabaje con objetos a través de la interfaz de
        // su clase base.
        public static void CodigoCliente(ClaseAbstracta claseAbstracta)
        {
            // ...
            claseAbstracta.MetodoPlantilla();
            // ...
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            Console.WriteLine("El mismo código de cliente puede trabajar con diferentes subclases:");

            Cliente.CodigoCliente(new ClaseConcreta1());

            Console.Write("\n");

            Console.WriteLine("El mismo código de cliente puede trabajar con diferentes subclases:");
            Cliente.CodigoCliente(new ClaseConcreta2());
        }
    }
}
