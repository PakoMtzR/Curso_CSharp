/*
  Creado por: Francisco Martinez Rivas 1MM4
  Fecha creacion: 07/05/2021
  Ultima modificacion: 07/05/2021

  Descripcion del Programa:
  Ejecicio 9,
  Desarrollar un programa que permita ingresar una frase solo texto y espacios de no más de 100 caracteres y que imprima la frase en cada línea eliminando los espacios

  Fuentes: 
*/

using System;

namespace separadorFrases
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
            string texto;
            int sLength;
            int arrayLen;

            //Inicio del Programa
            do
            {
                //Reset variables
                texto = "";
                sLength = 0;
                arrayLen = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("                    Separador de Frases                  ");
                Console.WriteLine(".........................................................");
                Console.WriteLine("   1. Acepata solo texto, no mayor a 100 caracteres.     ");
                Console.WriteLine("   2. Imprimira una frase por linea                      ");
                Console.WriteLine("=========================================================");
                // Usuario ingresa palabra/frase a analizar
                Console.WriteLine("");
                Console.WriteLine(" [Instrucciones]: Ingrese Texto [ < 100 Char]:           ");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                texto = Console.ReadLine();

                Console.WriteLine("\n\nResultado:");
                Console.WriteLine("---------------------------------------------------------");
                sLength = texto.Length;

                // Ejecucion del proceso solo textos <= 100 caracteres
                if (sLength <= 100)
                {
                    string[] splitedArray = texto.Trim().Split(' ');
                    arrayLen = splitedArray.Length;

                    for (int i = 0; i < arrayLen; i++)
                    {
                        for (int j = 0; j < arrayLen - i; j++)
                        {
                            // Impresion de resultados
                            Console.Write(splitedArray[j] + " ");
                        }
                        Console.WriteLine(" ");
                    }
                }
                else
                {
                    // Error: + 100 caracteres
                    Console.WriteLine("Texto excede la longuitud admitida [Maximo 100 caracteres]");
                }
            }
            while (condicionSalida());
        }
    }
}
