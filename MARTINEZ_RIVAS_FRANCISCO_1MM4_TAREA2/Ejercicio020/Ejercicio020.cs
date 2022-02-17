/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 06/05/2021
 * Ultima modificacion: 06/05/2021
 * 
 * Descripcion del Programa:
 * 20.	Programa que permita realizar la simulación del Camino o Paseo Aleatorio (Random Walk) o caminata del borracho. 
 * Solicitando cuántos pasos (n) se efectuarán y de que longitud L, se deben de guardar las coordenadas (x,y) 
 * que se obtengan del camino aleatorio
 * 
 * Fuente: 
 * https://www.dropbox.com/s/xbt4cps31zf3liv/Simulaci%C3%B3n%20del%20camino%20aleatorio.docx?dl=0
 */

using System;
using System.IO;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Ejercicio020
{
    class Program
    {
        //=================================================================================
        //      Funcion Principal
        //=================================================================================
        static void Main(string[] args)
        {
            //Configuracion de Ventana
            Console.Title = "Programa 020: Random Walk";

            //Declaracion de Variables
            //Random rdm = new Random();
            int pasos;
            double x, y, distancia, angulo, longitud;
            Random aleatorio = new Random();

            //Inicio del Programa
            do
            {
                //Reinicio de Variables
                pasos = 0;
                x = 0; y = 0; distancia = 0; angulo = 0; longitud = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("                      Random Walk");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese los datos correspondientes");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write(" Cantidad de Pasos: ");  pasos = validarEntero(" Cantidad de Pasos: ");
                Console.Write(" Longitud de Pasos: ");  longitud = validarDouble(" Longitud de Pasos: ");
                Console.WriteLine("---------------------------------------------------------\n\n");

                Console.ForegroundColor = ConsoleColor.White;
                // Generando el archivo txt
                TextWriter datosRandomWalk = new StreamWriter("DatosRandomWalk.txt");

                //Impresion de Resultados
                datosRandomWalk.WriteLine("  -------------------- RESULTADOS ---------------------");
                datosRandomWalk.WriteLine("  -----------------------------------------------------");
                datosRandomWalk.WriteLine("\n");
                datosRandomWalk.WriteLine("  N  | Coordenada en X | Cordenada en Y | Angulo");
                datosRandomWalk.WriteLine("  -----------------------------------------------------");
                for (int i = 1; i <= pasos; i++)
                {
                    angulo = aleatorio.Next(0, 360) * (Math.PI / 180);
                    x += longitud * Math.Cos(angulo);
                    y += longitud * Math.Sin(angulo);
                    datosRandomWalk.WriteLine($" [{i}] | {Math.Round(x, 3)}   | {Math.Round(y, 3)}   | {Math.Round(angulo, 3)}");
                }
                distancia = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                datosRandomWalk.WriteLine("\n");
                datosRandomWalk.WriteLine("  -----------------------------------------------------");
                datosRandomWalk.WriteLine("     Coordenadas Finales: ");
                datosRandomWalk.WriteLine("  -----------------------------------------------------");
                datosRandomWalk.WriteLine($"     [x]: {Math.Round(x, 5)}");
                datosRandomWalk.WriteLine($"     [y]: {Math.Round(y, 5)}");
                datosRandomWalk.WriteLine("  -----------------------------------------------------\n");
                datosRandomWalk.WriteLine("  -----------------------------------------------------");
                datosRandomWalk.WriteLine("     Distancia entre el Punto Final y el Origen: ");
                datosRandomWalk.WriteLine("  -----------------------------------------------------");
                datosRandomWalk.WriteLine($"     Distancia = {Math.Round(distancia, 5)}");
                datosRandomWalk.WriteLine("  -----------------------------------------------------");

                datosRandomWalk.Close();

                // Leyendo el documento...
                try
                {
                    StreamReader leerDatos = new StreamReader("DatosRandomWalk.txt");
                    string line = leerDatos.ReadLine();     //Guardamos la una linea del archivo en una cadena de texto

                    while (line != null)    //Este ciclo se repetira hasta que no exista mas lineas que leer
                    {
                        Console.WriteLine(line);            //Imprime la linea de texto
                        line = leerDatos.ReadLine();    //Lee la siguiente linea de texto
                    }

                    leerDatos.Close();  //Cierra el Archivo
                }
                catch (Exception e)
                {
                    Console.WriteLine(" [Error]: " + e.Message);    //Mensaje de error si el archivo no existe en la coleccion
                }
                Console.WriteLine("\n\n----------------------------------------------------------------------------");
                Console.WriteLine(" [AVISO]: Se ha generado un archivo txt con los datos de la trayectortia");
                Console.WriteLine($"         Direccion del archivo: {Path.GetFullPath("DatosRandomWalk.txt")}");
                Console.WriteLine("----------------------------------------------------------------------------");
            }
            while (condicionSalida());
		}


        //=================================================================================
        //      Funciones Auxiliares
        //=================================================================================

        //Funcion Evaluacion de Salida
        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n ¿Desea volver a intentarlo? [y/n]: ");

            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver a intentarlo? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;  // <--- opcionSalida == 'n'
        }

        //Validar Dato de tipo Double
        public static double validarDouble(string dato)
        {
            double numeroEntrada;   //Declaracion de variables
            while ((!Double.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 100000))
                Console.Write($"{dato}");

            return numeroEntrada;
        }

        //Validar Dato de tipo Entero
        public static int validarEntero(string dato)
        {
            int numeroEntrada;//Declaracion de variables
            while ((!Int32.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 118))
                Console.Write($"{dato}");

            return numeroEntrada;
        }
    }
}