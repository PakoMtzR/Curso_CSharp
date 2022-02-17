/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 19/03/2021
 * Ultima modificacion: 22/03/2021
 * 
 * Descripcion del Programa:
 * Generar un algoritmo que permita calcular el 
 * dígito de control del código de barras EAN-8
 */

using System;

namespace Ejercicio014
{
    class Program
    {
        //Algoritmo que permite calcular el dígito de control del código de barras EAN-8
        public static void genNumeroControl(string codigo)
        {
            int numero = 0;
            int acumuladorPar = 0;
            int acumuladorImpar = 0;
            int numeroControl = 0;

            for (int i = 0; i < codigo.Length; i++)
            {
                numero = Int32.Parse(codigo[i].ToString());

                if (i % 2 != 0) acumuladorImpar += numero;
                else acumuladorPar += numero;
            }

            acumuladorImpar *= 3;
            numeroControl = 10 - ((acumuladorImpar + acumuladorPar) % 10);

            Console.WriteLine("\tCodigo: {0} {1}",codigo, numeroControl);
        }

        //Funcion Evaluacion del dato de entrada
        public static int validacionDato()
        {
            int valor;
            while ((!Int32.TryParse(Console.ReadLine(), out valor)) || (valor < 10000000) || (valor > 99999999)) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  n = ");
            }
            return valor; 
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            Console.Title = "Programa 014: Código de barras EAN-8";

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
                Console.WriteLine("             Control del código de barras EAN-8");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese el codigo para poder generar su");
                Console.WriteLine("                  numero de control (8 digitos).");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("  Codigo: ");
                numeroEntrada = validacionDato();
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n");

                genNumeroControl(numeroEntrada.ToString());

                //Evaluacion de condicion de salida
                Console.Write("\n\n\n ¿Desea volver a ingresar otro codigo [y/n]: ");
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Desea volver a ingresar otro codigo [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}
