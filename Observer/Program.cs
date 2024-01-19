using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    public interface IObservador
    {
        // Recibir actualización del sujeto
        void Actualizar(ISujeto sujeto);
    }

    public interface ISujeto
    {
        // Adjuntar un observador al sujeto.
        void Adjuntar(IObservador observador);

        // Desvincular un observador del sujeto.
        void Desvincular(IObservador observador);

        // Notificar a todos los observadores sobre un evento.
        void Notificar();
    }

    // El Sujeto posee un estado importante y notifica a los observadores cuando
    // el estado cambia.
    public class Sujeto : ISujeto
    {
        // Por simplicidad, el estado del Sujeto, esencial para todos los
        // suscriptores, se almacena en esta variable.
        public int Estado { get; set; } = 0;

        // Lista de suscriptores. En la vida real, la lista de suscriptores puede
        // almacenarse de manera más completa (categorizada por tipo de evento, etc.).
        private List<IObservador> _observadores = new List<IObservador>();

        // Métodos de gestión de suscripción.
        public void Adjuntar(IObservador observador)
        {
            Console.WriteLine("Sujeto: Se adjuntó un observador.");
            this._observadores.Add(observador);
        }

        public void Desvincular(IObservador observador)
        {
            this._observadores.Remove(observador);
            Console.WriteLine("\nSujeto: Se desvinculó un observador.");
        }

        // Dispara una actualización en cada suscriptor.
        public void Notificar()
        {
            Console.WriteLine("Sujeto: Notificando a los observadores...");

            foreach (var observador in _observadores)
            {   //(this) permite que el observador acceda a los detalles del Sujeto
                observador.Actualizar(this);
            }
        }

        // Por lo general, la lógica de suscripción es solo una fracción de lo que un
        // Sujeto realmente puede hacer. Los Sujetos comúnmente tienen alguna lógica
        // empresarial importante, que activa un método de notificación cuando algo
        // importante está a punto de suceder (o después).
        public void AlgunaLogicaDeNegocios()
        {
            Console.WriteLine("\nSujeto: Estoy haciendo algo importante.");
            this.Estado = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Sujeto: Mi estado acaba de cambiar a: " + this.Estado);
            this.Notificar();
        }
    }

    // Observadores Concretos reaccionan a las actualizaciones emitidas por el
    // Sujeto al que estuvieron adjuntados.
    class ObservadorConcretoA : IObservador
    {
        public void Actualizar(ISujeto sujeto)
        {
            //(sujeto as Sujeto) realiza una conversión explícita del tipo del objeto a Sujeto.
            //Esto se hace porque la interfaz ISujeto no tiene la propiedad Estado, pero Sujeto sí la tiene.
            if ((sujeto as Sujeto).Estado < 3)
            {
                Console.WriteLine("ObservadorConcretoA: Reaccionó al evento.");
            }
        }
    }

    class ObservadorConcretoB : IObservador
    {
        public void Actualizar(ISujeto sujeto)
        {
            if ((sujeto as Sujeto).Estado == 0 || (sujeto as Sujeto).Estado >= 2)
            {
                Console.WriteLine("ObservadorConcretoB: Reaccionó al evento.");
            }
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            // Código del cliente.
            var sujeto = new Sujeto();
            var observadorA = new ObservadorConcretoA();
            sujeto.Adjuntar(observadorA);

            var observadorB = new ObservadorConcretoB();
            sujeto.Adjuntar(observadorB);

            sujeto.AlgunaLogicaDeNegocios();
            sujeto.AlgunaLogicaDeNegocios();

            sujeto.Desvincular(observadorB);

            sujeto.AlgunaLogicaDeNegocios();
        }
    }
}
