/*
  Creado por: Francisco Martinez Rivas 1MM4
  Fecha creacion: 07/05/2021
  Ultima modificacion: 07/05/2021

  Descripcion del Programa:
  Ejecicio 14,
  Desarrollar un programa que permita obtener la diferencia entre dos fechas, una la que ingresa el usuario y la otra es la fecha del sistema. Mostrar la diferencia ya sea en días totales o en días, meses y años de diferencia, esto puede ser seleccionado por el usuario

  Fuentes: 
  https://www.dropbox.com/s/mfq9mw5ugdgpw9l/Numeraciones.pdf?dl=0
*/

using System;

namespace DatesDifference
{
    class Program
    {
        //Funcion Evaluacion de Salida
        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n ¿Desea volver a intentarlo? [y/n]: ");

            //Evalua condicion de salida, solo acepta [Y/N]
            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver a intentarlo? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;
        }

        //Evalua diferencia entre la fecha del usuario y la fecha del sistema.
        public static string ElapsedTime(DateTime fechaUsuario)
        {
            TimeSpan TS = DateTime.Now - fechaUsuario;

            double intYears = Math.Round(TS.Days / 365.2425, 2);
            double intMonths = Math.Round(TS.Days / 30.436875, 2);
            double intDays = TS.Days;

            return ($"Años: {intYears}    Meses: {intMonths}    Dias: {intDays}");
        }

        //Funcion principal
        static void Main(string[] args)
        {
            // Declaracion de variables
            DateTime fecha_1;
            string difFechas;
            bool valid;

            //Inicio del Programa
            do
            {
                //Inicio del Programa
                valid = false;
                difFechas = "";
                fecha_1 = DateTime.Now;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine(" Calcula Diferencia entre Fecha Usuario y Fecha Sistema  ");
                Console.WriteLine(".........................................................");
                Console.WriteLine(" 1. Obtener diferencia entre 2 fechas:                   ");
                Console.WriteLine("      - Fecha ingresada por el usuario                   ");
                Console.WriteLine("      - Fecha del sistema                                ");
                Console.WriteLine(" 2. Muestra diferencia en días días, meses y años        ");
                Console.WriteLine("=========================================================");
                // Usuario ingresa palabra/frase a analizar
                Console.WriteLine(" ");
                Console.WriteLine("[Instrucciones]: Ingrese Fecha [MM/DD/YYYY]:             ");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                do
                {
                    try
                    {
                        fecha_1 = DateTime.Parse(Console.ReadLine());
                        valid = true;
                    }
                    catch (Exception ex)
                    {
                        ex = null;
                        Console.WriteLine("Error: Fecha invalida, vuelva a intentar.");
                        valid = false;
                    }
                } while (!valid);

                // Calcula diferencia de fechas
                difFechas = ElapsedTime(fecha_1);

                // Impresion de resultados
                Console.WriteLine("\n\nResultados: ");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(difFechas);
            }
            while (condicionSalida());
        }
    }
}
