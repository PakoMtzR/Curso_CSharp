/*
  Creado por: Francisco Martinez Rivas 1MM4
  Fecha creacion: 07/05/2021
  Ultima modificacion: 07/05/2021

  Descripcion del Programa:
  Ejecicio 17,
  Programa que permita verificar si al ingresar un par de números enteros positivos, se tratan o no de números amigos Los números amigos.

  Fuentes: 
  https://mathworld.wolfram.com/AmicablePair.html
*/

using System;

namespace NumerosAmigos
{
    class Program
    {
        //Funcion Evaluacion de Salida
        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n¿Desea volver a intentar? [y/n]: ");

            //Evalua condicion de salida, solo acepta [Y/N]
            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write("¿Desea volver a intentar? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;
        }

        // Encuentra divisores y los suma. 
        // S=1, porque 1 es comun divisor de cualquier numero
        static int suma(int N, int S)
        {
            for (int i = 2; i < N; i++)
            {
                if (N % i == 0)
                {
                    S = S + i;
                }
            }
            return S;
        }

        static void Main(string[] args)
        {
            int num_1;
            int num_2;
            int sum1 = 1;
            int sum2 = 1;
            bool valid;

            //Inicio del Programa
            do
            {
                //Reset variables
                num_1 = 0;
                num_2 = 0;
                sum1 = 1;
                sum2 = 1;
                valid = false;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("                      Numeros Amigos                     ");
                Console.WriteLine(".........................................................");
                Console.WriteLine(" Numeros Amigos: Son dos números enteros positivos A y B ");
                Console.WriteLine(" donde la suma de los divisores de A es igual al de B y  ");
                Console.WriteLine(" viceversa.                                              ");
                Console.WriteLine("=========================================================");
                // Usuario ingresa palabra/frase a analizar
                Console.WriteLine(" ");
                Console.WriteLine(" Ingrese Primer Numero [Num Entero +]:                   ");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                do
                {
                    try
                    {
                        num_1 = Convert.ToInt32(Console.ReadLine());
                        valid = true;
                    }
                    catch (Exception ex)
                    {
                        ex = null;
                        Console.WriteLine("Error: El numero debe ser entero positivo, vuelva a intentar.");
                        valid = false;
                    }
                } while (!valid);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" ");
                Console.WriteLine(" Ingrese Segundo Numero [Num Entero +]:                  ");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                do
                {
                    try
                    {
                        num_2 = Convert.ToInt32(Console.ReadLine());
                        valid = true;
                    }
                    catch (Exception ex)
                    {
                        ex = null;
                        Console.WriteLine("Error: El numero debe ser entero positivo, vuelva a intentar.");
                        valid = false;
                    }
                } while (!valid);

                sum1 = suma(num_1, sum1);
                sum2 = suma(num_2, sum2);

                Console.WriteLine("\n\nResultado:");
                Console.WriteLine("---------------------------------------------------------");

                // sum1 = suma de divisores del num_1
                // sum2 = suma de divisores del num_2
                // Si la suma de divisores de num_1=num2 y viseversa, los numeros son amigos
                if ((sum1 == num_2) && (sum2 == num_1))
                {
                    Console.WriteLine("los numeros " + num_1 + " y " + num_2 + " SI son numeros amigos");
                    Console.WriteLine(" ");
                    Console.WriteLine("    + Suma divisores Primer Numero (" + num_1 + ") es: " + sum1);
                    Console.WriteLine("    + Suma divisores Segundo Numero (" + num_2 + ") es: " + sum2);
                }
                else
                {
                    Console.WriteLine("los numeros " + num_1 + " y " + num_2 + " No son numeros amigos");
                    Console.WriteLine(" ");
                    Console.WriteLine("    + Suma divisores Primer Numero (" + num_1 + ") es: " + sum1);
                    Console.WriteLine("    + Suma divisores Segundo Numero (" + num_2 + ") es: " + sum2);
                }

            }
            while (condicionSalida());
        }
    }
}
