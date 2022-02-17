/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 23/03/2021
 * Ultima modificacion: 23/03/2021
 * 
 * Descripcion del Programa:
 * Programa para la generación de figuras con * 
 * 
 * Fuente: https://www.dropbox.com/s/7jme0322yrbd719/EjerciciosIII.docx?dl=0
 */

using System;

namespace Ejercicio015
{
    class Program
    {
        public static void trianguloPiramide(int filas)
        {
            string asteriscos = "*";
            //Construccion del triangulo 1
            for (int i = 1; i <= filas; i++)
            {
                for (int j = 1; j <= i; j++) Console.Write(asteriscos);
                Console.Write("\n");
            }
        }

        public static void trianguloMedioDiamante(int filas)
        {
            string asteriscos = "*";
            //Construccion del triangulo 2
            for (int i = 1; i <= filas; i++)
            {
                for (int j = 1; j <= i; j++) Console.Write(asteriscos);
                Console.Write("\n");
            }
            for (int i = (filas - 1); i >= 0; i--)
            {
                for (int j = (i - 1); j >= 0; j--) Console.Write(asteriscos);
                Console.Write("\n");
            }
        }

        public static void trianguloDiamante(int filas)
        {
            string asteriscos = "*";
            string espacio = " ";
            //Construccion del triangulo 3
            for (int i = 1; i <= filas; i++)
            {
                int n = 2 * i - 1;
                int p = filas - i;
                for (int j = 1; j <= p; j++) Console.Write(espacio);
                for (int k = 1; k <= n; k++) Console.Write(asteriscos);
                Console.Write("\n");
            }
            for (int i = (filas - 1); i >= 0; i--)
            {
                int n = 2 * i - 1;
                int p = filas - i;
                for (int j = 1; j <= p; j++) Console.Write(espacio);
                for (int k = 1; k <= n; k++) Console.Write(asteriscos);
                Console.Write("\n");
            }
        }

        //Funcion Evaluacion Dato del menu
        public static int validacionDatoMenu()
        {
            int valor;
            while (!(Int32.TryParse(Console.ReadLine(), out valor) && ((valor == 1) || (valor == 2) || (valor == 3) || (valor == 4)))) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  Opcion: ");
            }
            return valor;
        }

        //Funcion Evaluacion dato de entrada
        public static int validarDato()
        {
            int numeroEntrada;
            while ((!Int32.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 100)) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  n = ");
            }
            return numeroEntrada;
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            Console.Title = "Programa 015: figuras :3";

            //Declaracion de variables
            char opcion;
            int opcionMenu;
            int filas;

            //Procesamiento  
            do
            {
                //Reinicio de Variables
                opcionMenu = 0;
                filas = 0;
                opcion = 'y';

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================================");
                Console.WriteLine("                 Generacion de Figuras con '*' ");
                Console.WriteLine("=========================================================");
                Console.WriteLine("");
                Console.WriteLine(" [1]: Triangulo Piramide");
                Console.WriteLine(" [2]: Triangulo Medio Diamante");
                Console.WriteLine(" [3]: Triangulo Diamante");
                Console.WriteLine(" [4]: Salir");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese la opcion que desea ejecutar");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("  Opcion: ");
                opcionMenu = validacionDatoMenu();
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n");

                switch (opcionMenu)
                {
                    case 1:
                        while (opcion != 'n')
                        {
                            Console.Clear();
                            Console.WriteLine("=========================================================");
                            Console.WriteLine("                     Triangulo Piramide");
                            Console.WriteLine("=========================================================");
                            Console.WriteLine("---------------------------------------------------------");
                            Console.WriteLine(" [Instrucciones]: Ingrese el numero de filas");
                            Console.WriteLine("---------------------------------------------------------");
                            Console.Write("  n = ");
                            filas = validarDato();
                            Console.WriteLine("---------------------------------------------------------\n");
                            trianguloPiramide(filas);

                            //Evaluacion de condicion de salida
                            Console.Write("\n\n\n ¿Desea volver generar otro triangulo Diamante? [y/n]: ");

                            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y'))))
                                Console.Write("\n ¿Desea volver generar otro triangulo Diamante? [y/n]: ");
                        }
                        break;

                    case 2:
                        while (opcion != 'n')
                        {
                            Console.Clear();
                            Console.WriteLine("=========================================================");
                            Console.WriteLine("                Triangulo Medio Diamante");
                            Console.WriteLine("=========================================================");
                            Console.WriteLine("---------------------------------------------------------");
                            Console.WriteLine(" [Instrucciones]: Ingrese el numero de filas");
                            Console.WriteLine("---------------------------------------------------------");
                            Console.Write("  n = ");
                            filas = validarDato();
                            Console.WriteLine("---------------------------------------------------------\n");
                            trianguloMedioDiamante(filas);

                            //Evaluacion de condicion de salida
                            Console.Write("\n\n\n ¿Desea volver generar otro triangulo Diamante? [y/n]: ");

                            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y'))))
                                Console.Write("\n ¿Desea volver generar otro triangulo Diamante? [y/n]: ");
                        }
                        
                        break;

                    case 3:
                        while (opcion != 'n')
                        {
                            Console.Clear();
                            Console.WriteLine("=========================================================");
                            Console.WriteLine("                     Triangulo Diamante");
                            Console.WriteLine("=========================================================");
                            Console.WriteLine("---------------------------------------------------------");
                            Console.WriteLine(" [Instrucciones]: Ingrese el numero de filas");
                            Console.WriteLine("---------------------------------------------------------");
                            Console.Write("  n = ");
                            filas = validarDato();
                            Console.WriteLine("---------------------------------------------------------\n");
                            trianguloDiamante(filas);

                            //Evaluacion de condicion de salida
                            Console.Write("\n\n\n ¿Desea volver generar otro triangulo Diamante? [y/n]: ");

                            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y'))))
                                Console.Write("\n ¿Desea volver generar otro triangulo Diamante? [y/n]: ");
                        }
                        break;

                    default:
                        Console.WriteLine("[ERROR]: Cheetos :'v");
                        break;
                }
                Console.Clear();
            } 
            while (opcionMenu != 4);
        }
    }
}