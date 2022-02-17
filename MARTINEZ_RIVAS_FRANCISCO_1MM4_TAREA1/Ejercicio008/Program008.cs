/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 02/03/2021
 * Ultima modificacion: 04/03/2021
 * 
 * Generar un algoritmo que permita obtener y desplegar los N primeros números primos,
 * en donde N es un número entero positivo, el cual ingresa el usuario. 
 * Recordar que los números primos son aquellos que solo son divisibles entre si mismos y entre 1. 
 * Si N=8, el programa debe mostrar 2,3,5,7,11,13,17,19
 */

using System;

namespace Ejercicio008
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Programa 008: Serie de numeros Primos";

            //Declaracion de variables
            char opcion = 'y';
            int cantidadPrimos, divisores, n;

            //Procesamiento  
            while (opcion != 'n')
            {
                //Reinicio las variables
                cantidadPrimos = 0; divisores = 0; n = 2;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================================");
                Console.WriteLine("                      Numeros Primos");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese la cantidad de numeros primos");
                Console.WriteLine("                  que quiera imprimir en consola");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("  n = "); //cantidadPrimos = Convert.ToInt32(Console.ReadLine());
                while ((!Int32.TryParse(Console.ReadLine(), out cantidadPrimos)) || (cantidadPrimos <= 0) || (cantidadPrimos > 5000)) // <-- Validacion del dato
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("  n = ");
                }
                Console.WriteLine("---------------------------------------------------------\n");

                //Construccion de la serie de numeros primos
                Console.Write("     Primos:");
                while (cantidadPrimos != 0)
                {
                    for (int i = 1; i <= n; i++) if (n % i == 0) divisores++;
                    if (divisores == 2)
                    {
                        cantidadPrimos--;
                        Console.Write(" {0}", n);
                    }
                    divisores = 0;
                    n++;
                }

                //Evaluacion de condicion de salida
                Console.Write("\n\n\n ¿Desea volver a contruir la serie? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Desea volver a contruir la serie? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}