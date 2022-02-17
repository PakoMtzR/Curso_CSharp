/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 025/03/2021
 * Ultima modificacion: 25/03/2021
 * 
 * ------------------------------------------------------------------------------------------------------------------------------------------
 * Descripcion del Programa:
 * 
 * Generar el programa en C# que permita obtener las soluciones de un polinomio de segundo grado de la forma:
 * 
 *                                          p(x)=ax2+bx+c
 * 
 * El algoritmo tendrá como valores de entrada los coeficientes a, b, c, como números reales, los cuáles serán 
 * ingresados mediante el teclado (indicar perfectamente al usuario que coeficiente se está ingresando), 
 * y como salida, debe calcular las dos soluciones posibles: x1 y x2. Mostrar además la ecuación ingresada.
 * 
 * Nota: Se deben considerar todos los tipos de solución (real con soluciones iguales, real con soluciones diferentes y soluciones complejas),
 * lo cual puede anticiparse mediante el uso del discriminante b2−4ac
 * -------------------------------------------------------------------------------------------------------------------------------------------
 */

using System;

namespace examen_part01
{
    class Program
    {
        //Funcion que calcula del discriminante
        public static double valorDiscriminante(double a, double b, double c)
        {
            double valorDiscriminante = ((Math.Pow(b, 2)) - (4 * a * c));
            return valorDiscriminante;
        }

        //Funcion para validar datos de entrada
        public static float validarDato(char letra)
        {
            float numeroEntrada;
            while (!float.TryParse(Console.ReadLine(), out numeroEntrada))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("     {0} = ", letra);
            }
            return numeroEntrada;
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            Console.Title = "Programa Examen parte 1";

            //Declaracion de variables
            char opcion = 'y';
            double[] coeficientes = new double[3];
            char[] letras = {'A', 'B', 'C'};
            double[] soluciones = new double[2];
            double discriminante;

            //Procesamiento  
            do
            {
                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===============================================================");
                Console.WriteLine("                  Soluciones de un Polinomio");
                Console.WriteLine("===============================================================");
                Console.WriteLine("");
                Console.WriteLine("                     P(x) = Ax² + Bx + C");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese los valores de los coeficeintes");
                Console.WriteLine("                  A, B, C para obtener soluciones del polinomio");
                Console.WriteLine("---------------------------------------------------------------");

                //Ingreso de los coeficientes
                for (int i = 0; i <= 2; i++)
                {
                    Console.Write("     {0} = ", letras[i]);
                    coeficientes[i] = validarDato(letras[i]); 
                }

                Console.WriteLine("---------------------------------------------------------------");
                Console.Write("     Soluciones: P(x) = ({0})x² + ({1})x + ({2})\n", coeficientes[0], coeficientes[1], coeficientes[2]);
                Console.WriteLine("---------------------------------------------------------------\n");

                discriminante = valorDiscriminante(coeficientes[0], coeficientes[1], coeficientes[2]);

                //Dos soluciones en los reales
                if (discriminante > 0)
                {
                    soluciones[0] = (-1*coeficientes[1] +1*(Math.Pow(discriminante, 0.5))) / (2 * coeficientes[0]);
                    soluciones[1] = (-1*coeficientes[1] -1*(Math.Pow(discriminante, 0.5))) / (2 * coeficientes[0]);
                    for (int i = 0; i <= 1; i++) Console.WriteLine("\tx[{0}] = {1}", (i + 1), soluciones[i]);
                }

                //Una sola solucion dentro de los reales
                else if (discriminante == 0)
                {
                    soluciones[0] = (-1*coeficientes[1]) / (2 * coeficientes[0]);
                    //soluciones[1] = 0;
                    Console.WriteLine("\tx[{0}] = {1}", 1, soluciones[0]);
                }
                
                //Solucion con numero Imaginarios
                else
                {
                    string solucionImaginaria;
                    solucionImaginaria = ((Math.Pow(-1 * discriminante, 0.5)) / (2*coeficientes[0])).ToString() + "i";
                    soluciones[0] = -1*coeficientes[1] / 2 * coeficientes[0];
                    soluciones[1] = -1*coeficientes[1] / 2 * coeficientes[0];
                    Console.WriteLine("\tx[{0}] = {1} + {2}", 1, soluciones[0], solucionImaginaria);
                    Console.WriteLine("\tx[{0}] = {1} - {2}", 2, soluciones[1], solucionImaginaria);
                }

                //Evaluacion de condicion de salida
                Console.Write("\n\n\n ¿Desea volver a evaluar otra ecuacion? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());

                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y'))))
                    Console.Write("\n ¿Desea volver a evaluar otra ecuacion? [y/n]: ");

                Console.Clear();
            }   
            while (opcion != 'n');
        }
    }
}