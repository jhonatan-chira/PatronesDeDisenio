using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Creacionales
{
    
    public sealed class Singleton
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton() { }

        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        // Finally, any singleton should define some business logic, which can
        // be executed on its instance.
        public void someBusinessLogic()
        {
            // ...
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // The client code.
    //        Singleton s1 = Singleton.GetInstance();
    //        Singleton s2 = Singleton.GetInstance();

    //        if (s1 == s2)
    //        {
    //            Console.WriteLine("Singleton works, both variables contain the same instance.");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Singleton failed, variables contain different instances.");
    //        }
    //    }
    //}
}
