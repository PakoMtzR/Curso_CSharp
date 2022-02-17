/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 03/03/2021
 * Ultima modificacion: 12/03/2021
 * 
 * Generar un algoritmo que permita Imprimir los N números de la Serie de Padovan
 * (Enlaces a un sitio externo.), donde N es un número entero positivo 
 * que el usuario debe ingresar para obtener los valores de la serie
 * 
 * Fuente: https://es.wikipedia.org/wiki/Sucesi%C3%B3n_de_Padovan
 */

using System;

namespace Ejemplo009
{
    class Program
    {
        //Funcion que construye la Serie de Padovan
        public static void seriePadovan(int cantidadElementos)
        {
            double[] elementosPadovan = new double[1];  // <-- Declaramos como tipo double para que cada localidad de memoria pueda 
                                                        //      almacenar numeros muy grandes

            //Contruccion de la serie de Padovan
            elementosPadovan = new double[cantidadElementos];   //Crea un arreglo del tamaño de la cantidad de los elementos que el usuario quiera imprimir
            if (cantidadElementos <= 3) for (int k = 0; k < cantidadElementos; k++) elementosPadovan[k] = 1;    // <-- Los primeros elementos de la serie valen 1
            else //Si se van a imprimir mas de 3 elementos de la serie entonces entra en este ciclo
            {
                for (int k = 0; k < 3; k++) elementosPadovan[k] = 1;    // <-- Los primeros elementos de la serie valen 1
                for (int k = 3; k < cantidadElementos; k++) elementosPadovan[k] = elementosPadovan[k - 2] + elementosPadovan[k - 3];
            }
            for (int k = 0; k < cantidadElementos; k++) Console.Write(" {0}", elementosPadovan[k]); // <-- Impresion de cada elemento de la serie
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            Console.Title = "Programa 009: Serie de Padovan";

            //Declaracion de variables
            char opcion = 'y';
            int n;
            
            //Procesamiento  
            while (opcion != 'n')
            {
                n = 0; //Reinicio de la variable (no es necesaria)

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================================");
                Console.WriteLine("                      Serie de Padovan");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese la cantidad de elementos de la ");
                Console.WriteLine("                  serie que quiera imprimir en consola");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("  n = "); //n = Convert.ToInt32(Console.ReadLine());
                while ((!Int32.TryParse(Console.ReadLine(), out n)) || (n <= 0) || (n > 2520)) // <-- Validacion del dato
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("  n = ");
                }
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n\t");

                //Impresion de la serie de Padovan con ayuda de la funcion
                seriePadovan(n); //n --> cantidad de elementos a imprimir de la serie

                //Evaluacion de condicion de salida
                Console.Write("\n\n\n ¿Desea volver a contruir la serie? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Desea volver a contruir la serie? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}