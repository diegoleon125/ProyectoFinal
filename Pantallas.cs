using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoFinal
{
    public class Pantallas
    {
        public static string[,] producto = new string[100, 300];
        public static float[,] precio = new float[100, 300];
        public static int[,] cantidad = new int[100, 300];
        public static string[] almacen = new string[100];
        public static int alm_contador = 1;
        public static int[] pdto_contador = new int[100];

        //Menú Principal
        public static int MenuPrincipal()
        {
            almacen[0] = "Tiendita";
            string texto = "==================================================\n" +
                "||\t\t\t\t\t\t||\n" +
                "||\tSistema de Inventario \"Mi Tiendita\"\t||\n" +
                "||\t\t\t\t\t\t||\n" +
                "==================================================\n" +
                "|| 1. Gestionar Productos\t\t\t||\n" +
                "|| 2. Gestionar Almacenes\t\t\t||\n" +
                "|| 3. Agregar y Extraer Productos\t\t||\n" +
                "==================================================\n";
            Console.Write(texto);
            int opcion = Operaciones.GetOpcion("Seleccione una opción y presione Enter: ", texto,3);
            return opcion;
        }
        //Menú Gestionar Productos
        public static int MenuGestionarProductos()
        {
            string texto = "--------------------------------------------------\n" +
                "||       Gestionar Productos - Mi Tiendita      ||\n" +
                "--------------------------------------------------\n" +
                "|| 1. Agregar Producto                          ||\n" +
                "|| 2. Eliminar Producto                         ||\n" +
                "|| 3. Modificar Producto                        ||\n" +
                "|| 4. Mostrar Inventario                        ||\n" +
                "|| 5. Volver al Menú Principal                  ||\n" +
                "--------------------------------------------------\n";
            Console.Write(texto);
            int opcion = Operaciones.GetOpcion("Seleccione una opcion: ", texto,5);
            if (opcion == 5) return 0;
            return opcion + 3;
        }
        //Menú Gestionar Almacenes
        public static int MenuGestionarAlmacenes()
        {
            string texto = "--------------------------------------------------\n" +
                "||       Gestionar Almacenes - Mi Tiendita      ||\n" +
                "--------------------------------------------------\n" +
                "|| 1. Agregar Almacén                           ||\n" +
                "|| 2. Eliminar Almacén                          ||\n" +
                "|| 3. Mostrar Almacenes                         ||\n" +
                "|| 4. Volver al Menú Principal                  ||\n" +
                "--------------------------------------------------\n";
            Console.Write(texto);
            int opcion = Operaciones.GetOpcion("Seleccione una opcion: ", texto, 4);
            if (opcion == 4) return 0;

            return opcion + 7;
        }
        //Menú Agregar y Extraer Productos
        public static int MenuAgregarYExtraerProductos()
        {
            string texto = "--------------------------------------------------\n" +
                "||  Agregar y Extraer Productos - Mi Tiendita   ||\n" +
                "--------------------------------------------------\n" +
                "|| 1. Ingresar Producto en Almacén              ||\n" +
                "|| 2. Extraer Producto de Almacén               ||\n" +
                "|| 3. Ver Stock Actual                          ||\n" +
                "|| 4. Volver al Menú Principal                  ||\n" +
                "--------------------------------------------------\n";
            Console.Write(texto);
            int opcion = Operaciones.GetOpcion("Seleccione una opción: ", texto, 4);
            if (opcion == 4) return 0;
            return opcion + 10;
               
        }

        //Pantalla para Agregar Producto 
        public static int AgregarProducto()
        {
            string texto = "===== Pantalla para Agregar Producto =====\n" +
                           "--------------------------------------------------\n";
            Console.Write(texto);
            producto[0, pdto_contador[0]] = Operaciones.GetString("Ingrese el nombre del producto: ");
            precio[0, pdto_contador[0]] = Operaciones.GetFloat("Ingrese el precio del producto: ", texto);
            cantidad[0, pdto_contador[0]] = Operaciones.GetEntero("Ingrese la cantidad de producto: ", texto);
            Operaciones.GetKey("Producto agregado exitosamente.");
            pdto_contador[0]++;
            return 1;
        }
        //Pantalla para Eliminar Producto 
        public static int EliminarProducto()
        {
            string texto = "===== Pantalla para Eliminar Producto =====\n" +
                           "--------------------------------------------------\n";
            Console.Write(texto);
            string productoAEliminar = Operaciones.GetString("Ingrese el nombre del producto a eliminar:");
            int posicion = -1;
            for (int i = 0; i < pdto_contador[0]; i++)
            {
                if (producto[0, i] == productoAEliminar)
                {
                    posicion = i;
                    break;
                }
            }
            if (posicion != -1)
            {    
                for (int i = posicion;i  < pdto_contador[0] -1;i++)
                {
                    producto[0,i] = producto[0,i+1];
                    precio[0,i] = precio[0,i+1];
                    cantidad[0, i] = cantidad[0, i + 1];
                }
                pdto_contador[0]--;
                Console.WriteLine("Producto eliminado exitosamente.");
            } 
            else
            {
                Console.WriteLine("Error producto no encontrado.");
            }    
            Console.ReadKey();
                return 1;
        }
        //Pantalla para Modificar Producto 
        public static int ModificarProducto()
        {
            string texto = "==== Pantalla para Modificar Producto ==== \n" +
                           "--------------------------------------------------\n";

            Console.Write(texto);
            string modificar = Operaciones.GetString("Ingresar el nombre del producto a modificar: ");
            int posicion = -1;
            for (int i = 0; i < pdto_contador[0]; i++)
            {
                if (producto[0, i] == modificar) posicion = i;
            }
                if (posicion == -1)
                {
                Operaciones.GetKey("Error: producto no encontrado");
                }
                else
                {
                precio[0, posicion] = Operaciones.GetFloat("Ingrese el nuevo precio: ", texto);
                cantidad[0, posicion] = Operaciones.GetEntero("Ingrese la nueva cantidad: ", texto);
                Operaciones.GetKey("Producto modificado exitosamente.");
                }
            return 1;
        }
        //Pantalla para Mostrar Inventario
        public static int MostrarInventario()
        {
            string texto = "===== Pantalla para Mostrar Inventario =====\n" +
                "--------------------------------------------------\n" +
                "Inventario Actual:\n";
            for (int i = 0; i < pdto_contador[0]; i++)
            {
                texto += "Producto " + (i+1) + ": " + producto[0,i] + " - ";
                texto += "Precio: $ " + precio[0,i] + " - ";
                texto += "Cantidad: " + cantidad[0,i] + "\n";
            }
            Console.Write(texto);
            Operaciones.GetKey("...");
            return 1;   
        }

        //Pantalla para Agregar Almacén
        public static int AgregarAlmacen()
        {
            string texto = "===== Pantalla para Agregar Almacén =====\n" +
                           "--------------------------------------------------\n";
            Console.Write(texto);
            almacen[alm_contador] = Operaciones.GetString("Ingrese el nombre del nuevo almacén: ");
            Operaciones.GetKey("Almacén agregado exitosamente.");
            alm_contador++;
            return 2;
        }
        //Pantalla para Eliminar Almacén
        public static int EliminarAlmacen()
        {
            string texto = "===== Pantalla para Eliminar Almacén =====\n" +
                           "--------------------------------------------------\n";
            Console.Write(texto);
            string nombre = Operaciones.GetString("Ingrese el nombre del almacén a eliminar: ");
            bool almacenEncontrado = false;

            for (int i = 0; i < alm_contador; i++)
            {
                if (almacen[i] == nombre)
                {
                    almacenEncontrado = true;
                    for (int j = i; j < alm_contador - 1; j++)
                    {
                        almacen[j] = almacen[j + 1];

                        for (int k = 0; k < pdto_contador[j + 1]; k++)
                        {
                            producto[j, k] = producto[j + 1, k];
                            precio[j, k] = precio[j + 1, k];
                            cantidad[j, k] = cantidad[j + 1, k];
                        }
                        pdto_contador[j] = pdto_contador[j + 1];
                    }
                    alm_contador--; 
                    i--; 
                }
            }
            if (almacenEncontrado)
            {
                Operaciones.GetKey("Almacén eliminado exitosamente.");
            }
            else
            {
                Console.Write("--------------------------------------------------\n");
                Console.Write("Almacén no encontrado.");
                Console.ReadKey();
            }
            return 2;
        }
        //Pantalla para Moestrar Almacén
        public static int MostrarAlmacen()
        {
            string texto = "===== Pantalla para Mostrar Almacenes =====\n" +
                "--------------------------------------------------\n" +
                "Lista de Almacenes:\n";
            for (int i = 1; i < alm_contador; i++)
            {
                texto += "Almacén "+(i)+ ": " + almacen[i]+"\n";
            }
            Console.Write(texto);
            Console.ReadKey();
            return 2;
        }
        //Pantalla para Ingresar Producto en Almanecén
        public static int IngresarProductoAlmacen()
        {
            string texto = "===== Pantalla para Ingresar Producto de Almacén =====\n" +
               "--------------------------------------------------\n";
            string texto1 = "";
            if (alm_contador == 1)
            {
                Operaciones.GetKey("Sin almacenes"); return 3;
            }
            for (int i = 1; i < alm_contador; i++)
            {
                texto1 += i + ". " + almacen[i] + "\n";
            }
            Console.Write(texto + texto1);
            int opcion1 = Operaciones.GetOpcion("Seleccione el almacén: ", texto + texto1, alm_contador - 1); //opcion1 = i
            string texto2 = "";
            if (pdto_contador[0] == 0)
            {
                Operaciones.GetKey("Sin producto"); return 3;
            }
            for (int i = 0; i < pdto_contador[0]; i++)
            {
                texto2 += (i + 1) + ". " + producto[0, i] + "\n";
            }
            Console.Write(texto2);
            int opcion2 = Operaciones.GetOpcion("Seleccione el producto a ingresar: ", texto + texto2, pdto_contador[0]); //opcion2 = j
            opcion2--;
            int pos = -1;
            for (int i = 0; i < pdto_contador[opcion1]; i++)
            {
                if (producto[opcion1, i] == producto[0, opcion2])
                {
                    pos = i;
                    break;
                }
            }
            int opcion3 = Operaciones.GetEntero("Ingrese la cantidad a ingresar: ", texto);
            if (opcion3 > cantidad[0, opcion2])
            {
                Operaciones.GetKey("Error: No hay suficiente cantidad en la tienda.");
                return 3;
            }
            else
            {
                if (pos == -1)
                {
                    pos = pdto_contador[opcion1];
                    pdto_contador[opcion1]++;
                    producto[opcion1, pos] = producto[0, opcion2];
                }
            }
            producto[opcion1, pos] = producto[0, opcion2];
            cantidad[opcion1, pos] += opcion3;
            cantidad[0, opcion2] -= opcion3;
            Operaciones.GetKey("Producto ingresado en el almacén exitosamente.");
            return 3;
        }
        //Pantalla para Extraer Producto de Almacén
        public static int ExtraerProductoAlmacen()
        {
            string texto = "===== Pantalla para Extraer Producto de Almacén =====\n" +
               "--------------------------------------------------\n";
            Console.Write(texto);
            if  (alm_contador == 1)
            {
                Operaciones.GetKey("Sin almacenes"); return 2;
            }

            for (int i = 1; i < alm_contador; i++)
            {
                texto += i + ". " + almacen[i] + "\n";
            }
            Console.Write(texto);
            int opcionAlmacen = Operaciones.GetOpcion("Seleccione el almacén: ", texto, alm_contador);
            string TextoProducto = "";
            if (pdto_contador[opcionAlmacen]== 0)
            {
                Operaciones.GetKey("Sin productos"); return 2;
            }
            for(int i = 1; i < alm_contador; i++)
            {
                TextoProducto += (i + 1) + ". " + producto[opcionAlmacen, i] + "\n";
            }
            Console.Write(TextoProducto);
            int opcionproducto = Operaciones.GetOpcion("Seleccione el producto a extraer: ", texto + TextoProducto, pdto_contador[opcionAlmacen]);
            opcionproducto--;
            int tiendapos = 1;
            for (int i = 0; i < pdto_contador[0]; i++)
            {
                if ( producto[0,1]== producto[opcionAlmacen,opcionproducto])
                {
                    tiendapos = i; 
                }
            }
            int cantidadAExtraer = Operaciones.GetEntero("Ingrese la cantidad a extraer: ", texto + TextoProducto);
            if (cantidad[opcionAlmacen, opcionproducto] >= cantidadAExtraer)
            {
                cantidad[opcionproducto,opcionAlmacen] -= cantidadAExtraer;
                cantidad[0, tiendapos] += cantidadAExtraer;
                Console.WriteLine("Producto extraído del almacén exitosamente.");
            }    
            else
            {
                Console.WriteLine("Error: No hay suficiente cantidad en el almacén.");
            }
            Console.ReadKey();
            return 3; 
        }
        //Pantalla para Ver Stock Actual
        public static int VerStockActual()
        {
            string texto = "===== Pantalla para Ver Stock Actual =====\n" +
                           "--------------------------------------------------\n" +
                           "Stock Actual en Todos los Almacenes:\n ";
            int contador = 1;

            for (int i = 1; i < alm_contador; i++)
            {
                for (int j = 0; j < pdto_contador[i]; j++)
                {
                    texto += "Producto " + contador + ": " + producto[i, j] + " - ";
                    texto += "Almacén: " + almacen[i] + " - ";
                    texto += "Cantidad: " + cantidad[i, j] + "\n";
                    contador++;
                }
            }
            Console.Write(texto);
            if (contador == 1)
            {
                Console.WriteLine("Sin stock");
            }
            Console.ReadKey();
            return 3;
        }
    }
}