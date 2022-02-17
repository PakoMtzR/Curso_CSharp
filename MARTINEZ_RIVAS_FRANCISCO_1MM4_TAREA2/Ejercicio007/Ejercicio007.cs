/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 06/05/2021
 * Ultima modificacion: 06/05/2021
 * 
 * Descripcion del Programa:
 * Programa que permita obtener los números primos inferiores a un número entero positivo N 
 * proporcionado por el usuario, en donde N es un número entero positivo, el cual ingresa el usuario, 
 * esto es si N = 20, el programa debe desplegar la lista 2,3,5,7,11,13,17,19. 
 * El programa debe seguir el algoritmo propuesto por el matemático S.P. Sundaram: La criba de Sundaram
 */

using System;

namespace Ejercicio007
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuracion de Ventana
            Console.Title = "Programa 007: Numeros Primos";

            //Declaracion de variables
            int limite;
            string primos;

            //Procesamiento  
            do
            {
                limite = 0; //Reinicio de Variables
                primos = "";

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("              Numeros Primos (Criba de Sundaram) ");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese los datos que se le solicitan");
                Console.WriteLine("---------------------------------------------------------");
                    Console.Write("  Limite: "); limite = validarEntero("  Limite: ");
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n");

                primos = cribaSundaram(limite);

                Console.WriteLine($"  Numeros Primos entre [0, {limite}]"); 
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine($"    {primos}");
            }
            while (condicionSalida());
            
        }

        public static string cribaSundaram(int max)
        {
            //Declaracion de Variables
            string primos = "";
            int[,] numeros = new int[max, 2];
            int numero = 0;

            //Llenamos el arreglo bidimensional
            for(int i = 0; i < max; i++)
            {
                numeros[i, 0] = i;  //fila 1: 0 1 2 3 4 5 ... n
                numeros[i, 1] = 0;  //fila 2: 0 0 0 0 0 0 ... n <-- El 0 significa: posible primo
            }

            for (int j = 2; j < max; j++)
            {
                for (int k = 2; k < max + 1; k++)
                {
                    //Si a un numero, lo multiplicamos por k y este se encuetra en el arreglo, significa que es multiplo de dicho numero 
                    //Por lo tanto este no sera primo
                    numero = numeros[j, 0] * k; 
                    if (numero < max) numeros[numero, 1] = 1;   //Asignamos el valor de 1 para marcarlo como NO primo
                    else break;
                }
                if (numeros[j, 1] == 0) primos += numeros[j, 0] + " "; //En primos solo agregamos todos los numeros que no quedaron marcados (0)
            }
            return primos;
        }

        //Funcion para la Validacion de dato Entero
        public static int validarEntero(string dato)
        {
            int valor;
            while ((!Int32.TryParse(Console.ReadLine(), out valor)) || (valor <= 2) || (valor > 10000)) // <-- Validacion del dato
                Console.Write($"{dato}");

            return valor;
        }

        //Evaluacion Condicion de Salida
        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n ¿Desea volver intentarlo? [y/n]: ");

            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver intentarlo? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;  // <--- opcionSalida == 'n'
        }
    }
}
