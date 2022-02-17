/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 25/04/2021
 * Ultima modificacion: 25/04/2021
 * 
 * Descripcion del Programa:
 * Generar un programa usando el paradigma de POO en el que se permita, por un lado, ingresar los 
 * datos de los elementos químicos (Nombre del elemento, Símbolo, Número Atómico, Masa Atómica, Radio atómico, Estado ordinario) 
 * y que pueda ser almacenado en un archivo de texto (.txt). Por otro lado, debe contar con una opción para observar 
 * los datos almacenados de los elementos, al pedir al usuario que ingrese ya sea el nombre o el número del elemento 
 * (se debe revisar que elementos se encuentran disponibles)
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio004
{
    class Program
    {
        //=================================================================================
        //      Declaracion de Clase Persona
        //=================================================================================
        public class elementoQuimico
        {
            public string nombre;
            public string simbolo;
            public int numeroAtomico;
            public double masaAtomica;
            public double radioAtomico;
            public string estadoOrdiario;

            public elementoQuimico(string nombreInput, string simboloInput, int numeroAtomicoInput, double masaAtomicaInput, double radioAtomicoInput, string estadoOrdiarioInput)
            {
                nombre = nombreInput.ToUpper();
                simbolo = simboloInput.ToUpper();
                numeroAtomico = numeroAtomicoInput;
                masaAtomica = masaAtomicaInput;
                radioAtomico = radioAtomicoInput;
                estadoOrdiario = estadoOrdiarioInput.ToUpper();

                TextWriter elementoArchivo = new StreamWriter($"{nombre}.txt");
                elementoArchivo.WriteLine("====================================");
                elementoArchivo.WriteLine($"         Elemento: {nombre}");
                elementoArchivo.WriteLine("====================================");
                elementoArchivo.WriteLine($"          Simbolo: {simbolo}");
                elementoArchivo.WriteLine($"   Numero Atomico: {numeroAtomico}");
                elementoArchivo.WriteLine($"     Masa Atomica: {masaAtomica}");
                elementoArchivo.WriteLine($"    Radio Atomico: {radioAtomico}");
                elementoArchivo.WriteLine($" Estado Ordinario: {estadoOrdiario}");
                elementoArchivo.WriteLine("------------------------------------");
                elementoArchivo.Close();
            }
        }

        //==============================================================================================================================================
        //  Funciones Secundarias
        //==============================================================================================================================================
        
        // Funcion Evaluacion de Salida
        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n ¿Desea volver a intentarlo? [y/n]: ");

            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver a intentarlo? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;  // <--- opcionSalida == 'n'
        }

        // Funcion para valiar dato del menu
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

        // Imprimir Menu
        public static void imprimirMenu(string titulo)
        {
            Console.Clear();
            Console.WriteLine("=========================================================");
            Console.WriteLine("                         {0}", titulo);
            Console.WriteLine("=========================================================");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(" [Instrucciones]: Ingrese los datos que se le solicitan");
            Console.WriteLine("---------------------------------------------------------");
        }


        //Validar Radio Atomico
        public static double validarRadioAtomico(string dato)
        {
            double numeroEntrada;   //Declaracion de variables

            //El radio atomico de todos los elementos conocidos se encuentran en un rango de [0.49  : 3.34] Angstroms (Å)
            while ((!Double.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 3.35))
            {
                Console.Write($"{dato}");
            }
            return numeroEntrada;
        }

        //Validar Masa Atomica
        public static double validarMasaAtomica(string dato)
        {
            double numeroEntrada;   //Declaracion de variables

            //La masa atomica de todos los elementos conocidos se encuentran en un rango de [1 : 227]
            while ((!Double.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 227)) 
            {
                Console.Write($"{dato}");
            }
            return numeroEntrada;
        }

        //Validar Numero Atomico
        public static int validarNumeroAtomico(string dato)
        {
            int numeroEntrada;//Declaracion de variables

            //El numero atomico de todos los elementos conocidos se encuentran en un rango de [1: 118]
            while ((!Int32.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0) || (numeroEntrada > 118)) 
            {
                Console.Write($"{dato}");
            }
            return numeroEntrada;
        }

        //==============================================================================================================================================
        //  Funcion Principal
        //==============================================================================================================================================
        static void Main(string[] args)
        {
            //Configuracion de Ventana
            Console.Title = "Programa 004: Elementos Quimicos";

            //Declaracion de variables
            int opcionMenu;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================================");
                Console.WriteLine("                     Elemntos Quimicos");
                Console.WriteLine("=========================================================");
                Console.WriteLine("");
                Console.WriteLine(" [1]: Añadir Elemento");
                Console.WriteLine(" [2]: Ver Elementos");
                Console.WriteLine(" [3]: Salir");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese la opcion que desea ejecutar");
                Console.WriteLine("---------------------------------------------------------");
                    Console.Write("  Opcion: "); opcionMenu = validacionDatoMenu();
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n");

                switch (opcionMenu)
                {
                    // Añadir un elemento a la listo
                    case 1:
                        do
                        {
                            //Declaracion y reinicio de Variables
                            string nombreElemento = "";
                            string simboloElemento = "";
                            int numeroAtomicoElemento = 0;
                            double masaAtomicaElemento = 0.0;
                            double radioAtomicoElemento = 0.0;
                            string estadoOrdiarioElemento = "";

                            //Impresion de titulo y entrada de datos
                            imprimirMenu("Añadir un Elemento");
                                Console.Write("           Nombre: "); nombreElemento = Console.ReadLine();
                                Console.Write("          Simbolo: "); simboloElemento = Console.ReadLine();
                                Console.Write("   Numero Atomico: "); numeroAtomicoElemento = validarNumeroAtomico("   Numero Atomico: ");
                                Console.Write("     Masa Atomica: "); masaAtomicaElemento = validarMasaAtomica("     Masa Atomica: ");
                                Console.Write(" Radio Atomico[Å]: "); radioAtomicoElemento = validarRadioAtomico(" Radio Atomico[Å]: ");
                                Console.Write(" Estado Ordinario: "); estadoOrdiarioElemento = Console.ReadLine();
                            Console.WriteLine("---------------------------------------------------------");

                            //Construccion del archivo con los datos del elemento
                            elementoQuimico elementoInfoG = new elementoQuimico(nombreElemento, simboloElemento, numeroAtomicoElemento, masaAtomicaElemento, radioAtomicoElemento, estadoOrdiarioElemento);
                            
                            //Impresion del mensaje de proceso completado
                            Console.WriteLine(" Proceso Completado!");
                            Console.WriteLine(" Se ha agregado su elemento a lista de archivos");
                        }
                        while (condicionSalida());
                        break;

                    // Ver los elementos de las listas
                    case 2:
                        do
                        {
                            //Declaracion y reinicio de variables
                            string elementoLeer = "";

                            //Impresion de titulo
                            imprimirMenu("Ver elemento");
                                Console.Write(" Escriba el nombre del elemento: "); elementoLeer = Console.ReadLine().ToUpper();
                            Console.WriteLine("---------------------------------------------------------");
                            Console.WriteLine("\n");
                            
                            //Intenta buscar y leer el archivo que solicitamos
                            try
                            {
                                StreamReader elementoInfoR = new StreamReader($"{elementoLeer}.txt");
                                string line = elementoInfoR.ReadLine();     //Guardamos la una linea del archivo en una cadena de texto
                                
                                while (line != null)    //Este ciclo se repetira hasta que no exista mas lineas que leer
                                {
                                    Console.WriteLine(line);            //Imprime la linea de texto
                                    line = elementoInfoR.ReadLine();    //Lee la siguiente linea de texto
                                }

                                elementoInfoR.Close();  //Cierra el Archivo
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(" [Error]: " + e.Message);    //Mensaje de error si el archivo no existe en la coleccion
                            }
                        }
                        while (condicionSalida());
                        break;
                }
                Console.Clear();
            }
            while (opcionMenu != 3);
        }
    }
}