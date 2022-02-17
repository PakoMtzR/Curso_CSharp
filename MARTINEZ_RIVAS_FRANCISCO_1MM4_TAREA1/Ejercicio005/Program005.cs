/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 27/02/2021
 * Ultima modificacion: 22/03/2021
 * 
 * Descripcion del Programa:
 * Generar un algoritmo que indique si al ingresar 
 * un número entero positivo, este es par o impar
 */

using System;

namespace Ejercicio005
{
    class Program
    {
        //Funcion que verifica si ingresaron un valor entero
        public static int validarValorEntero()
        {
            int valor;
            while ((!Int32.TryParse(Console.ReadLine(), out valor)) || (valor < 0)) // Lee el valor y lo trata de convertirlo a int o si este es menor a 0
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");   //Mensaje de valor no valido
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" n = ");
            }
            return valor;
        }

        static void Main(string[] args)
        {
            Console.Title = "Programa 005: Evaluar si un numero es Par o Impar";

            //Declaracion de variables
            char opcion = 'y';
            int numero;

            //Procesamiento 
            while (opcion != 'n')
            {
                //Reinicio las variables
                numero = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=====================================================");
                Console.WriteLine("         Evaluar si un numero es Par o Impar");
                Console.WriteLine("=====================================================");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese el numero que desea evaluar");
                Console.WriteLine("------------------------------------------------------");

                //Ingreso del numero y validacion de dato
                Console.Write(" n = "); //numero = Convert.ToInt32(Console.ReadLine());
                numero = validarValorEntero();
                Console.WriteLine("------------------------------------------------------\n");

                //Evaluacion si el numero es par o impar
                if ( (numero % 2) == 0 ) Console.WriteLine("\n\t{0} es un numero Par.", numero);
                else Console.WriteLine("\n\t{0} es un numero Impar.", numero);
                
                //Evaluacion de condicion de salida
                Console.Write("\n ¿Desea evaluar otro numero? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Desea evaluar otro numero? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}