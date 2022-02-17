/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 09/03/2021
 * Ultima modificacion: 23/03/2021
 * 
 * Descripcion del programa:
 * Generar un algoritmo que permita el ingreso de un número entero positivo,
 * y representarlo como la suma de sus unidades, decenas, centenas..., esto es,
 * si se ingresa el valor de 1942 este debe de ser igual a: 1942 = 1000 + 900 + 40 + 2
 */

using System;

namespace Ejercicio010
{
    class Program
    {
        //Funcion descompone un numero y lo guarda dentro de un arreglo
        public static void descomponerNumero(int numero)
        {
            //Declaracion de las variables locales
            int cantidadDigitos, i, baseDiez, numeroCopia;
            int[] digitos;

            //Reinicio de variables
            cantidadDigitos = 1; i = 0; baseDiez = 0;

            //--------------------------------------------------------------------------------------------------------------
            numeroCopia = numero;   //Creamos una copia del numero de entrada para que podamos jugar con el sin problemas :D

            while ((numeroCopia / 10) > 0)  //Este while, busca la cantidad de digitos del numero que ingresaron
            {
                numeroCopia /= 10; //Como el usuario ingreso un numero entonces sabemos que dicho numero tiene por lo menos 1 digito
                cantidadDigitos++; // pero si este el divisible por 10 entonces tendra dos digitos y asi succesivamente...
            }

            digitos = new int[cantidadDigitos]; // Creamos un arreglo del tamaño de la cantidad de digitos que ingreso el usuario
            baseDiez = Convert.ToInt32(Math.Pow(10, (cantidadDigitos - 1)));    //10^(n-1) Se busca el multiplo mas grande ej: 6382-->1000
                                                                                //numero de digitos(6382) = 4 -> 10^(4-1) = 1000
            numeroCopia = numero;   //Creamos una copia del numero original para que esta podamos manupularla y no perder el valor original

            while (numeroCopia != 0)
            {
                digitos[i] = (numeroCopia - (numeroCopia % baseDiez)); //Ej: 25 - (25 % 10) => 25 - (5) = 20 <-- obtenemos asi las decenas (los demas siguen un proceso similar)
                numeroCopia %= baseDiez; // Siguiendo el mismo ejemplo, como ya obtuvimos las decenas ahora siguen las unidades, entonces 25 % 10 = 5 <-- 5 para el siguiente ciclo
                baseDiez /= 10; //Se va reducioendo el valor de la base 10 para el siguiente ciclo [ej: 1000... 100 ... 10... 1]
                i++; //Avanza a la siguiente localidad de memoria
            }

            //Imprimir los valores dentro del arreglo
            Console.Write("{0} = ", numero);
            for (int k = 0; k < cantidadDigitos; k++) //Recorre todo el arreglo
            {
                if (digitos[k] != 0) //Si en la casilla se encuentra un valor de 0, entonces no debe imprimir nada
                {
                    Console.Write("{0} ", digitos[k]);  //Imprime el valor que se encuentra en la casilla
                    if (k < (cantidadDigitos - 2)) Console.Write("+ "); //si no se encuentra en la ultima casilla entonces debe imprimir ademas un " + "
                }
            }
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            Console.Title = "Programa 010: Descomposicion de un numero en sumas";

            //Declaracion de variables
            char opcion = 'y';
            int numeroEntrada;

            //Procesamiento  
            while (opcion != 'n')
            {
                //Reinicio de Variables
                numeroEntrada = 0;

                //Impresion titulo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================================");
                Console.WriteLine("            Descomposicion de un numero en sumas");
                Console.WriteLine("=========================================================");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" [Instrucciones]: Ingrese el numero que desea descomponer");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("  n = "); 
                while ((!Int32.TryParse(Console.ReadLine(), out numeroEntrada)) || (numeroEntrada <= 0)) // <-- Validacion del dato
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [ERROR]: Valor invalido, vuelva a interntar.\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("  n = ");
                }
                Console.WriteLine("---------------------------------------------------------\n");
                Console.Write("\n\t");

                descomponerNumero(numeroEntrada);   // <-- Llamando a la funcion               

                //Evaluacion de condicion de salida
                Console.Write("\n\n\n ¿Desea descomponer otro numero? [y/n]: "); //opcion = Convert.ToChar(Console.ReadLine());
                
                while (!((Char.TryParse(Console.ReadLine().ToLower(), out opcion)) && ((opcion == 'n') || (opcion == 'y')))) 
                    Console.Write("\n ¿Desea descomponer otro numero? [y/n]: ");
                
                Console.Clear();
            }
        }
    }
}