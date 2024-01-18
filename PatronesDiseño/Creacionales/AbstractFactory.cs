using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Creacionales
{
    using System;

    // Interfaz abstracta para la fábrica
    public interface IUIFactory
    {
        public IButton CreateButton();
        public IWindow CreateWindow();
    }

    // Interfaz para el producto Botón
    public interface IButton
    {
        void Render();
    }

    // Interfaz para el producto Ventana
    public interface IWindow
    {
        void Render();
    }

    // Implementación concreta de la fábrica para Windows
    public class WindowsFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public IWindow CreateWindow()
        {
            return new WindowsWindow();
        }
    }

    // Implementación concreta de la fábrica para macOS
    public class MacOSFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new MacOSButton();
        }

        public IWindow CreateWindow()
        {
            return new MacOSWindow();
        }
    }

    // Implementación concreta del producto Botón para Windows
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Renderizando botón estilo Windows");
        }
    }

    // Implementación concreta del producto Ventana para Windows
    public class WindowsWindow : IWindow
    {
        public void Render()
        {
            Console.WriteLine("Renderizando ventana estilo Windows");
        }
    }

    // Implementación concreta del producto Botón para macOS
    public class MacOSButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Renderizando botón estilo macOS");
        }
    }

    // Implementación concreta del producto Ventana para macOS
    public class MacOSWindow : IWindow
    {
        public void Render()
        {
            Console.WriteLine("Renderizando ventana estilo macOS");
        }
    }

    //Cliente que utiliza el patrón Factory
    //class Program
    //{
    //    static void Main()
    //    {
    //        // Seleccionamos la fábrica para Windows
    //        IUIFactory windowsFactory = new WindowsFactory();

    //        // Creamos productos usando la fábrica para Windows
    //        IButton windowsButton = windowsFactory.CreateButton();
    //        IWindow windowsWindow = windowsFactory.CreateWindow();

    //        // Renderizamos los productos
    //        windowsButton.Render();
    //        windowsWindow.Render();

    //        // Repetimos el proceso para macOS
    //        IUIFactory macOSFactory = new MacOSFactory();
    //        IButton macOSButton = macOSFactory.CreateButton();
    //        IWindow macOSWindow = macOSFactory.CreateWindow();

    //        macOSButton.Render();
    //        macOSWindow.Render();
    //    }
    //}
}

