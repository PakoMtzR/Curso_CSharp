/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 06/05/2021
 * Ultima modificacion: 06/05/2021
 * 
 * Descripcion del Programa:
 * Programa que permita obtener los datos de un tiro parabólico para el cual 
 * se le ingresen los valores de la velocidad incial v0, el ángulo inicial θ0, la altura inicial 
 * de donde saldrá el proyectil h0 y la aceleración de la gravedad que afectará al proyectil, 
 * así como los pasos δt que se tomarán para realizar la simulación, la cual deberá detenerse 
 * cuando el proyectil llegue al suelo y = 0. Los datos de la simulación deben de guardarse 
 * en un archivo de texto (.txt) con formato de tabla |i x y t |, donde i es el paso, 
 * la posición en (x,y) y el tiempo t de vuelo del proyectil
 * 
 */

using System;
using System.IO;

namespace Ejercicio019
{
    class Program
    {
        public const double g = 9.81;

        static void Main(string[] args)
        {


            //Configuracion de Ventana
            Console.Title = "Programa 019: Tiro Parabolico";

            //Declaracion de variables
            double velocidad_Inicial;
            double angulo;
            double altura_Inicial;
            int pasos;
            

            //Procesamiento  
            do
            {
                velocidad_Inicial = 0;
                angulo = 0;
                altura_Inicial = 0;
                pasos = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("==============================================================");
                Console.WriteLine("                         Tiro Parabolico ");
                Console.WriteLine("==============================================================");
                Console.WriteLine(" Este programa permite obtener los datos de un tiro parabolico");
                Console.WriteLine("");
                Console.WriteLine(" [Instrucciones]: Ingrese los datos que se le solicitan");
                Console.WriteLine("--------------------------------------------------------------");
                    Console.Write("     Velocidad Inicial [m/s]: "); velocidad_Inicial = validarDouble("     Velocidad Inicial: ");
                    Console.Write(" Angulo de lanzamiento [deg]: "); angulo = validarAngulo(" Angulo de lanzamiento: ");
                    Console.Write("          Altura Inicial [m]: "); altura_Inicial = validarDouble("        Altura Inicial: ");
                    Console.Write("             Numero de Pasos: "); pasos = validarEntero("       Numero de Pasos: ");
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.White;

                TextWriter datosTiroParabolico = new StreamWriter("DatosTiroParabolico.txt");
                datosTiroParabolico.WriteLine("==================================================");
                datosTiroParabolico.WriteLine("             Datos del Tiro Parabolico");
                datosTiroParabolico.WriteLine("==================================================");
                datosTiroParabolico.WriteLine("");
                datosTiroParabolico.WriteLine(" Datos:");
                datosTiroParabolico.WriteLine($"     1) Velocidad Inicial = {velocidad_Inicial} m/s");
                datosTiroParabolico.WriteLine($"     2) Angulo Inicial = {angulo * (180/Math.PI)}°");
                datosTiroParabolico.WriteLine($"     3) Altura Inicial = {altura_Inicial} m");
                datosTiroParabolico.WriteLine("--------------------------------------------------");
                datosTiroParabolico.WriteLine("");

                //----------------------------------------------------------------
                double intervalosTiempo = tiempoDeCaida(velocidad_Inicial, angulo, altura_Inicial) / pasos;
                double time;
                int i;
                datosTiroParabolico.WriteLine("             DATOS DE LA TRAYECTORIA");
                datosTiroParabolico.WriteLine("--------------------------------------------------");
                datosTiroParabolico.WriteLine("  N  | Posicion X  | Posicion Y | Tiempo");
                datosTiroParabolico.WriteLine("--------------------------------------------------");
                for (i = 0, time = 0; i <= pasos; i++, time += intervalosTiempo)
                {
                    datosTiroParabolico.WriteLine($" [{i}] | {Math.Round(posicionX(velocidad_Inicial, angulo, time), 3)} m     | {Math.Round(posicionY(velocidad_Inicial, angulo, altura_Inicial, time), 3)} m   | {Math.Round(time, 3)} seg");
                }
                //-------------------------------------------------------------------
                datosTiroParabolico.Close();

                try
                {
                    StreamReader leerDatos = new StreamReader("DatosTiroParabolico.txt");
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
                Console.WriteLine($"         Direccion del archivo: {Path.GetFullPath("DatosTiroParabolico.txt")}");
                Console.WriteLine("----------------------------------------------------------------------------");
            }
            while (condicionSalida());

        }

        //==============================================================================================
        // Calculos para obtener la posicion en X y Y, asi como el tiempo de caida en funcion del tiempo
        //==============================================================================================
        public static double posicionX(double velocidad_o, double angulo, double tiempo)
        {
            double posicionX = 0;
            posicionX = velocidad_o * Math.Cos(angulo) * tiempo;
            return posicionX;
        }

        public static double posicionY(double velocidad_o, double angulo, double altura_o, double tiempo)
        {
            double posicionY = 0;
            posicionY = altura_o + (velocidad_o * Math.Sin(angulo) * tiempo) - (g * Math.Pow(tiempo, 2)) / 2;
            return posicionY;
        }

        public static double tiempoDeCaida(double velocidad_o, double angulo, double altura_o)
        {
            double tiempoDeCaida = 0;
            tiempoDeCaida = ((velocidad_o * Math.Sin(angulo)) + Math.Pow((Math.Pow((velocidad_o * Math.Sin(angulo)), 2) + (2 * g * altura_o)), 0.5)) / g;
            return tiempoDeCaida;
        }

        //==============================================================================================
        // Funciones para la validacion de Datos
        //==============================================================================================

        //Funcion para la Validacion de dato Entero
        public static int validarEntero(string dato)
        {
            int valor;
            while ((!Int32.TryParse(Console.ReadLine(), out valor)) || (valor <= 2) || (valor > 10000)) // <-- Validacion del dato
                Console.Write($"{dato}");

            return valor;
        }

        //Funcion para la Validacion de dato Double
        public static double validarDouble(string dato)
        {
            double valor;
            while ((!double.TryParse(Console.ReadLine(), out valor)) || (valor < 0) || (valor > 10000)) // <-- Validacion del dato
                Console.Write($"{dato}");

            return valor;
        }

        //Funcion para la Validacion del angulo
        public static double validarAngulo(string dato)
        {
            double angulo;
            while ((!double.TryParse(Console.ReadLine(), out angulo)) || (angulo < 0) || (angulo > 360)) // <-- Validacion del dato
                Console.Write($"{dato}");

            return angulo*(Math.PI/180);
        }

        //Evaluacion Condicion de Salida
        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n ¿Desea volver intentarlo? [y/n]: ");

            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver intentarlo? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;  // <--- opcionSalida == 'n'
        }
    }
}