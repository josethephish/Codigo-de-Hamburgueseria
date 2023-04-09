using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_de_Hamburgueseria
{
    internal class Producto
    {

        static int ultimoId = 0;
        public int Id { get; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(string nombre, double precio)
        {
            Id = ++ultimoId;
            Nombre = nombre;
            Precio = precio;
        }

        public void VerProducto()
        {
            Console.Write("{0,-5}", Id);
            Console.Write("{0,-20}", Nombre);
            Console.Write("{0,10}", Precio);
            Console.WriteLine();
        }

        public void ModificarProducto(string nuevoNombre, double nuevoPrecio)
        {
            Nombre = nuevoNombre;
            Precio = nuevoPrecio;
        }
    }
}
