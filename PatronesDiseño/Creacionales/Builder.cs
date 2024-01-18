using PatronesDiseño.Estructurales;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace PatronesDiseño.Creacionales
{
    // La interfaz Builder especifica métodos para la creación de las diferentes partes
    // de los objetos Product2.
    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    // Las clases Concrete Builder siguen la interfaz Builder y proporcionan
    // implementaciones específicas de los pasos de construcción. Tu programa puede tener
    // varias variaciones de Builders, implementadas de manera diferente.
    public class ConcreteBuilder : IBuilder
    {
        private Product2 _product = new Product2();

        // Una instancia de builder recién creada debería contener un objeto de producto en blanco,
        // que se utiliza en el montaje posterior.
        public ConcreteBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            //Se utiliza para asegurarse de que un nuevo objeto de producto esté listo
            //para ser construido cada vez que se crea una nueva instancia de ConcreteBuilder
            _product = new Product2();
        }

        // Todos los pasos de producción trabajan con la misma instancia de producto.
        public void BuildPartA()
        {
            _product.Add("ParteA1");
        }

        public void BuildPartB()
        {
            _product.Add("ParteB1");
        }

        public void BuildPartC()
        {
            _product.Add("ParteC1");
        }

        // Los Constructores Concretos deben proporcionar sus propios métodos para
        // recuperar resultados. Esto se debe a que varios tipos de constructores pueden
        // crear productos completamente diferentes que no siguen la misma
        // interfaz. Por lo tanto, esos métodos no se pueden declarar en la interfaz
        // base Builder (al menos en un lenguaje de programación tipado estáticamente).
        //
        // Por lo general, después de devolver el resultado final al cliente, se espera que un constructor
        // esté listo para comenzar a producir otro producto.
        // Es por eso que es una práctica habitual llamar al método de reinicio al final
        // del cuerpo del método `GetProduct2`. Sin embargo, este comportamiento no es
        // obligatorio, y puedes hacer que tus constructores esperen una llamada explícita de reinicio
        // desde el código del cliente antes de desechar el resultado anterior.
        public Product2 GetProduct2()
        {
            Product2 resultado = _product;

            Reset();

            return resultado;
        }
    }

    // Tiene sentido usar el patrón Builder solo cuando tus productos son
    // bastante complejos y requieren una configuración extensa.
    //
    // A diferencia de otros patrones creacionales, diferentes constructores concretos pueden
    // producir productos no relacionados. En otras palabras, los resultados de varios constructores
    // pueden no seguir siempre la misma interfaz.
    public class Product2
    {
        private List<object> _partes = new List<object>();

        public void Add(string parte)
        {
            _partes.Add(parte);
        }

        public string ListarPartes()
        {
            string str = string.Empty;

            for (int i = 0; i < _partes.Count; i++)
            {
                str += _partes[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // eliminando la última ",c"

            return "Partes del Producto2: " + str + "\n";
        }
    }

    // El Director solo es responsable de ejecutar los pasos de construcción en un
    // orden o configuración específicos. Es útil al producir productos según un
    // orden o configuración específicos. Estrictamente hablando, la clase Director es
    // opcional, ya que el cliente puede controlar los constructores directamente.
    public class Director
    {
        private IBuilder _constructor;

        public IBuilder Constructor
        {
            set { _constructor = value; }
        }

        // El Director puede construir varias variaciones del producto utilizando los mismos
        // pasos de construcción.
        public void ConstruirProductoMinimamenteViable2()
        {
            _constructor.BuildPartA();
        }

        public void ConstruirProductoCompleto2()
        {
            _constructor.BuildPartA();
            _constructor.BuildPartB();
            _constructor.BuildPartC();
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            // El código del cliente crea un objeto constructor, lo pasa al
            // director y luego inicia el proceso de construcción. El resultado final
            // se obtiene del objeto constructor.
            var director = new Director();
            var constructor = new ConcreteBuilder();
            director.Constructor = constructor;

            Console.WriteLine("Producto básico estándar:");
            director.ConstruirProductoMinimamenteViable2();
            Console.WriteLine(constructor.GetProduct2().ListarPartes());

            Console.WriteLine("Producto completo estándar:");
            director.ConstruirProductoCompleto2();
            Console.WriteLine(constructor.GetProduct2().ListarPartes());

            // Recuerda, el patrón Builder se puede usar sin una clase Director.
            Console.WriteLine("Producto personalizado:");
            constructor.BuildPartA();
            constructor.BuildPartC();
            Console.Write(constructor.GetProduct2().ListarPartes());
        }
    }
}
