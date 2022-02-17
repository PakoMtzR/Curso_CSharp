/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 19/03/2021
 * Ultima modificacion: 23/03/2021
 * 
 * Descripcion del Programa:
 * Programa para generar un triángulo de Pascal, en donde el usuario 
 * ingrese el número de filas que desea observar del triángulo
 */

using System;

namespace Ejercicio013
{
    class Program
    {
        //Funcion para calcular el factorial
        public static double factorial(int numero)
        {
            double factorial;   //Declaramos como tipo double para que pueda almacenar numero muy grandes
            factorial = 1;  //Inicializo mi variable

            //Evalucion del Factorial:
            if (numero == 0) factorial = 1;    // <-- 0! = 1
            else for (int i = 1; i <= numero; i++) factorial *= i;  // n! = (1)(2)(3).....(n)

            return factorial;
        }

        //Funcion Combinatoria
        public static double funcionCombinatoria(int n, int r)
        {
            return factorial(n) / (factorial(r) * factorial(n - r));
        }

        static void Main(string[] args)
        {
            Console.Title = "Programa 013: Triangulo de Pascal";

            //Declaracion de variables
            char opcion = 'y';
            int numeroEntrada;

            //Procesamiento  
            while (opcion != 'n')
            {
                
                //Reinicio de Variables
                numeroEntrada = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================================");
                Console.WriteLine("                     Triangulo de Pascal");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese la cantidad de filas que desea");
                Console.WriteLine("                  ver del triangulo de Pascal.");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("  n = ");
                while ((!Int32.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0)) // <-- Validacion del dato
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("  n = ");
                }
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n");

                //Construccion del Triangulo de Pascal
                for(int i = 0; i < numeroEntrada; i++)
                {
                    for (int j = (numeroEntrada - i); j >= 0; j--) Console.Write(" ");
                    for (int j = 0; j <= i; j++) Console.Write("{0} ", funcionCombinatoria(i, j));
                    Console.WriteLine("");
                }

                //Evaluacion de condicion de salida
                Console.Write("\n\n\n ¿Desea volver a construir el triangulo? [y/n]: ");
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Desea volver a construir el triangulo? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}
