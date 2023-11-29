using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Pantallas
    {
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
            return 0;
        }

    }
}
