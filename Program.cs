using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            while (opcion != -1)
            {
                Console.Clear();
                switch (opcion)
                {
                    //Menus
                    case 0: opcion = Pantallas.MenuPrincipal();
                        break;
                    case 1: opcion = Pantallas.MenuGestionarProductos();
                        break;
                    case 2: opcion = Pantallas.MenuGestionarAlmacenes(); 
                        break;
                    case 3: opcion = Pantallas.MenuAgregarYExtraerProductos(); 
                        break;

                    //Menu-Gestionar Productos
                    case 4:
                        opcion = Pantallas.AgregarProducto();
                        break;
                    case 5:
                            opcion = Pantallas.EliminarProducto();
                        break;
                    case 6: opcion = Pantallas.ModificarProducto();
                        break;
                    case 7: opcion = Pantallas.MostrarInventario();
                        break;

                    //Menu-Gestionar Almacenes
                    case 8: opcion = Pantallas.AgregarAlmacen();
                        break;
                    case 9: opcion = Pantallas.EliminarAlmacen();
                        break;
                    case 10: opcion = Pantallas.MostrarAlmacen();
                        break;

                    //Menu-Agregar y Extraer Productos
                    case 11: opcion = Pantallas.IngresarProductoAlmacen();
                        break;
                    //case 12: opcion = Pantallas.ExtraerProductoAlmacen(); break;
                    case 13: opcion = Pantallas.VerStockActual(); 
                        break;
                }
            }

        }
    }
}
