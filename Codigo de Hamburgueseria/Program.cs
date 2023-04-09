using Codigo_de_Hamburgueseria;
using System;
using System.Collections.Generic;



class Program
{
   static List <Producto> productos = new List<Producto>();
   static List <Pedido> pedidos = new List<Pedido>();

    static void Main(string[] args)
    {

        productos.Add(new Producto("Hamburguesa sencilla",150));
        productos.Add(new Producto("Hamburguesa doble", 250));
        productos.Add(new Producto("Hamburguesa con queso", 200));
        productos.Add(new Producto("Hamburguesa con bacon", 250));
        productos.Add(new Producto("Hamburguesa con huevo", 200));
        productos.Add(new Producto("Papas Fritas Pequeñas ", 70));
        productos.Add(new Producto("Papas Fritas Grandes ", 150));
        productos.Add(new Producto("Aros de Cebolla", 100));
        productos.Add(new Producto("Nuggets de Pollo", 100));
        productos.Add(new Producto("Enslada", 100));
        productos.Add(new Producto("Hamburguesa sencilla", 150));
        productos.Add(new Producto("Refresco", 50));
        productos.Add(new Producto("Botella de Agua", 30));
        productos.Add(new Producto("Batido de Frutas", 80));
        productos.Add(new Producto("Malteada", 100));

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║           Bienvenido(a) a la hamburguesería!         ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════╣");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("║ [1] Ver Productos                                    ║");
            Console.WriteLine("║ [2] Agregar producto                                 ║");
            Console.WriteLine("║ [3] Modificar producto                               ║");
            Console.WriteLine("║ [4] Eliminar producto                                ║");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("║ [5] Ver pedidos                                      ║");
            Console.WriteLine("║ [6] Agregar pedido                                   ║");
            Console.WriteLine("║ [7] Modificar pedido                                 ║");
            Console.WriteLine("║ [8] Eliminar pedido                                  ║");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("║ [9] Salir                                            ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.Write("Ingrese la opción deseada: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Productos Existente:");
                    foreach (Producto producto in productos)
                    {
                        producto.VerProducto();
                        Console.WriteLine();
                    }
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();

                    break;
                case 2:

                    

                    Console.WriteLine("Ingrese el nombre:");
                    string nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese el precio:");
                    double precio = double.Parse(Console.ReadLine());

                    Producto nuevoProducto = new Producto(nombre, precio);
                    productos.Add(nuevoProducto);

                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();

                    break;
                case 3:

                    Console.WriteLine("Ingrese el ID:");
                    int idMoficiar = int.Parse(Console.ReadLine());
                    foreach (Producto producto in productos)
                    {
                        if (producto.Id == idMoficiar)
                        {
                            Console.WriteLine("Ingrese el nuevo nombre del producto:");
                            string nuevoNombre = Console.ReadLine();

                            Console.WriteLine("Ingrese el nuevo precio del producto:");
                            double nuevoPrecio = double.Parse(Console.ReadLine());

                            producto.ModificarProducto(nuevoNombre, nuevoPrecio);

                            Console.WriteLine("El producto se ha modificado exitosamente.");

                            Console.WriteLine("Presiona cualquier tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    break;
                case 4:

                    Console.WriteLine("Ingrese el ID:");
                    int idEliminar = int.Parse(Console.ReadLine());
                    foreach (Producto producto in productos)
                    {
                        if (producto.Id == idEliminar)
                        {
                            productos.Remove(producto);

                            Console.WriteLine("El producto se ha eliminado exitosamente.");

                            Console.WriteLine("Presiona cualquier tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    break;
                case 5:
                    int existencia = pedidos.Count();
                    if(existencia>0)
                    {
                        Console.WriteLine("Pedidos existentes:");
                    foreach (Pedido pedido in pedidos)
                    {
                        pedido.VerPedido();
                        Console.WriteLine();
                    }
                    }
                    else
                    {
                        Console.WriteLine("No hay pedidos existentes");
                    }
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;


                case 6: // hacer pedido
                    List<Producto> productosPedido = new List<Producto>();
                    Console.WriteLine("Agregar nuevo pedido");
                    Console.WriteLine("Ingrese el nombre del cliente:");
                    string nombreCliente = Console.ReadLine();
                    Pedido nuevoPedido = new Pedido(nombreCliente, productosPedido); 
                    bool agregarProductos = true;
                    while (agregarProductos)
                    {
                        

                        Console.WriteLine("Seleccione un producto por su ID:");
                        foreach (Producto producto in productos)
                        {
                            producto.VerProducto();
                            Console.WriteLine();
                        }
                        int idProducto = int.Parse(Console.ReadLine());
                        Producto productoSeleccionado = productos.Find(p => p.Id == idProducto);
                        Console.WriteLine("Ingrese la cantidad:");
                        int cantidad = int.Parse(Console.ReadLine());
                        nuevoPedido.AgregarProducto(productoSeleccionado);
                        Console.WriteLine("Producto agregado al pedido.");
                        Console.WriteLine("¿Desea agregar otro producto? (S/N)");
                        string respuesta = Console.ReadLine();
                        if (respuesta.ToUpper() != "S")
                        {
                            agregarProductos = false;
                        }
                    }
                    pedidos.Add(nuevoPedido);
                    Console.WriteLine("Pedido registrado exitosamente.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 7:
                    Console.WriteLine("Modificar pedido");
                    Console.Write("Ingrese el ID del pedido a modificar: ");
                    int idPedidoModificar = int.Parse(Console.ReadLine());

                    // Buscar el pedido por ID
                    Pedido pedidoModificar = null;
                    foreach (Pedido pedido in pedidos)
                    {
                        if (pedido.Id == idPedidoModificar)
                        {
                            pedidoModificar = pedido;
                            break;
                        }
                    }

                    // Verificar si el pedido existe
                    if (pedidoModificar == null)
                    {
                        Console.WriteLine("El pedido no existe");
                    }
                    else
                    {
                        // Mostrar detalles del pedido
                        Console.WriteLine("Detalle del pedido a modificar:");
                        pedidoModificar.VerPedido();

                        // Preguntar qué se quiere modificar
                        Console.WriteLine("Ingrese los nuevos datos del pedido:");

                        Console.Write("Cliente (dejar en blanco para no modificar): ");
                        string nuevoCliente = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevoCliente))
                        {
                            pedidoModificar.Cliente = nuevoCliente;
                        }

                        Console.Write("Agregar producto (S/N): ");
                        string agregarProducto = Console.ReadLine();
                        if (agregarProducto.ToUpper() == "S")
                        {
                            Console.WriteLine("Seleccione el producto a agregar:");
                            foreach (Producto producto in productos)
                            {
                                producto.VerProducto();
                            }
                            Console.Write("ID del producto a agregar: ");
                            int idProductoAgregar = int.Parse(Console.ReadLine());

                            Producto productoAgregar = null;
                            foreach (Producto producto in productos)
                            {
                                if (producto.Id == idProductoAgregar)
                                {
                                    productoAgregar = producto;
                                    break;
                                }
                            }

                            if (productoAgregar == null)
                            {
                                Console.WriteLine("El producto no existe");
                            }
                            else
                            {
                                pedidoModificar.AgregarProducto(productoAgregar);
                                Console.WriteLine("Producto agregado al pedido");
                            }
                        }

                        Console.Write("Eliminar producto (S/N): ");
                        string eliminarProducto = Console.ReadLine();
                        if (eliminarProducto.ToUpper() == "S")
                        {
                            Console.WriteLine("Seleccione el producto a eliminar:");
                            foreach (Producto producto in pedidoModificar.Productos)
                            {
                                producto.VerProducto();
                            }
                            Console.Write("ID del producto a eliminar: ");
                            int idProductoEliminar = int.Parse(Console.ReadLine());

                            Producto productoEliminar = null;
                            foreach (Producto producto in pedidoModificar.Productos)
                            {
                                if (producto.Id == idProductoEliminar)
                                {
                                    productoEliminar = producto;
                                    break;
                                }
                            }

                            if (productoEliminar == null)
                            {
                                Console.WriteLine("El producto no existe en el pedido");
                            }
                            else
                            {
                                pedidoModificar.EliminarProducto(productoEliminar);
                                Console.WriteLine("Producto eliminado del pedido");
                            }
                        }

                        Console.WriteLine("Pedido modificado:");
                        pedidoModificar.VerPedido();
                    }
                    break;


                case 8:
                    Console.WriteLine("Ingrese el ID del pedido que desea eliminar:");
                    int ideliminar = int.Parse(Console.ReadLine());

                    Pedido pedidoAEliminar = pedidos.FirstOrDefault(p => p.Id == ideliminar);
                    if (pedidoAEliminar != null)
                    {
                        pedidos.Remove(pedidoAEliminar);
                        Console.WriteLine("El pedido ha sido eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ningún pedido con el ID ingresado.");
                    }
                    break;


                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
    }

    }
