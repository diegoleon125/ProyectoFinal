﻿using System;
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


        //Menus
        public static int MenuPrincipal()
        {
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
            int opcion = Operaciones.GetOpcion("Seleccione una opción y presione Enter:", texto,3);
            return opcion;
        }
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
            int opcion = Operaciones.GetOpcion("Seleccione una opcion: ", texto, 4);
            if (opcion == 4) return 0;
            return opcion + 10;
               
        }

        //Menu-Gestionar Productos
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
        //Menu-Eliminar Productos
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

        public static int ModificarProducto()
        {
            string texto = "==== Pantalla para Modificar Prodcto ==== \n" +
                           "--------------------------------------------------\n" +
                           "Ingrese el nombre del producto a modificar: ";
            Console.Write(texto);
            string modificar = Console.ReadLine();
            int posicion = 0;
            for (int i = 0; i < pdto_contador[0]; i++)
            {
                if (producto[0, i] == modificar) posicion = i;
            }
            string texto1 = "Ingrese el nuevo precio: ";
            Console.Write(texto1);
            precio[0, posicion] = float.Parse(Console.ReadLine());
            string texto2 = "Ingrese la nueva cantidad: ";
            Console.Write(texto2);
            cantidad[0, posicion] = int.Parse(Console.ReadLine());
            string texto3 = "--------------------------------------------------\n" +
                            "Producto modificado exitosamente.";
            Console.Write(texto3);
            Console.ReadKey();
            return 1;

        }
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

        //Menu-Gestionar Almacenes
        public static int AgregarAlmacen()
        {
            almacen[0] = "Tiendita";
            string texto = "===== Pantalla para Agregar Almacén =====\n"+
                           "--------------------------------------------------\n"+
                           "Ingrese el nombre del nuevo almacén: ";
            Console.Write(texto);
            almacen[alm_contador]= Console.ReadLine();
            Operaciones.GetKey("Almacén agregado exitosamente.");
            alm_contador++;
            return 2;
        }
        public static int EliminarAlmacen()
        {
            string texto = "===== Pantalla para Eliminar Almacén =====\n" +
                           "--------------------------------------------------\n" +
                           "Ingrese el nombre del almacén a eliminar: ";
            Console.Write(texto);
            string nombre = Console.ReadLine();
            bool eliminar = false;
            for (int i = 0; i < alm_contador; i++)
            {
                if (almacen[i] == nombre) eliminar = true;
                if (eliminar) almacen[i] = almacen[i + 1];
            }
            if (eliminar) alm_contador--;
            Operaciones.GetKey("Almacén eliminado exitosamente.");
            return 2;
        }
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

        //Menu-Agregar y Extraer Productos
        public static int IngresarProductoAlmacen()
        {
            string texto = Operaciones.SetTitulo("Pantalla para Ingresar Producto en Almacén");
            for (int i = 1; i < alm_contador; i++)
            {
                texto += i + ". " + almacen[i] + "\n";
            }
            Console.Write(texto);
            int opcion1 = Operaciones.GetOpcion("Seleccione el almacén: ", texto, alm_contador);
            string texto1 = "";
            for (int i = 0; i < pdto_contador[0]; i++)
            {
                texto1 += i + ". " + producto[0, i] + "\n";
            }
            Console.Write(texto1);
            int opcion2 = Operaciones.GetOpcion("Seleccione el producto a ingresar: ", texto + texto1, pdto_contador[0]);
            producto[opcion1, opcion2] = producto[0, opcion2];
            int opcion3 = Operaciones.GetOpcion("Ingrese la cantidad a ingresar: ", texto + texto1, cantidad[0, opcion2]);
            cantidad[opcion1, opcion2] += opcion3;
            cantidad[0, opcion2] -= opcion3;
            Operaciones.GetKey("Producto ingresado en el almacén exitosamente.");
            return 3;
        }

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
            Console.ReadKey();


            return 3;
        }

    }
}
