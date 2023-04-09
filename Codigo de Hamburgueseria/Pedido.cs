using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_de_Hamburgueseria
{
    internal class Pedido
    {
        static int ultimoId = 0;
        public int Id { get; }
        public string Cliente { get; set; }
        public List<Producto> Productos { get; set; }

        public Pedido(string cliente, List<Producto> productos)
        {
            Id = ++ultimoId;
            Cliente = cliente;
            Productos = productos;
        }

        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
        }

        public void EliminarProducto(Producto producto)
        {
            Productos.Remove(producto);
        }

        public double CalcularTotal()
        {
            double total = 0;
            foreach (Producto producto in Productos)
            {
                total += producto.Precio;
            }
            return total;
        }

        public void VerPedido()
        {
            Console.WriteLine("ID del pedido: {0}", Id);
            Console.WriteLine("Cliente: {0}", Cliente);
            Console.WriteLine("Productos:");
            foreach (Producto producto in Productos)
            {
                Console.WriteLine("- {0} {1}", producto.Nombre, producto.Precio);
            }
            Console.WriteLine("Total: {0}", CalcularTotal());
        }
        public void ModificarPedido(string nuevoCliente, List<Producto> nuevosProductos)
        {
            Cliente = nuevoCliente;
            Productos = nuevosProductos;
        }
    }

    }


