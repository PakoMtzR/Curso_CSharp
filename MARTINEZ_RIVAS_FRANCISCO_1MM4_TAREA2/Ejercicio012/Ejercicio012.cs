/*
  Creado por: Francisco Martinez Rivas 1MM4
  Fecha creacion: 07/05/2021
  Ultima modificacion: 07/05/2021

  Descripcion del Programa:
  Ejecicio 12,
  Desarrollar un programa que permita ingresar una palabra o frase y verificar si se trata de un palíndromo (Enlaces a un sitio externo.) o no

  Fuentes: 
  https://es.wikipedia.org/wiki/Pal%C3%ADndromo
*/

using System;

namespace palindrome
{
    class Program
    {
        //Funcion Evaluacion de Salida
        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n ¿Desea volver a intentarlo? [y/n]: ");

            //Evalua condicion de salida, solo acepta [Y/N]
            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver a intentarlo? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;  // <--- opcionSalida == 'n'
        }

        //Funcion principal
        static void Main(string[] args)
        {
            // Declaracion de variables
            int no_char, contador_izq, contador_der;
            bool palindromo;
            string frase;


            //Inicio del Programa
            do
            {
                // Inicializacion de variables
                no_char = 0;
                contador_izq = 0;
                contador_der = 0;
                palindromo = true;
                frase = "";

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("                Analizador de Palindromos                ");
                Console.WriteLine(".........................................................");
                Console.WriteLine("  Palindromo: Palabra oexpresion que se lee igual        ");
                Console.WriteLine("              de izquierda a derecha y viseversa.        ");
                Console.WriteLine("=========================================================");
                // Usuario ingresa palabra/frase a analizar
                Console.WriteLine(" ");
                Console.WriteLine(" [Instrucciones]: Ingrese palabra/frase a validar:       ");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                frase = Console.ReadLine().ToLower();

                // Suprime espacios en blanco (no distingue entre palabra o frase)
                frase = frase.Replace(" ", String.Empty);
                // Ajusta tamaño de arreglo
                no_char = frase.Length - 1;

                // Analisis de palabra/frase
                for (contador_izq = 0, contador_der = no_char; contador_izq <= no_char / 2; contador_izq++, contador_der--)
                {
                    if (frase[contador_izq] != frase[contador_der])
                        palindromo = false;
                }

                // Impresion de resultados
                Console.WriteLine("\n\nResultado:");
                Console.WriteLine("---------------------------------------------------------");
                if (palindromo)
                {
                    Console.WriteLine("La palabra o frase es un Palindromo");
                }
                else
                {
                    Console.WriteLine("La palabra o frase NO es un Palindromo");
                }
            }
            while (condicionSalida());
        }
    }
}
