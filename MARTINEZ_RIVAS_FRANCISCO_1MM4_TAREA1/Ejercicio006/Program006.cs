/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 01/03/2021
 * Ultima modificacion: 22/03/2021
 * 
 * Descripcion del Programa:
 * Generar un algoritmo que obtenga el Máximo Común Divisor (MCD) 
 * y el mínimo común múltiplo de un par de números enteros positivos. 
 * (Existe un algoritmo ya establecido para este caso, se le conoce como algoritmo de Euclídes)
 * 
 * Fuentes:
 * 1) https://www.youtube.com/watch?v=x6qFMSRpgpM
 * 2) https://es.khanacademy.org/computing/computer-science/cryptography/modarithmetic/a/the-euclidean-algorithm
 */

using System;

namespace Ejercicio006
{
    class Program
    {
        //Funcion para la validacion de dato
        public static int validarDato(char letra)
        {
            int numero;
            Console.Write("  {0} = ", letra); //numA = Convert.ToInt32(Console.ReadLine());
            while ((!Int32.TryParse(Console.ReadLine(), out numero)) || (numero < 0)) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  {0} = ", letra);
            }
            return numero;
        }

        static void Main(string[] args)
        {
            Console.Title = "Programa 006: Calculo de M.C.M y M.C.D";

            //Declaracion de variables
            char opcion = 'y';
            int numA, numB, aux, i, j, residuo, mcd, mcm;

            //Procesamiento 
            while (opcion != 'n')
            {
                //Reinicio las variables
                numA = 0; numB = 0; aux = 0; residuo = 1;
                mcd = 0; mcm = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================================");
                Console.WriteLine("    Calculo de M.C.M y M.C.D de una pareja de numeros");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Intrucciones]: Ingresa los la valores de las parejas");
                Console.WriteLine("                 de numeros correspondientes.");
                Console.WriteLine("---------------------------------------------------------");

                //Entrada y validacion de datos
                numA = validarDato('A');
                numB = validarDato('B');
                Console.WriteLine("---------------------------------------------------------\n");

                //Calculo del MCD y MCM
                if ((numA == 0) && (numB == 0)) mcd = 0;
                else if (numA == 0) mcd = numB;
                else if (numB == 0) mcd = numA;
                else
                {
                    if (numA < numB) //Modificamos los datos para que numA sea siempre el mayor
                    {
                        aux = numA;
                        numA = numB;
                        numB = aux;
                    }

                    //Creamos variables modificables y conservamos los valores iniciales para calcular el mcm
                    i = numA;
                    j = numB;

                    while (residuo != 0) //Calculamos el mcd con el logaritmo de Euclides
                    {
                        residuo = i % j;
                        mcd = j;
                        i = j;
                        j = residuo;
                    }
                    mcm = (numA * numB) / (mcd); //Calculamos el mcm
                }

                //Imprimiendo datos de salida
                Console.WriteLine("\n  Resultados: ");
                Console.WriteLine("  ------------------------------");
                Console.WriteLine("\tM.C.D = {0}", mcd);
                Console.WriteLine("\tM.C.M = {0}", mcm);
                Console.WriteLine("  ------------------------------");
                
                //Evaluacion de condicion de salida
                Console.Write("\n\n\n ¿Deseas evaluar otra pareja de numeros? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Deseas evaluar otra pareja de numeros? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}