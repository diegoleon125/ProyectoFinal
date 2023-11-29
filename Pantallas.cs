using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Pantallas
    {
        public static int contador1 = 0;
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
            string texto = "--------------------------------------------------\r\n" +
                "||       Gestionar Productos - Mi Tiendita      ||\r\n" +
                "--------------------------------------------------\r\n" +
                "|| 1. Agregar Producto                          ||\r\n" +
                "|| 2. Eliminar Producto                         ||\r\n" +
                "|| 3. Modificar Producto                        ||\r\n" +
                "|| 4. Mostrar Inventario                        ||\r\n" +
                "|| 5. Volver al Menú Principal                  ||\r\n" +
                "--------------------------------------------------\r\n";
            Console.Write(texto);
            int opcion = Operaciones.GetOpcion("Seleccione una opcion: ", texto,5);
            if (opcion == 5) return 0;
            return opcion+3;
        }
        public static int MenuGestionarAlmacenes()
        {
            string texto = "--------------------------------------------------\r\n" +
                "||       Gestionar Almacenes - Mi Tiendita      ||\r\n" +
                "--------------------------------------------------\r\n" +
                "|| 1. Agregar Almacén                           ||\r\n" +
                "|| 2. Eliminar Almacén                          ||\r\n" +
                "|| 3. Mostrar Almacenes                         ||\r\n" +
                "|| 4. Volver al Menú Principal                  ||\r\n" +
                "--------------------------------------------------\r\n";
            Console.Write(texto);
            int opcion = Operaciones.GetOpcion("Seleccione una opcion: ", texto, 4);
            if (opcion == 4) return 0;
            
            return opcion+7;
        }
        public static int MenuAgregarYExtraerProductos()
        {
            string texto = "--------------------------------------------------\r\n" +
                "||  Agregar y Extraer Productos - Mi Tiendita   ||\r\n" +
                "--------------------------------------------------\r\n" +
                "|| 1. Ingresar Producto en Almacén              ||\r\n" +
                "|| 2. Extraer Producto de Almacén               ||\r\n" +
                "|| 3. Ver Stock Actual                          ||\r\n" +
                "|| 4. Volver al Menú Principal                  ||\r\n" +
                "--------------------------------------------------\r\n";
            Console.Write(texto);
            int opcion = Operaciones.GetOpcion("Seleccione una opcion: ", texto, 4);
            if (opcion == 4) return 0;
            return opcion+10;
               
        }

    }
}
