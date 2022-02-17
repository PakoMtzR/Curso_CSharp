/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 27/02/2021
 * Ultima modificacion: 22/03/2021
 * 
 * Descripcion del Programa:
 * Generar un algoritmo que indique si al ingresar un año como un número entero positivo,
 * este sea o no bisiesto. Un año es bisiesto si es múltiplo de 4, exceptuando los múltiplos de 100,
 * que sólo son bisiestos cuando son múltiplos además de 400,
 * por ejemplo el año 1900 no fue bisiesto, pero el año 2000 si lo es
 */

using System;

namespace Ejercicio002
{
    class Program
    {
        //Funcion que verifica si el dato que ingresaron es correcto
        public static int validarValorEntero()
        {
            int valor;
            while ((!Int32.TryParse(Console.ReadLine(), out valor)) || (valor < 0)) // Lee el valor y lo trata de convertirlo a int o si este es menor a 0
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");   //Mensaje de valor no valido
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Ingresar año: ");
            }
            return valor;   // Retorno del dato
        }

        static void Main(string[] args)
        {
            Console.Title = "Programa 002: Año Bisiesto";

            //Declaracion de variables
            char opcion = 'y';
            int year = 0;
            bool condicion = false;

            //Procesamiento 
            while (opcion != 'n')
            {
                //Reinicio las variables
                year = 0;
                condicion = false;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("======================================================");
                Console.WriteLine("              Evaluar si es Año bisiesto");
                Console.WriteLine("======================================================");

                //Ingreso del año:
                Console.Write(" Ingresar año: ");   // year = Convert.ToInt32(Console.ReadLine());
                year = validarValorEntero();
                Console.WriteLine("------------------------------------------------------\n");

                //Evaluacion del año
                if (year % 4 == 0)
                {
                    if (year % 100 == 0)
                    {
                        if (year % 400 == 0) condicion = true;
                        else condicion = false;
                    }
                    else condicion = true;
                }
                else condicion = false;

                //Salida de Datos
                if (condicion) Console.WriteLine("\n   {0} es un año bisiesto", year);
                else Console.WriteLine("\n   {0} NO es un año bisiesto", year);
                
                //Evaluacion de condicion de salida
                Console.Write("\n ¿Deseas evaluar otro año? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Deseas evaluar otro año? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}