/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 07/05/2021
 * Ultima modificacion: 07/05/2021
 * 
 * Descripcion del Programa:
 * Programa que permita verificar si un número entero positivo ingresado por el usuario 
 * es o no un número de Keith Los números de Keith.
 * 
 * Fuente: 
 * https://mathworld.wolfram.com/KeithNumber.html
 */

using System;

namespace Ejercicio016
{
    class Program
    {
        //=================================================================================
        //      Funcion Principal
        //=================================================================================
        static void Main(string[] args)
        {
            //Configuracion de Ventana
            Console.Title = "Programa 016: Numeros de Keith";

            //Declaracion de Variables
            int numero;

            //Inicio del Programa
            do
            {
                numero = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("                      Numeros de Keith");
                Console.WriteLine("=========================================================");
                Console.WriteLine("          Este programa determina si un numero es ");
                Console.WriteLine("                     un numero de Keith");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese un numero entero positivo");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("                 N: "); numero = validarEntero("                 N: ");
                Console.WriteLine("---------------------------------------------------------\n");

                if (numeroKeith(numero.ToString())) Console.WriteLine($"        {numero} es un numero de Keith");
                else Console.WriteLine($"       {numero} NO es un numero de Keith");
            }
            while (condicionSalida());
        }

        //=================================================================================
        //      Validador de numeros de Keith
        //=================================================================================
        public static bool numeroKeith(string numero)
        {
            int suma = 0;
            int[] numeros = new int[numero.Length];

            //Guardamos en un arreglo todos los digitos del numero
            for (int i = 0; i < numero.Length; i++)
            {
                numeros[i] = Int32.Parse(numero[i].ToString());
            }


            while (suma < Int32.Parse(numero))
            {
                suma = 0;   // Limpiamos la variable

                // Se suma todos los numeros del arreglo
                for (int k = 0; k < numero.Length; k++)
                {
                    suma += numeros[k];
                }

                // Desplazamos todos los valores del arreglo un lugar a la izquierda
                for (int j = 0; j < numero.Length; j++)
                {
                    if (j == numero.Length - 1) numeros[j] = suma; //Cuando lleguemos al ultimo dato del arreglo, guardaremos la suma del paso anterior
                    else numeros[j] = numeros[j + 1];
                }
            }

            // Si la suma final es igual al numero de entrada, entonces es un numero de Keith
            if (suma == Int32.Parse(numero)) return true;
            else return false;
        }

        //=================================================================================
        //      Funciones Auxiliares
        //=================================================================================
        
        //Funcion Evaluacion de Salida
        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n ¿Desea volver a intentarlo? [y/n]: ");

            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver a intentarlo? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;  // <--- opcionSalida == 'n'
        }

        //Funcion para la Validacion de dato Entero
        public static int validarEntero(string dato)
        {
            int valor;
            while ((!Int32.TryParse(Console.ReadLine(), out valor)) || (valor < 10) || (valor > 1000000)) // <-- Validacion del dato
                Console.Write($"{dato}");

            return valor;
        }
    }
}