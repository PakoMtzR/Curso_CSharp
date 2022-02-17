/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 24/02/2021
 * Ultima modificacion: 22/03/2021
 * 
 * Descripcion del Programa:
 * Generar un algoritmo que permita calcular el factorial de un número N
 * ingresado por el usuario, debe tomarse en cuenta que el usuario 
 * solo puede ingresar números enteros y positivos.
 */

using System;

namespace Ejercicio001
{
    class Program
    {
        //Funcion para calcular el factorial
        public static void factorial(int numero)
        {
            double factorial;   //Declaramos como tipo double para que pueda almacenar numero muy grandes
            factorial = 1;  //Inicializo mi variable

            //Evalucion del Factorial:
            if (numero == 0) factorial = 1;    // <-- 0! = 1
            else for (int i = 1; i <= numero; i++) factorial *= i;  // n! = (1)(2)(3).....(n)

            //Impresion de resultados
            Console.WriteLine("\t{0}! = {1}\n", numero, factorial);
        }

        //Funcion que analiza y valida el valor que ingreso el usuario
        public static int validarValorEntero()
        {
            int valor;
            while ((!Int32.TryParse(Console.ReadLine(), out valor)) || (valor < 0) || (valor > 170)) // Lee el valor y lo trata de convertirlo a int o si este es menor a 0
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");   //Mensaje de valor no valido
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" n = ");
            }
            return valor;   // Retorno del dato
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            //Declaracion de variables.
            char opcion = 'y';
            int num;

            Console.Title = "Programa 001: Factorial";      //Titulo del factorial
            Console.ForegroundColor = ConsoleColor.Yellow;  //Color del texto

            //Procesamiento 
            while (opcion != 'n')
            {
                num = 0;

                //Impresion titulo
                Console.WriteLine("===========================================================");
                Console.WriteLine("                     Calculo de Factoriales   ");
                Console.WriteLine("===========================================================");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("[Instrucciones]: Ingrese el valor del factorial que desea  ");
                Console.WriteLine("                 calcular (solo es valido numeros enteros).");
                Console.WriteLine("-----------------------------------------------------------\n");
                Console.Write(" n = "); //Ingreso de dato
                num = validarValorEntero(); //<-- Validacion del dato
                Console.WriteLine("---------------------------------------------------------\n");
                Console.WriteLine("");

                factorial(num); //<-- Calculo del factorial con ayuda de la funcion
                
                //Evaluacion de condicion de salida
                Console.Write("\n ¿Deseas calcular otro factorial? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Deseas calcular otro factorial? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}