/*
  Creado por: Francisco Martinez Rivas 1MM4
  Fecha creacion: 07/05/2021
  Ultima modificacion: 07/05/2021

  Descripcion del Programa:
  Ejecicio 8,
  Programa que genere un password:
   10 dígitos
      - 4 primeros siendo letras minúsculas
      - 4 números y 
      - 2 letras mayúsculas 
      (de manera aleatoria)

  Fuentes: 
*/

using System;

namespace Contraseña_aleatorio_8
{
    class Program
    {
        //Funcion Evaluacion de Salida
        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n¿Desea volver a intentar? [y/n]: ");

            //Evalua condicion de salida, solo acepta [Y/N]
            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write("¿Desea volver a intentar? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;
        }

        public static void Main(string[] args)
        {
            Random rdn = new Random();

            //Inicio del Programa
            do
            {
                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("           Generador de Passwords Aleatorios             ");
                Console.WriteLine(".........................................................");
                Console.WriteLine("    10 dígitos:                                          ");
                Console.WriteLine("       - 4 primeros minusculas, seguido de               ");
                Console.WriteLine("       - 4 números y finalmente                          ");
                Console.WriteLine("       - 2 letras mayusculas                             ");
                Console.WriteLine("=========================================================");

                string cadena_1 = "abcdefghijklmnopqrstuvwxyz";
                string cadena_2 = "0123456789";
                string cadena_3 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                int longitud1 = cadena_1.Length;
                int longitud2 = cadena_2.Length;
                int longitud3 = cadena_3.Length;

                char Minuscula, Numero, Mayuscula;

                // Define longuitud (l) de Cadena 1, 2 y 3
                int l1 = 4, l2 = 4, l3 = 2;

                string passwordParte_1 = string.Empty;
                string passwordParte_2 = string.Empty;
                string passwordParte_3 = string.Empty;

                // Genera Cadena 1, Minisculas (Aleatoria)
                for (int i = 0; i < l1; i++)
                {
                    Minuscula = cadena_1[rdn.Next(longitud1)];
                    passwordParte_1 += Minuscula.ToString();
                }

                // Genera Cadena 2, Numerico (Aleatoria)
                for (int i = 0; i < l2; i++)
                {
                    Numero = cadena_2[rdn.Next(longitud2)];
                    passwordParte_2 += Numero.ToString();
                }

                // Genera Cadena 3, Mayusculas (Aleatoria)
                for (int i = 0; i < l3; i++)
                {
                    Mayuscula = cadena_3[rdn.Next(longitud3)];
                    passwordParte_3 += Mayuscula.ToString();
                }

                // Impresion de resultados
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                Console.WriteLine("Su nuevo password es: {0}{1}{2}", passwordParte_1, passwordParte_2, passwordParte_3);
                Console.WriteLine("---------------------------------------------------------");

            }
            while (condicionSalida());
        }


    }
}

