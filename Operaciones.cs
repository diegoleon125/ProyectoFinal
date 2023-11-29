using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Operaciones
    {
        public static int GetOpcion(string texto, string prefijo, int limite)
        {
            bool respuesta = false;
            int opcion = 0;
            while (!respuesta)
            {
                Console.Write(texto);
                string opciontexto = Console.ReadLine();
                respuesta = int.TryParse(opciontexto, out opcion);
                if (opcion < 1 || opcion > limite) respuesta = false;
                if (!respuesta)
                {
                    Console.Clear();
                    Console.Write(prefijo);
                    Console.WriteLine("Ingrese una opción valida");
                }
            }
            return opcion;
        }

    }
}
