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
        public static void GetKey(string texto)
        {
            Console.Write("--------------------------------------------------\n" + texto);
            Console.ReadKey();
        }
        public static int GetEntero(string texto, string prefijo)
        {
            bool respuesta = false;
            int opcion = 0;
            while (!respuesta)
            {
                Console.Write(texto);
                string enterotexto = Console.ReadLine();
                respuesta = int.TryParse(enterotexto, out opcion);
                if (opcion < 1) respuesta = false;
                if (!respuesta)
                {
                    Console.Clear();
                    Console.Write(prefijo);
                    Console.WriteLine("Ingrese una opción valida");
                }
            }
            return opcion;
        }
        public static float GetFloat(string texto, string prefijo)
        {
            bool respuesta = false;
            float opcion = 0;
            while (!respuesta)
            {
                Console.Write(texto);
                string enterotexto = Console.ReadLine();
                respuesta = float.TryParse(enterotexto, out opcion);
                if (opcion < 1) respuesta = false;
                if (!respuesta)
                {
                    Console.Clear();
                    Console.Write(prefijo);
                    Console.WriteLine("Ingrese una opción valida");
                }
            }
            return opcion;
        }
        public static string GetString(string texto)
        {
            Console.Write(texto);
            return Console.ReadLine();
        }
        public static string SetTitulo(string texto)
        {
            return "===== " + texto + " =====\n" +
                "--------------------------------------------------\n";
        }

    }
}
