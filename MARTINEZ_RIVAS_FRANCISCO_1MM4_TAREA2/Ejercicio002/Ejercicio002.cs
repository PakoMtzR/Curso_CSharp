/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 25/04/2021
 * Ultima modificacion: 05/05/2021
 * 
 * Descripcion del Programa:
 * Programa que permita obtener el RFC con homoclave de una persona, 
 * solicitando los datos necesarios (Nombre, Apellidos, Fecha de Nacimiento)
 * 
 * Fuente: 
 * https://www.dropbox.com/s/knefl1rxxgu36wu/IFAI%200610100135506%20065%20Algoritmo%20para%20generar%20el%20RFC%20con%20homoclave%20para%20personas%20fisicas%20y%20morales.odt?dl=0
 */

using System;
using System.Collections.Generic;

namespace Ejercicio002
{
    class Program
    {
        //=================================================================================
        //      Declaracion de Clase Persona
        //=================================================================================
        public class Persona
        {
            // Atributos
            public string nombre;
            public string apellidoPaterno;
            public string apellidoMaterno;
            public string dd;
            public string mm;
            public string aa;
            public string rfc = "";

            static public string primeraVocal(string texto, string rfc)
            {
                int i = 1;
                char[] vocales = new char[] { 'A', 'E', 'I', 'O', 'U' };
                int contador;
                int condicion = rfc.Length + 1;

                while (rfc.Length != condicion)
                {
                    contador = 0;
                    foreach (char vocal in vocales) if (texto[i] == vocal) contador++;
                    if (contador == 1) rfc += texto[i];
                    else i++;
                }
                return rfc;
            }

            static public string generadorHomoclave(string nombre, string apellidoPaterno, string apellidoMaterno)
            {
                //Declarando Diccionarios
                //---------------------------------------------------------------
                Dictionary<char, string> tabla1 = new Dictionary<char, string>();
                tabla1.Add(' ', "00");  tabla1.Add('A', "11");  tabla1.Add('B', "12");
                tabla1.Add('C', "13");  tabla1.Add('D', "14");  tabla1.Add('E', "15");
                tabla1.Add('F', "16");  tabla1.Add('G', "17");  tabla1.Add('H', "18");
                tabla1.Add('I', "19");  tabla1.Add('J', "21");  tabla1.Add('K', "22");
                tabla1.Add('L', "23");  tabla1.Add('M', "24");  tabla1.Add('N', "25");
                tabla1.Add('O', "26");  tabla1.Add('P', "27");  tabla1.Add('Q', "28");
                tabla1.Add('R', "29");  tabla1.Add('S', "32");  tabla1.Add('T', "33");
                tabla1.Add('U', "34");  tabla1.Add('V', "35");  tabla1.Add('W', "36");
                tabla1.Add('X', "37");  tabla1.Add('Y', "38");  tabla1.Add('Z', "39");
                tabla1.Add('Ñ', "40");

                Dictionary<int, char> tabla2 = new Dictionary<int, char>();
                tabla2.Add(0, '1');     tabla2.Add(1, '2');     tabla2.Add(2, '3');
                tabla2.Add(3, '4');     tabla2.Add(4, '5');     tabla2.Add(5, '6');
                tabla2.Add(6, '7');     tabla2.Add(7, '8');     tabla2.Add(8, '9');
                tabla2.Add(9, 'A');     tabla2.Add(10, 'B');    tabla2.Add(11, 'C');
                tabla2.Add(12, 'D');    tabla2.Add(13, 'E');    tabla2.Add(14, 'F');
                tabla2.Add(15, 'G');    tabla2.Add(16, 'H');    tabla2.Add(17, 'I');
                tabla2.Add(18, 'J');    tabla2.Add(19, 'K');    tabla2.Add(20, 'L');
                tabla2.Add(21, 'M');    tabla2.Add(22, 'N');    tabla2.Add(23, 'P');
                tabla2.Add(24, 'Q');    tabla2.Add(25, 'R');    tabla2.Add(26, 'S');
                tabla2.Add(27, 'T');    tabla2.Add(28, 'U');    tabla2.Add(29, 'V');
                tabla2.Add(30, 'W');    tabla2.Add(31, 'X');    tabla2.Add(32, 'Y');
                tabla2.Add(33, 'Z');
                //------------------------------------------------------------------
                
                //Declaracion de variables
                string homoclave = "";
                string nombreCompleto = apellidoPaterno + " " + apellidoMaterno + " " + nombre;
                string numerosColeccion = "0";

                //Procesamiento:
                //Conviertiendo en nombre completo en una coleccion de numeros
                foreach (char letra in nombreCompleto)
                {
                    foreach (KeyValuePair<char, string> holaSoyPakito in tabla1)
                    {
                        if (letra == holaSoyPakito.Key)
                        {
                            numerosColeccion += holaSoyPakito.Value;
                            break;
                        }
                    }
                }

                //Calculando un numerote unu
                int numerote = 0;
                for (int i = 0; i <= numerosColeccion.Length - 2; i++)
                {
                    numerote += Int32.Parse(numerosColeccion.Substring(i, 2)) * Int32.Parse(numerosColeccion[i + 1].ToString());
                }

                //Generando la homoclave...
                int residuo = (Int32.Parse((numerote.ToString()).Substring(1, 3))) % 34;
                int cociente = ((Int32.Parse((numerote.ToString()).Substring(1, 3))) - residuo) / 34;

                    //Generando Primera Letra de la Homoclave
                    foreach (KeyValuePair<int, char> holaSoyPakitoSiOtraVez in tabla2)
                    {
                        if (cociente == holaSoyPakitoSiOtraVez.Key)
                        {
                            homoclave += holaSoyPakitoSiOtraVez.Value;
                            break;
                        }
                    }

                    //Generando la Segunda Letra de la Homoclave
                   foreach (KeyValuePair<int, char> holaSoyPakitoSiOtraVez in tabla2)
                    {
                        if (residuo == holaSoyPakitoSiOtraVez.Key)
                        {
                            homoclave += holaSoyPakitoSiOtraVez.Value;
                            break;
                        }
                    }

                return homoclave;
            }

            //Constructor ==> Clase Persona
            public Persona(string nombreInput, string apellidoPaternoInput, string apellidoMaternoInput, string ddInput, string mmInput, string aaInput)
            {
                nombre = nombreInput.ToUpper();
                apellidoPaterno = apellidoPaternoInput.ToUpper();
                apellidoMaterno = apellidoMaternoInput.ToUpper();
                dd = ddInput;
                mm = mmInput;
                aa = aaInput;

                rfc += apellidoPaterno[0];
                rfc = primeraVocal(apellidoPaterno, rfc);
                rfc += apellidoMaterno[0];
                rfc += nombre[0];
                rfc += aa;
                rfc += mm;
                rfc += dd;
                rfc += generadorHomoclave(nombre, apellidoPaterno, apellidoMaterno);
            }
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

        /*
        // Funcion Validar dia
        public static string validarDia()
        {
            string InpDia;

            while (!((Int32.Parse(Console.ReadLine())) || (InpDia.Length == 1) || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver a intentarlo? [y/n]: ");
            return
        }
        */

        //=================================================================================
        //      Funcion Principal
        //=================================================================================
        static void Main(string[] args)
        {
            //Configuracion de Ventana
            Console.Title = "Programa 002: Generador del RFC con Homoclave";
            
            //Declaracion de Variables
            string nombreInp;
            string apellidoPaternoInp;
            string apellidoMaternoInp;
            string ddInp, mmInp, aaInp;

            //Inicio del Programa
            do
            {   
                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("                      Generar RFC");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese los datos correspondientes");
                Console.WriteLine("---------------------------------------------------------");
                    Console.Write("                 Nombre: "); nombreInp = Console.ReadLine();
                    Console.Write("       Apellido Paterno: "); apellidoPaternoInp = Console.ReadLine();
                    Console.Write("       Apellido Materno: "); apellidoMaternoInp = Console.ReadLine();
                    Console.Write(" Dia de Nacimiento [dd]: "); ddInp = Console.ReadLine();
                    Console.Write(" Mes de Nacimiento [mm]: "); mmInp = Console.ReadLine();
                    Console.Write(" Año de Nacimiento [aa]: "); aaInp = Console.ReadLine();
                Console.WriteLine("---------------------------------------------------------\n");

                Persona persona = new Persona(nombreInp, apellidoPaternoInp, apellidoMaternoInp, ddInp, mmInp, aaInp);
                Console.WriteLine($"    RFC: {persona.rfc}");
            }
            while (condicionSalida());
        }
    }
}