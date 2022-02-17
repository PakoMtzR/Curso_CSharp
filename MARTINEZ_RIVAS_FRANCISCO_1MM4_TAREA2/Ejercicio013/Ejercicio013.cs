/*
  Creado por: Francisco Martinez Rivas 1MM4
  Fecha creacion: 07/05/2021
  Ultima modificacion: 07/05/2021

  Descripcion del Programa:
  Ejecicio 13,
  Programa que reciba un número digitado por el usuario y que muestre su representación en texto en pantalla. El número puede mostrarse en alguno de los idiomas mostrados en la siguiente tabla: Numeración en diferentes idiomas (Enlaces a un sitio externo.)

  Fuentes: 
  https://www.dropbox.com/s/mfq9mw5ugdgpw9l/Numeraciones.pdf?dl=0
*/

using System;

namespace Convertidor
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

        static void Main(string[] args)
        {
            string numToConvert;
            string numConverted;
            bool valid;
            int validaNum;

            do
            {
                //Inicio del Programa
                valid = false;
                validaNum = 0;
                numToConvert = "";
                numConverted = "";

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("       Conversion de Numeros (Positivos) a Texto         ");
                Console.WriteLine(".........................................................");
                Console.WriteLine(" 1. Recibe un Numero y muestra su representacion en Texto");
                Console.WriteLine(" 2. El idioma es Español                                 ");
                Console.WriteLine("=========================================================");
                // Usuario ingresa palabra/frase a analizar
                Console.WriteLine(" ");
                Console.WriteLine("[Instrucciones]: Ingrese Numero [Entero Positivo]:       ");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                do
                {
                    try
                    {
                        numToConvert = Console.ReadLine();
                        validaNum = Convert.ToInt32(numToConvert);
                        valid = true;
                    }
                    catch (Exception ex)
                    {
                        ex = null;
                        Console.WriteLine("Error: El numero debe ser entero positivo, vuelva a intentar.");
                        valid = false;
                    }
                } while (!valid);

                // Convierte Numero a Texto
                numConverted = Conversiones.NumeroALetras(numToConvert);

                // Impresion de resultados
                Console.WriteLine("\n\nConversion a Texto:");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(numConverted);
            }
            while (condicionSalida());
        }

        public class Conversiones
        {
            public static string NumeroALetras(string num)
            {
                string res, dec = "";
                Int64 entero;
                int decimales;
                double nro;

                try
                {
                    nro = Convert.ToDouble(num);
                }
                catch
                {
                    return "";
                }

                entero = Convert.ToInt64(Math.Truncate(nro));
                decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));

                if (decimales > 0)
                {
                    dec = " CON " + decimales.ToString() + "/100";
                }

                res = Conversiones.NumeroALetras(Convert.ToDouble(entero)) + dec;
                return res;
            }

            private static string NumeroALetras(double value)
            {
                string Num2Text = "";
                value = Math.Truncate(value);

                if (value == 0) Num2Text = "CERO";
                else if (value == 1) Num2Text = "UNO";
                else if (value == 2) Num2Text = "DOS";
                else if (value == 3) Num2Text = "TRES";
                else if (value == 4) Num2Text = "CUATRO";
                else if (value == 5) Num2Text = "CINCO";
                else if (value == 6) Num2Text = "SEIS";
                else if (value == 7) Num2Text = "SIETE";
                else if (value == 8) Num2Text = "OCHO";
                else if (value == 9) Num2Text = "NUEVE";
                else if (value == 10) Num2Text = "DIEZ";
                else if (value == 11) Num2Text = "ONCE";
                else if (value == 12) Num2Text = "DOCE";
                else if (value == 13) Num2Text = "TRECE";
                else if (value == 14) Num2Text = "CATORCE";
                else if (value == 15) Num2Text = "QUINCE";
                else if (value < 20) Num2Text = "DIECI" + NumeroALetras(value - 10);
                else if (value == 20) Num2Text = "VEINTE";
                else if (value < 30) Num2Text = "VEINTI" + NumeroALetras(value - 20);
                else if (value == 30) Num2Text = "TREINTA";
                else if (value == 40) Num2Text = "CUARENTA";
                else if (value == 50) Num2Text = "CINCUENTA";
                else if (value == 60) Num2Text = "SESENTA";
                else if (value == 70) Num2Text = "SETENTA";
                else if (value == 80) Num2Text = "OCHENTA";
                else if (value == 90) Num2Text = "NOVENTA";

                else if (value < 100) Num2Text = NumeroALetras(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetras(value % 10);
                else if (value == 100) Num2Text = "CIEN";
                else if (value < 200) Num2Text = "CIENTO " + NumeroALetras(value - 100);
                else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = NumeroALetras(Math.Truncate(value / 100)) + "CIENTOS";

                else if (value == 500) Num2Text = "QUINIENTOS";
                else if (value == 700) Num2Text = "SETECIENTOS";
                else if (value == 900) Num2Text = "NOVECIENTOS";
                else if (value < 1000) Num2Text = NumeroALetras(Math.Truncate(value / 100) * 100) + " " + NumeroALetras(value % 100);
                else if (value == 1000) Num2Text = "MIL";
                else if (value < 2000) Num2Text = "MIL " + NumeroALetras(value % 1000);
                else if (value < 1000000)
                {
                    Num2Text = NumeroALetras(Math.Truncate(value / 1000)) + " MIL";
                    if ((value % 1000) > 0) Num2Text = Num2Text + " " + NumeroALetras(value % 1000);
                }

                else if (value == 1000000) Num2Text = "UN MILLON";
                else if (value < 2000000) Num2Text = "UN MILLON " + NumeroALetras(value % 1000000);
                else if (value < 1000000000000)
                {
                    Num2Text = NumeroALetras(Math.Truncate(value / 1000000)) + " MILLONES ";
                    if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000) * 1000000);
                }
                else if (value == 1000000000000) Num2Text = "UN BILLON";
                else if (value < 2000000000000) Num2Text = "UN BILLON " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                else
                {
                    Num2Text = NumeroALetras(Math.Truncate(value / 1000000000000)) + " BILLONES";
                    if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                }

                return Num2Text;
            }
        }
    }
}
