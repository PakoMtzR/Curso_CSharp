/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 12/04/2021
 * Ultima modificacion: 04/05/2021
 * 
 * Descripcion del Programa:
 * Programa que permita obtener el perímetro y el área de ciertas figuras geométricas: 
 * cuadrado, rectángulo, triángulo (de cualquier tipo), círculo, rombo, trapecio, polígono regular. 
 * El programa debe utilizar Programación Orientada a Objetos en donde cada una de las figuras 
 * será una clase que contenga los atributos necesarios para lograr el cálculo tanto del área como del perímetro
 */

using System;

namespace Ejercicio001
{
    class Program
    {
        //==============================================================================================================================================
        //  Declaracion de Clases (POO)
        //==============================================================================================================================================
        public class figura     // <--- Clase padre
        {
            public double perimetro;
            public double area;

            public figura()
            {
                this.perimetro = 0;
                this.area = 0;
            }
        }

        public class cuadrado : figura
        {
            public cuadrado (float longitudLadoEntrada)
            {
                perimetro = 4 * longitudLadoEntrada;
                area = Math.Pow(longitudLadoEntrada, 2);
            }
        }

        public class rectangulo : figura
        {
            public rectangulo (float medidaBase, float altura)
            {
                perimetro = (2 * medidaBase) + (2 * altura);
                area = medidaBase * altura;
            }
        }

        public class triangulo : figura
        {
            public triangulo (float medidaBase, float altura, float lado1, float lado2)
            {
                perimetro = lado1 + lado2 + medidaBase;
                area = (medidaBase * altura) / 2;
            }
        }
        
        public class circulo : figura
        {
            public circulo (float radio)
            {
                perimetro = 2 * Math.PI * radio;
                area = Math.PI * radio * radio;
            }
        }
        
        public class rombo : figura
        {
            public rombo (float diagonalMayor, float diagonalMenor)
            {
                perimetro = 4 * Math.Sqrt((Math.Pow((diagonalMayor / 2), 2) + Math.Pow((diagonalMenor / 2), 2)));
                area = (diagonalMayor * diagonalMenor) / 2;
            }
        }

        public class trapecio : figura
        {
            public trapecio (float baseMayor, float baseMenor, float altura)
            {
                perimetro = (2 * Math.Sqrt(Math.Pow(altura, 2) + Math.Pow(((baseMayor - baseMenor) / 2), 2))) + baseMayor + baseMenor;
                area = (baseMayor + baseMenor) * altura / 2;
            }
        }

        public class poligonoRegular : figura
        {
            public poligonoRegular (int numeroLados, float medidaBase)
            {
                perimetro = numeroLados * medidaBase;
                area = (perimetro * numeroLados) / (4 * Math.Tan(Math.PI / numeroLados));     //(perimetro * apotema) / 2; (360 / (2 * numeroLados)) * (Math.PI / 180)
            }
        }


        //==============================================================================================================================================
        //  Funciones Secundarias
        //==============================================================================================================================================
        public static int validacionDatoMenu()
        {
            int valor;
            while (!Int32.TryParse(Console.ReadLine(), out valor) || (valor <= 0) || (valor > 8)) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  Opcion: ");
            }
            return valor;
        }

        public static float validarNumeroDecimal(string texto)
        {
            float numeroEntrada;
            while ((!float.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 100)) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(texto);
            }
            return numeroEntrada;
        }

        public static int validarNumeroEntero(string texto)
        {
            int numeroEntrada;
            while ((!Int32.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 100)) // <-- Validacion del dato
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(texto);
            }
            return numeroEntrada;
        }

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

        public static void imprimirMenu(string figura)
        {
            Console.Clear();
            Console.WriteLine("=========================================================");
            Console.WriteLine("      Calcular Area y Perimetro de un {0}", figura);
            Console.WriteLine("=========================================================");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(" [Instrucciones]: Ingrese los datos que se le solicitan");
            Console.WriteLine("---------------------------------------------------------\n");
        }

        public static void imprimirResultados(double perimetro, double area)
        {
            Console.WriteLine("\n=========================================================");
            Console.WriteLine("\n     Resultados:\n");
            Console.WriteLine("                 Perimetro = {0}u", perimetro);
            Console.WriteLine("                      Area = {0}u²\n", area);
            Console.WriteLine("=========================================================");
        }

        //==============================================================================================================================================
        //  Funcion Principal
        //==============================================================================================================================================
        static void Main(string[] args)
        {
            //Configuracion de Ventana
            Console.Title = "Programa 001: Figuras Geometricas";

            //Declaracion de variables
            int opcionMenu;
            var figura = ("Cuadrado", "Rectangulo", "Triangulo", "Circulo", "Rombo", "Trapecio", "Poligono Regular");
            
            //Procesamiento
            do
            {
                //Impresion del Titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================================");
                Console.WriteLine("                 Area y Perimetro de Figuras");
                Console.WriteLine("=========================================================");
                Console.WriteLine("");
                Console.WriteLine(" [1]: Cuadrado");
                Console.WriteLine(" [2]: Rectangulo");
                Console.WriteLine(" [3]: Triangulo");
                Console.WriteLine(" [4]: Circulo");
                Console.WriteLine(" [5]: Rombo");
                Console.WriteLine(" [6]: Trapecio");
                Console.WriteLine(" [7]: Poligono Regular");
                Console.WriteLine(" ");
                Console.WriteLine(" [8]: Salir");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese la opcion que desea ejecutar");
                Console.WriteLine("---------------------------------------------------------");
                    Console.Write("  Opcion: ");    opcionMenu = validacionDatoMenu();
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n");

                switch (opcionMenu)
                {
                    // Cuadrado
                    case 1:
                        do
                        {
                            float lado = 0;                                                                             //Declaracion de Variable
                            imprimirMenu(figura.Item1);                                                                 //Impresion del Titulo
                            Console.Write(" Medida del lado = "); lado = validarNumeroDecimal(" Medida del lado = ");   //Entrada de datos
                            cuadrado miCuadrado = new cuadrado(lado);                                                   //Creacion del objeto cuadrado
                            imprimirResultados(miCuadrado.perimetro, miCuadrado.area);                                  //Impresion de Resultados
                        } 
                        while (condicionSalida());  //Evaluacion de la condicion de salida
                        break;

                    // Rectangulo
                    case 2:
                        do
                        {
                            float baseRectangulo = 0, alturaRectangulo = 0;                                     //Declaracion de Variable
                            imprimirMenu(figura.Item2);                                                         //Impresion del Titulo
                            Console.Write("   Base = ");   baseRectangulo = validarNumeroDecimal("   Base = "); //Entrada de datos
                            Console.Write(" Altura = "); alturaRectangulo = validarNumeroDecimal(" Altura = ");
                            rectangulo miRectangulo = new rectangulo(baseRectangulo, alturaRectangulo);         //Creacion del objeto rectangulo
                            imprimirResultados(miRectangulo.perimetro, miRectangulo.area);                      //Impresion de Resultados
                        }
                        while (condicionSalida());  //Evaluacion de la condicion de salida
                        break;

                    // Triangulo
                    case 3:
                        do
                        {
                            float baseTriangulo = 0, alturaTriangulo = 0, lado1T = 0, lado2T = 0;               //Declaracion de Variable
                            imprimirMenu(figura.Item3);                                                         //Impresion del Titulo
                            Console.Write("   Base = ");   baseTriangulo = validarNumeroDecimal("   Base = ");  //Entrada de datos
                            Console.Write("  Lado1 = ");          lado1T = validarNumeroDecimal("  Lado1 = ");
                            Console.Write("  Lado2 = ");          lado2T = validarNumeroDecimal("  Lado2 = ");
                            Console.Write(" Altura = "); alturaTriangulo = validarNumeroDecimal(" Altura = ");
                            triangulo miTriangulo = new triangulo(baseTriangulo, alturaTriangulo, lado1T, lado2T);  //Creacion del objeto triangulo
                            imprimirResultados(miTriangulo.perimetro, miTriangulo.area);                        //Impresion de Resultados
                        }
                        while (condicionSalida());  //Evaluacion de la condicion de salida
                        break;

                    // Circulo
                    case 4:
                        do
                        {
                            float radioCirculo = 0;                                                         //Declaracion de Variable
                            imprimirMenu(figura.Item4);                                                     //Impresion del Titulo
                            Console.Write(" Radio = "); radioCirculo = validarNumeroDecimal(" Radio = ");   //Entrada de datos
                            circulo miCirculo = new circulo(radioCirculo);                                  //Creacion del objeto Circulo
                            imprimirResultados(miCirculo.perimetro, miCirculo.area);
                        }
                        while (condicionSalida());  //Evaluacion de la condicion de salida
                        break;

                    // Rombo        
                    case 5:
                        do
                        {
                            float diagonalMayorRombo = 0, diagonalMenorRombo = 0;                                                   //Declaracion de Variable
                            imprimirMenu(figura.Item5);                                                                             //Impresion del Titulo
                            Console.Write("  Diagonal Mayor = "); diagonalMayorRombo = validarNumeroDecimal("  Diagonal Mayor = "); //Entrada de datos
                            Console.Write("  Diagonal Menor = "); diagonalMenorRombo = validarNumeroDecimal("  Diagonal Menor = ");
                            rombo miRombo = new rombo(diagonalMayorRombo, diagonalMenorRombo);                                      //Creacion del objeto Rombo
                            imprimirResultados(miRombo.perimetro, miRombo.area);
                        }
                        while (condicionSalida());  //Evaluacion de la condicion de salida
                        break;

                    // Trapecio
                    case 6:
                        do
                        {
                            float baseMayorTrapecio = 0, baseMenorTrapecio = 0, alturaTrapecio = 0;                         //Declaracion de Variable
                            imprimirMenu(figura.Item6);                                                                     //Impresion del Titulo  
                            Console.Write(" Base Mayor = "); baseMayorTrapecio = validarNumeroDecimal(" Base Mayor = ");    //Entrada de datos
                            Console.Write(" Base Menor = "); baseMenorTrapecio = validarNumeroDecimal(" Base Menor = ");
                            Console.Write("     Altura = ");    alturaTrapecio = validarNumeroDecimal("     Altura = ");
                            trapecio miTrapecio = new trapecio(baseMayorTrapecio, baseMenorTrapecio, alturaTrapecio);       //Creacion del objeto trapecio
                            imprimirResultados(miTrapecio.perimetro, miTrapecio.area);
                        }
                        while (condicionSalida());  //Evaluacion de la condicion de salida
                        break;

                    // Poligono Regular
                    case 7:
                        do
                        {
                            int numeroLadosP = 0;                                                                               //Declaracion de Variable
                            float medidaLadoP = 0;
                            imprimirMenu(figura.Item7);                                                                         //Impresion del Titulo
                            Console.Write(" Numero de Lados = "); numeroLadosP = validarNumeroEntero(" Numero de Lados = ");    //Entrada de datos
                            Console.Write(" Medida de Lados = "); medidaLadoP = validarNumeroDecimal(" Medida de Lados = ");
                            poligonoRegular miPoligono = new poligonoRegular(numeroLadosP, medidaLadoP);                        //Creacion del objeto Poligono Regular
                            imprimirResultados(miPoligono.perimetro, miPoligono.area);
                        }
                        while (condicionSalida());  //Evaluacion de la condicion de salida
                        break;
                }
                Console.Clear(); //Limpiar pantalla
            } 
            while (opcionMenu != 8); //Opcion de salida == 8
        }
    }
}