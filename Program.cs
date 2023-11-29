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

                        //Menu-Gestionar Almacenes

                        //Menu-Agregar y Extraer Productos

                }
            }

        }
    }
}
