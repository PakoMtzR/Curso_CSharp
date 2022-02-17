/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 25/03/2021
 * Ultima modificacion: 25/03/2021
 * 
 * ------------------------------------------------------------------------------------------------------------------------------------------
 * Descripcion del Programa:
 * 
 * Generar el diagrama de flujo y el programa en C# que calcule mediante las correspondientes series de Taylor, 
 * el valor del arcoseno hiperbólico de un argumento que se encuentra entre -1 y 1
 * 
 * Los valores a ingresar son el valor a calcular (x) como un número real en el intervalo [-1, 1] y el número de iteraciones o 
 * términos de la serie que se van a realizar (N) como un número entero positivo. Finalmente, se debe de mostrar el valor del 
 * resultado de la aproximación.
 * 
 * Por otro lado, se le debe dar opción al usuario de ver cada uno de los términos calculados o solamente el valor del 
 * resultado de la aproximación.
 * -------------------------------------------------------------------------------------------------------------------------------------------
 */

using System;

namespace examen_part02
{
    class Program
    {
        public static float validarArgumento()
        {
            float numeroEntrada;
            while ((!float.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada > 1) || (numeroEntrada < -1)) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  x = ");
            }
            return numeroEntrada;
        }

        public static int validarIteraciones()
        {
            int numeroEntrada;
            while ((!int.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 33)) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("     n = ");
            }
            return numeroEntrada;
        }

        public static int factorial(int numero)
        {
            int factorial;   //Declaramos como tipo double para que pueda almacenar numero muy grandes
            factorial = 1;  //Inicializo mi variable

            //Evalucion del Factorial:
            if (numero == 0) factorial = 1;    // <-- 0! = 1
            else for (int i = 1; i <= numero; i++) factorial *= i;  // n! = (1)(2)(3).....(n)

            return factorial;
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            Console.Title = "Programa Examen parte 2";

            //Declaracion de variables
            char opcion = 'y';
            float x;
            int n;
            double arcsinh;

            //Procesamiento  
            do
            {
                arcsinh = 0; x = 0; n = 0;
                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===========================================================");
                Console.WriteLine("                  Valor del arcoseno hiperbólico");
                Console.WriteLine("===========================================================");
                Console.WriteLine("");
                Console.WriteLine("                         arcsinh(x)");
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese los valor del argumento ");
                Console.WriteLine("                  (ingresar  valores entre -1 y 1 [-1, 1])");
                Console.WriteLine("-----------------------------------------------------------");
                Console.Write("     x = "); x = validarArgumento();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese el numero de iteraciones (n)");
                Console.WriteLine("-----------------------------------------------------------");
                Console.Write("     n = "); n = validarIteraciones();

                //Calculo del arcsinh(x)
                for(int i = 0; i <= n; i++) arcsinh += ((Math.Pow(-1, i))*factorial(2*i)*(Math.Pow(x, ((2*i)+1)))) / ((Math.Pow(4, i))*(Math.Pow(factorial(i),2))*((2*i)+1));

                //Impresion de Resultados
                Console.WriteLine("\n\n\tarcsinh({0}) = {1} (aprox)", x, arcsinh);

                //Evaluacion de condicion de salida
                Console.Write("\n\n\n ¿Desea volver evaluar otro valor? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());

                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y'))))
                    Console.Write("\n ¿Desea volver evaluar otro valor? [y/n]: ");

                Console.Clear();
            }
            while (opcion != 'n');
        }
    }
}