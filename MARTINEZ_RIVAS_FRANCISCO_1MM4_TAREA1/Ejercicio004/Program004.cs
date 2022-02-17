/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 27/02/2021
 * Ultima modificacion: 23/03/2021
 * 
 * Descripcion del Programa:
 * Generar un algortimo que permita generar un triángulo con *, solicitando 
 * al usuario el número de filas a generar (en un intervalo de 1 a 10)
 */

using System;

namespace Ejercicio004
{
    class Program
    {
        //Funcion que genera el triangulo
        public static void trianguloPiramide(int filas)
        {
            string asteriscos = "*";
            for (int i = 1; i <= filas; i++)
            {
                for (int j = 1; j <= i; j++) Console.Write(asteriscos);
                Console.Write("\n");
            }
        }

        //Funcion que verifica si ingresaron un valor entero
        public static int validarValorEntero()
        {
            int valor; 
            while ((!Int32.TryParse(Console.ReadLine(), out valor)) || (valor <= 0) || (valor > 100)) // Lee el valor y lo trata de convertirlo a int o si este es menor a 0
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");   //Mensaje de valor no valido
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Ingresa numero de filas: ");
            }
            return valor;
        }

        static void Main(string[] args)
        {
            Console.Title = "Generar Triangulo con * uwu";

            //Declaracion de variables
            char opcion = 'y';
            int filas;

            //Procesamiento 
            while (opcion != 'n')
            {
                //Reinicio las variables
                filas = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("==================================================");
                Console.WriteLine("               Formar Triangulo con '*'");
                Console.WriteLine("==================================================");

                //Ingreso del numero de filas y validacion del dato:
                Console.Write(" Ingresa numero de filas: "); //filas = Convert.ToInt32(Console.ReadLine());
                filas = validarValorEntero();
                Console.WriteLine("--------------------------------------------------\n");

                //Construccion del triangulo
                trianguloPiramide(filas);

                //Evaluacion de condicion de salida
                Console.Write("\n ¿Deseas construir otro triangulo? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Deseas construir otro triangulo? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}
