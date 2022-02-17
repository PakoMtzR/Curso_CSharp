/*
  Creado por: Francisco Martinez Rivas 1MM4
  Fecha creacion: 07/05/2021
  Ultima modificacion: 07/05/2021

  Descripcion del Programa:
  Ejecicio 10,
  Desarrollar un programa que permita ingresar cualquier tipo de texto (de cualquier longitud) 
  y que cuente la frecuencia de aparición de cada letra del alfabeto latino, esto el número de 
  cuántas a, b, c, d, ... hay en el texto ingresado, mostrar al final una tabla con las letras y 
  el número de apariciones de cada una.

  Fuentes: 
*/

using System;

namespace conteoLetras
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

        public static void Main(string[] args)
        {
            string abecedario = "abcdefghijklmnñopqrstuvwxyz";
            string texto;
            string strImpTxt;

            //Inicio del Programa
            do
            {
                //Reset variables
                texto = "";
                strImpTxt = "";

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("             Contador de Letras en un Texto              ");
                Console.WriteLine(".........................................................");
                Console.WriteLine("   1. Ingrese un Texto, de cualquier longuitud.          ");
                Console.WriteLine("   2. Cuenta la frecuencia de aparicion de cada letra    ");
                Console.WriteLine("=========================================================");
                // Usuario ingresa palabra/frase a analizar
                Console.WriteLine(" ");
                Console.WriteLine(" [Instrucciones]: Ingrese Texto a Analizar               ");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                texto = Console.ReadLine();

                int contador;

                foreach (char letra_abc in abecedario)
                {
                    contador = 0;
                    foreach (char letra_txt in texto.ToLower())
                    {
                        if (letra_abc == letra_txt)
                        {
                            contador++;
                        }
                    }
                    strImpTxt = strImpTxt + letra_abc.ToString() + " --> " + contador.ToString() + " \n";
                }

                // Impresion de resultados
                Console.WriteLine("\n\nResultado del Conteo:");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(strImpTxt);
            }
            while (condicionSalida());
        }
    }
}