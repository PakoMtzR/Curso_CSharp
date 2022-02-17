/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 12/03/2021
 * Ultima modificacion: 23/03/2021
 * 
 * Descripcion del programa:
 * Generar un algoritmo que permita obtener una cantidad N de números 
 * pseudoaleatorios (donde N es un número entero, mayor a 0) utilizando 
 * para ello el método/algoritmo de generación de números congruencial.
 * 
 * Fuente:
 * https://www.youtube.com/watch?v=OdLM3FiHoNo&list=WL
 * https://www.dropbox.com/s/c31wk8l5maltt8a/Generador%20de%20N%C3%BAmeros%20aleatorios%20congruencial.doc?dl=0
 */

using System;

namespace Ejercicio012
{
    class Program
    {
        //Algoritmo de generación de números congruencial
        static public void genNumAleatorios(int cantidad)
        {
            //Declaracion de Variables
            decimal[] random = new decimal[cantidad];   //Guarda los numeros aleatorios
            decimal[] n = new decimal[cantidad + 1];      //Guarda todos los valores de xi
            int x_inicial, a, b, m;

            //Parametros:
            x_inicial = 5; b = 0; a = 5; m = 13;

            //Impresion del titulo
            Console.WriteLine("Numeros aleatorios");
            Console.WriteLine("---------------------------------------------------------");

            //Algoritmo Congruencial Lineal
            n[0] = x_inicial; // <-- Ingresamos un valor inicial en el arreglo de xi
            for (int i = 0; i <= (cantidad - 1); i++)
            {
                n[i + 1] = (((a * n[i]) + b) % m);  //Console.WriteLine(x_i[i +  1]);
                random[i] = decimal.Round(n[i] / m, 4);
                Console.WriteLine("\tx[{0}] = {1}", (i + 1), random[i]);
            }
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            Console.Title = "Programa 012: Serie de Numeros Pseudoaleatorios";

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
                Console.WriteLine("              Serie de Numeros Pseudoaleatorios");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese la cantidad de elementos que");
                Console.WriteLine("                  desea usted imprimir en consola.");
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
                Console.Write("\n\t");

                genNumAleatorios(numeroEntrada);
         
                //Evaluacion de condicion de salida
                Console.Write("\n\n\n ¿Desea volver a intentarlo? [y/n]: ");
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Desea volver a hacer otro calculo? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}
