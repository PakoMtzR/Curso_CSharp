/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 27/02/2021
 * Ultima modificacion: 22/03/2021
 * 
 * Descripcion del Programa:
 * Generar un algoritmo que si se ingresan 3 números positivos, se establezca 
 * que si son longitudes de líneas rectas, estás puedan formar un triángulo. Solamente se
 * forma un triángulo, cuando la suma de las 2 longitudes de las rectas es mayor que la otra
 */

using System;

namespace Ejercicio003
{
    class Program
    {
        //Funcion para validar dato de entrada (entero positivo)
        public static int validarValorEntero(int num)
        {
            int numeroSalida;
            Console.Write(" l{0} =  ", num); //l1 = Convert.ToInt32(Console.ReadLine());
            while ((!Int32.TryParse(Console.ReadLine(), out numeroSalida)) || (numeroSalida <= 0)) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" [ERROR]: Valor invalido, vuelva a interntar.\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" l{0} =  ", num);
            }
            return numeroSalida; // <-- Retorno del valor valido
        }

        public static bool validarTriangulo(int a, int b, int c)
        {
            bool condicion;
            if ((b + c) > a) condicion = true;
            else condicion = false;
            return condicion;
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            Console.Title = "Programa 003: Validacion de Triangulos";

            //Declaracion de variables
            char opcion = 'y';
            int l1, l2, l3;
            bool trianguloValido;

            //Procesamiento 
            while (opcion != 'n')
            {
                //Reinicio las variables
                trianguloValido = true;
                l1 = 0; l2 = 0; l3 = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("======================================================");
                Console.WriteLine("                     Validar Triangulos");
                Console.WriteLine("======================================================");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("[Instrucciones]: Ingrese las longitudes de las rectas.");
                Console.WriteLine("------------------------------------------------------\n");

                //Entrada y validacion de datos
                l1 = validarValorEntero(1);
                l2 = validarValorEntero(2);
                l3 = validarValorEntero(3);
               
                //Evaluacion del triangulo
                if ( (l1 > l2) && (l1 > l3) ) trianguloValido = validarTriangulo(l1, l2, l3); 
                else if ( (l2 > l1) && (l2 > l3) ) trianguloValido = validarTriangulo(l2, l1, l3);
                else if ( (l3 > l1) && (l3 > l2) ) trianguloValido = validarTriangulo(l3, l1, l2);

                //Impresion de resultados
                Console.WriteLine("\n\n------------------------------------------------------");
                if (trianguloValido) Console.WriteLine("\n    Es posible formar el triangulo: {0}-{1}-{2}", l1, l2, l3);
                else Console.WriteLine("\n    NO es posible formar el triangulo: {0}-{1}-{2}", l1, l2, l3);
               
                //Evaluacion de condicion de salida
                
                Console.Write("\n\n ¿Deseas evaluar otro triangulo? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Deseas evaluar otro triangulo? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}