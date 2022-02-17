/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 06/05/2021
 * Ultima modificacion: 06/05/2021
 * 
 * Descripcion del Programa:
 * Desarrollar un programa que permita el cálculo del valor de π/4 por medio de una fracción continua Fracción continua
 * El usuario debe ingresar el número de fracciones a realizar, lo cual acerca más el valor de π
 * 
 * Fuente: https://wikimedia.org/api/rest_v1/media/math/render/svg/3268a8c94ade49b8caa85c430ea369e3c25def21
 */

using System;

namespace Ejercicio006
{
    class Program
    {
        static void Main(string[] args)
        {
            //==============================================================================================================================================
            //  Funcion Principal
            //==============================================================================================================================================

            //Configuracion de Ventana
            Console.Title = "Programa 006: Pi mediante la fraccion continua";

            //Declaracion de variables
            int cantidadFracciones;
            int[] impares;
            int[] cuadrados;
            double pi;

            //Procesamiento  
            do
            {
                cantidadFracciones = 0; //Reinicio de Variables
                pi = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("============================================================");
                Console.WriteLine("          Calcular PI (mediante la fraccion continua)");
                Console.WriteLine("============================================================");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese el numero de fracciones a realizar");
                Console.WriteLine("------------------------------------------------------------");
                Console.Write("  Numero de Fracciones: "); cantidadFracciones = validarEntero("  Numero de Fracciones: ");
                Console.WriteLine("------------------------------------------------------------\n");
                Console.Write("\n");

                impares = generarImpares(cantidadFracciones);
                cuadrados = generarCuadrados(cantidadFracciones);

                pi = fraccionContinua(cantidadFracciones, cuadrados, impares) * 4;

                Console.WriteLine($"     pi = {pi} (apox)");
            }
            while (condicionSalida());
        }

        //==============================================================================================================================================
        //  Funciones Secundarias
        //==============================================================================================================================================
        public static int[] generarImpares(int n)
        {
            int[] impares = new int[n];
            impares[0] = 1;
            for (int i = 1; i < n; i++)
            {
                impares[i] = impares[i - 1] + 2;
            }
            return impares;
        }

        public static int[] generarCuadrados(int n)
        {
            int[] cuadrados = new int[n];
            cuadrados[0] = 1;

            for (int i = 1; i < n; i++)
            {
                cuadrados[i] = Convert.ToInt32(Math.Pow(i, 2));
            }
            return cuadrados;
        }

        //Esta funcion calcula pi/4 mediante la fraccion continua 
        public static double fraccionContinua(int n, int[] cuadrados, int[] impares)
        {
            double resFraccionContinua = 0;

            for (int i = (n - 1); i >= 0; i--)
            {
                resFraccionContinua = cuadrados[i] / (impares[i] + resFraccionContinua);
            }
            return resFraccionContinua;
        }

        //-----------------------------------------------------------------------------------------------------------
        //Evaluacion de condicion de salida
        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n ¿Desea volver intentarlo? [y/n]: ");

            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver intentarlo? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;  // <--- opcionSalida == 'n'
        }

        //Funcion PAra Validar Numero Entero Positivo
        public static int validarEntero(string texto)
        {
            int numeroEntrada;
            while ((!Int32.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 10000)) // <-- Validacion del dato
                Console.Write(texto);

            return numeroEntrada;
        }
    }
}
