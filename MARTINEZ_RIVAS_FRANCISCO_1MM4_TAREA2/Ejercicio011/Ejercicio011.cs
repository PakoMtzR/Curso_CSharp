/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 05/05/2021
 * Ultima modificacion: 05/05/2021
 * 
 * Descripcion del Programa:
 * 11.	Desarrollar un programa que permita ingresar cualquier tipo de texto y que lo encripte 
 * utilizando para ello la Encriptación o Cifrado César, por lo que se debe también solicitar 
 * cuántas posiciones se debe mover en el alfabeto para realizar la encriptación.
 * 
 * Fuente: https://es.wikipedia.org/wiki/Cifrado_C%C3%A9sar
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio011
{
    class Program
    {
        static string caracteres = "abcdefghijklmñnopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890_-+,#$%&/()=¿?¡!|,.;:{}[]";


        //==============================================================================================================================================
        //  Funcion Principal
        //==============================================================================================================================================
        static void Main(string[] args)
        {
            //Configuracion de Ventana
            Console.Title = "Programa 011: Cifrado de Cesar";

            //Declaracion de variables
            int opcion;

            //Procesamiento  
            do
            {
                //Reinicio de Variables
                opcion = 0;

                //Impresion titulo
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================================");
                Console.WriteLine("                     Cifrado de Cesar");
                Console.WriteLine("=========================================================");
                Console.WriteLine("");
                Console.WriteLine(" [1]: Cifrar un mensaje");
                Console.WriteLine(" [2]: Decifrar un mensaje");
                Console.WriteLine(" [3]: Salir");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese la opcion que desea ejecutar");
                Console.WriteLine("---------------------------------------------------------");
                    Console.Write(" Opcion: "); opcion = validacionDatoMenu(" Opcion: ");
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n");

                switch (opcion)
                {
                    // Cifrar un mensaje
                    case 1:
                        do
                        {
                            string mensaje = "";
                            string mensajeCifrado = "";
                            int key = 0;
                            imprimirMenu("Cifrar un Mensaje", "cifrar");
                            Console.Write(" Mensaje: "); mensaje = Console.ReadLine();
                            Console.Write(" Llave: "); key = validarEntero(" Llave: ");
                            Console.WriteLine("---------------------------------------------------------");
                            mensajeCifrado = cifrarMensaje(mensaje, key);
                            Console.Write($" Mensaje Cifrado: {mensajeCifrado}");

                        }
                        while (condicionSalida());  //Evaluacion de la condicion de salida
                        break;

                    // Desifrar un mensaje
                    case 2:
                        do
                        {
                            string mensaje = "";
                            string mensajeCifrado = "";
                            int key = 0;
                            imprimirMenu("Decifrar un Mensaje", "decifrar");
                            Console.Write(" Mensaje: "); mensajeCifrado = Console.ReadLine();
                            Console.Write(" Llave: "); key = validarEntero(" Llave: ");
                            Console.WriteLine("---------------------------------------------------------");
                            mensaje = decifrarMensaje(mensajeCifrado, key);
                            Console.Write($" Mensaje Decifrado: {mensaje}");
                        }
                        while (condicionSalida());  //Evaluacion de la condicion de salida
                        break;
                }
            }
            while (opcion != 3);
        }

        //==============================================================================================================================================
        //  Funciones Secundarias
        //==============================================================================================================================================
        public static int validarEntero(string dato)
        {
            int valor;
            while ((!Int32.TryParse(Console.ReadLine(), out valor)) || (valor <= 0) || (valor > caracteres.Length)) // <-- Validacion del dato
                Console.Write($"{dato}");

            return valor;
        }

        public static int validacionDatoMenu(string dato)
        {
            int valor;
            while (!Int32.TryParse(Console.ReadLine(), out valor) || (valor <= 0) || (valor > 3))
                Console.Write($"{dato}");

            return valor;
        }

        public static bool condicionSalida()
        {
            char opcionSalida = 'n';

            Console.Write("\n\n\n\n ¿Desea volver intentarlo? [y/n]: ");

            while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcionSalida)) && ((opcionSalida == 'n') || (opcionSalida == 'y'))))
                Console.Write(" ¿Desea volver intentarlo? [y/n]: ");

            if (opcionSalida == 'y') return true;
            else return false;  // <--- opcionSalida == 'n'
        }

        public static string cifrarMensaje(string mensaje, int key)
        {
            string mensajeCifrado = "";
            
            for(int i = 0; i < mensaje.Length; i++)
            {
                int posicionCaracter = getPosicionEnCaracteres(mensaje[i]); //Obtiene la posicion del caracter original del mensaje en la lista de caracteres
                if (posicionCaracter == -1) mensajeCifrado += mensaje[i];   //Si se tiene la posicion -1 significa que ese caracter no se encuentra en la lista (" ")
                else
                {
                    int nuevaPosicion = posicionCaracter + key;
                    if (nuevaPosicion >= caracteres.Length) nuevaPosicion -= caracteres.Length;
                    mensajeCifrado += caracteres[nuevaPosicion];
                }
            }
            return mensajeCifrado;
        }

        public static string decifrarMensaje(string mensajeCifrado, int key)
        {
            string mensaje = "";

            for (int i = 0; i < mensajeCifrado.Length; i++)
            {
                int posicionCaracterCifrado = getPosicionEnCaracteres(mensajeCifrado[i]); //Obtiene la posicion del caracter cifrado del mensaje en la lista de caracteres
                if (posicionCaracterCifrado == -1) mensaje += mensajeCifrado[i];   //Si se tiene la posicion -1 significa que ese caracter no se encuentra en la lista (" ")
                else
                {
                    int posicionCaracterOriginal = posicionCaracterCifrado - key;
                    if (posicionCaracterOriginal < 0) posicionCaracterOriginal += caracteres.Length;
                    mensaje += caracteres[posicionCaracterOriginal];
                }
            }
            return mensaje;
        }

        public static int getPosicionEnCaracteres(char caracter)
        {
            for(int posicion = 0; posicion < caracteres.Length; posicion++)
            {
                if (caracter == caracteres[posicion]) return posicion;
            }
            return -1; //Significa que el caracter no se encuentra en la collecion de caracteres, lo cual es posible que se trate de  un: " "
        }

        public static void imprimirMenu(string titulo, string accion)
        {
            Console.Clear();
            Console.WriteLine("=========================================================");
            Console.WriteLine($"                     {titulo}");
            Console.WriteLine("=========================================================");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($" [Instrucciones]: Ingrese el mensaje a {accion}");
            Console.WriteLine("---------------------------------------------------------");
        }
    }
}
