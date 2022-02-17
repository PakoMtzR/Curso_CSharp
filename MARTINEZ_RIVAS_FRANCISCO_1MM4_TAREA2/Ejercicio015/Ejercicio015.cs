/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 05/05/2021
 * Ultima modificacion: 05/05/2021
 * 
 * Descripcion del Programa:
 * Programa que permita verificar si un número entero positivo ingresado por el usuario
 * es o no un número narcisista Los números narcisistas.
 * 
 * Fuente: https://mathworld.wolfram.com/NarcissisticNumber.html
 */

using System;

namespace Ejercicio015
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuracion de Ventana
            Console.Title = "Programa 015: Numeros Narcisistas";

            //Declaracion de variables
            int numeroInp;

            //Procesamiento  
            do
            {
                numeroInp = 0; //Reinicio de Variables

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("                     Numeros Narcisistas");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese los datos que se le solicitan");
                Console.WriteLine("---------------------------------------------------------");
                    Console.Write("  Numero a Evaluar: ");  numeroInp = validarEntero("  Numero a Evaluar: ");
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n");

                if (numeroNarcisista(numeroInp)) Console.WriteLine($" {numeroInp} es Narcisista");
                else Console.WriteLine($" {numeroInp} No es Narcisista");
            }
            while (condicionSalida());
        }


        //Funcion Validar Entero
        public static int validarEntero(string dato)
        {
            int valor;
            while ((!Int32.TryParse(Console.ReadLine(), out valor)) || (valor <= 0) || (valor > 99999999)) // <-- Validacion del dato
            {
                Console.Write($"{dato}");
            }
            return valor;
        }


        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n ¿Desea volver intentarlo? [y/n]: ");

            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver intentarlo? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;  // <--- opcionSalida == 'n'
        }


        public static bool numeroNarcisista(int numeroInp)
        {
            string numero = numeroInp.ToString();
            double suma = 0;
            int potencia = numero.Length;

            for(int i = 0; i <= numero.Length - 1; i++)
            {
                suma += Math.Pow(Int32.Parse(numero[i].ToString()), potencia);
            }

            if (numeroInp == suma) return true;
            else return false;
        }
    }
}
