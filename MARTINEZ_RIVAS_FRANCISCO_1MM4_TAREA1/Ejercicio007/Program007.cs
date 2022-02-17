/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 01/03/2021
 * Ultima modificacion: 22/03/2021
 * 
 * Generar un algoritmo que permita imprimir los números de la serie de Fibonacci, 
 * perimtiendo que se ingrese el número de elementos a desplegar N, como valor entero y positivo. 
 * Recordar que la serie de Fibonacci es: 0,1,1,2,3,5,8,13,21,34,...
 */

using System;

namespace Ejercicio007
{
    class Program
    {
        //Funcion que valida el dato de entrada
        public static int validarDato()
        {
            int numeroEntrada;
            while ((!Int32.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 1430)) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  n = ");
            }
            return numeroEntrada;
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            Console.Title = "Serie de Fibonacci";

            //Declaracion de variables
            char opcion = 'y';
            double a, b, c;
            int numeroEntrada, k;
            double[] serieFibonacci = new double[1];
            
            //Procesamiento 
            while (opcion != 'n')
            {
                //Reinicio las variables
                numeroEntrada = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================================");
                Console.WriteLine("                     Serie Fibonacci");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese el numero de elementos que ");
                Console.WriteLine("                  quiera imprimir de la serie Fibonacci");
                Console.WriteLine("---------------------------------------------------------");

                //Ingreso y validacion de dato
                Console.Write("  n = "); //n = Convert.ToInt32(Console.ReadLine());
                numeroEntrada = validarDato();
                Console.WriteLine("---------------------------------------------------------");

                //Serie Fibonacci
                Console.Write("\n\t");
                serieFibonacci = new double[numeroEntrada];
                for (k = 0, a = 1, b = 0, c = 0; k < numeroEntrada; c = a + b, a = b, b = c, k++) serieFibonacci[k] = c; //Otra alternativa --> Console.Write(" {0}", c);
                for (k = 0; k < numeroEntrada; k++) Console.Write(" {0}", serieFibonacci[k]);   // <-- Imprime los datos del arreglo
                
                //Evaluacion de condicion de salida
                Console.WriteLine("\n\n\n---------------------------------------------------------");
                Console.Write(" ¿Desea volver a contruir la serie? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());
                
                while (!((Char.TryParse(Console.ReadLine(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Desea volver a contruir la serie? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}