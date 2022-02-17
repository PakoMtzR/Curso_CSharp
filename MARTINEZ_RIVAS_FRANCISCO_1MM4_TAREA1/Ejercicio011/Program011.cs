/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 12/03/2021
 * Ultima modificacion: 23/03/2021
 * 
 * Descripcion del programa:
 * Programa que calcule el doble factorial (n!!) de un número entero positivo
 */
using System;

namespace Ejercicio011
{
    class Program
    {
        //Funcion que calcula el doble factorial de un numero
        public static double dobleFactorial(int numero) // <-- Declare la funcion como double para que pueda retornarme numeros mas grandes
        {
            //Inicializamos todas las variables
            int k = 0;
            double dobleFactorial = 1; 
            int factor = 1;

            //Calculo del doble factorial
            while (factor > 0)  // El ciclo termina cuando factor = 1 || factor = 2
            {
                dobleFactorial *= factor;   // n!! = (n-2)(n-4)(n-6)...(1)--> si es impar, (2)--> si es par
                factor = numero - (2 * k);  // (n-2k)
                k++;    //Cada vez incrementa k una unidad
            }
            return dobleFactorial;  //Retornamos el valor del doble factorial
        }

        //Funcion que valida el dato que ingreso el usuario
        public static int validarDato()
        {
            int numeroEntrada;
            while ((!Int32.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 300)) // <-- Validacion del dato
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
            Console.Title = "Programa 011: Doble Factorial";

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
                Console.WriteLine("                     Doble Factorial");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese el valor del doble factorial");
                Console.WriteLine("                  que desea calcular.");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("  n = ");
                numeroEntrada = validarDato();
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n\t");
                
                //Impresion de resultados en consola
                Console.WriteLine("{0}!! = {1}", numeroEntrada, dobleFactorial(numeroEntrada));   // <-- Llamando a la funcion "dobleFactorial(numeroEntrada)"              

                //Evaluacion de condicion de salida
                Console.Write("\n\n\n ¿Desea volver a hacer otro calculo? [y/n]: ");
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Desea volver a hacer otro calculo? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}
