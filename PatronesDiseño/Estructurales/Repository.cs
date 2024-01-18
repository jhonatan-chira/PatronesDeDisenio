using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Estructurales
{
    // Definición de la entidad Producto
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }

    // Interfaz del repositorio
    public interface IProductoRepository
    {
        Producto ObtenerPorId(int id);
        IEnumerable<Producto> ObtenerTodos();
        void AgregarProducto(Producto producto);
    }

    // Implementación concreta del repositorio
    public class ProductoRepository : IProductoRepository
    {
        private List<Producto> productos;

        public ProductoRepository()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public Producto ObtenerPorId(int id)
        {
            return productos.Find(p => p.Id == id);
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return productos;
        }
    }

    //class Program
    //{
    //    static void Main()
    //    {
    //        // Crear instancia del repositorio
    //        IProductoRepository productoRepository = new ProductoRepository();

    //        // Agregar algunos productos
    //        productoRepository.AgregarProducto(new Producto { Id = 1, Nombre = "Producto1", Precio = 19.99m });
    //        productoRepository.AgregarProducto(new Producto { Id = 2, Nombre = "Producto2", Precio = 29.99m });

    //        // Obtener y mostrar todos los productos
    //        Console.WriteLine("Lista de Productos:");
    //        foreach (var producto in productoRepository.ObtenerTodos())
    //        {
    //            Console.WriteLine($"Id: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}");
    //        }

    //        // Obtener y mostrar un producto por ID
    //        int idBuscado = 1;
    //        Producto productoEncontrado = productoRepository.ObtenerPorId(idBuscado);
    //        Console.WriteLine($"\nProducto con Id {idBuscado}: {productoEncontrado.Nombre}, Precio: {productoEncontrado.Precio}");
    //    }
    //}
}
