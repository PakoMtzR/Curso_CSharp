/*
  Creado por: Francisco Martinez Rivas 1MM4
  Fecha creacion: 07/05/2021
  Ultima modificacion: 07/05/2021

  Descripcion del Programa:
  Ejecicio 5,
  Desarrollar un programa que muestre los pasos para convertir un número de punto flotante en su representación IEEE 754-1985 de precisión sencilla (32 bits) Información importante  (Enlaces a un sitio externo.)Conversor IEEE-754-1985.  (Enlaces a un sitio externo.) Permitir que el usuario ingrese los valores y se mostrará en pantalla una tabla con los pasos para la conversión.

  Fuentes: 
  http://puntoflotante.org/formats/fp/
*/

using System;
namespace convertidorIEEE754
{
    class MainClass
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
            float output;
            int input;

            //Inicio del Programa
            do
            {
                //Reset variables
                output = 0;
                input = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("          Covertidor IEEE-754 Punto Flotante             ");
                Console.WriteLine("=========================================================");
                // Usuario ingresa numero a convertir
                Console.WriteLine(" ");
                Console.WriteLine(" [Instrucciones]: Ingrese Numero a Convertir [Positivo]  ");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                do
                {
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        ex = null;
                        Console.WriteLine("Error: Valide que el numero sea entero positivo y vuelva a intentar.");
                    }
                } while (input <= 0);

                Console.WriteLine("\nResultados Conversion (32 Bits Floating Point):");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Representacion: Binary32 | Simple Precisión (32 bits)");
                Console.WriteLine("Valor (decimal): " + input);

                output = intBitsToFloat(input);

                Console.WriteLine("Valor Convertido (float): " + output);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Paginas de referencia y validacion de resultados: ");
                Console.WriteLine(".........................................................");
                Console.WriteLine("Convierte Float a Hexadecimal: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("https://gregstoll.com/~gregstoll/floattohex/");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Conviersion punto flotante a IEEE 754-1985:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("https://www.h-schmidt.net/FloatConverter/IEEE754.html");
                Console.WriteLine("https://www.zator.com/Cpp/E2_2_4a1.htm");
                Console.WriteLine("https://en.wikipedia.org/wiki/IEEE_754");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(".........................................................");
            }
            while (condicionSalida());
        }

        public static float intBitsToFloat(int bits)
        {
            /*
                Layout: 32 Bits Floating Point
                Name: Binary32 
                Common Name: Single Presicion
                Base: 2
                Significant bits: 23 + 1 (sign)= 24 bits
                Exponent bits: 8
                Exponent bias: (2^7)-1 = 127
                Exp Min: -126
                Exp Max: 127
                Fuente: https://en.wikipedia.org/wiki/IEEE_754
            */
            //uint fb = Convert.ToUInt32(bits);
            //bits = (int)fb;

            int s = ((bits >> 31) == 0) ? 1 : -1;
            int e = ((bits >> 23) & 0xff);
            int m = (e == 0) ?
                             (bits & 0x7fffff) << 1 :
                             (bits & 0x7fffff) | 0x80000;

            float fSign = (float)s;
            float fMantissa = (float)m;

            if (e != 0)
            {
                e -= 127;
            }
            else
            {
                e -= 126;
            }

            float fExponent = (float)Math.Pow(2.0, e);
            float resultado = fSign * fMantissa * fExponent;

            Console.WriteLine("Signo (float): " + fSign);
            Console.WriteLine("Mantissa (float): " + fMantissa);
            Console.WriteLine("Exponente (float): " + fExponent);

            return resultado;
        }

    }
}

