/*
 * Creado por: Francisco Martinez Rivas 1MM4
 * Fecha de creacion: 13/04/2021
 * Ultima modificacion: 24/04/2021
 * 
 * Descripcion del Programa:
 * Programa que permita obtener el CURP completo de una persona, solicitando los datos necesarios 
 * (Nombre, Apellidos, Fecha de Nacimiento, lugar de nacimiento), siguiendo para ello las instrucciones 
 * proporcionadas en el DOF Normativa para generar el CURP, DOF. (Enlaces a un sitio externo.) 
 * No generar los últimos dos dígitos del CURP, los cuales son asignados por el RENAPO mediante algoritmos misteriosos
 */

using System;
using System.Collections.Generic;

namespace Ejercicio003
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
            public string sexo;
            public string lugarNacimiento;
            public string curp = "";
            
            // Funciones auxiliares
            static public string primeraConstante(string texto, string curp)
            {
                int i = 1;
                char[] vocales = new char[] { 'A', 'E', 'I', 'O', 'U' };
                int contador;
                int condicion = curp.Length + 1;

                while (curp.Length != condicion)
                {
                    contador = 0;
                    foreach (char vocal in vocales) if (texto[i] == vocal) contador++;
                    if (contador != 0) i++;
                    else curp += texto[i];
                }
                return curp;
            }
            static public string primeraVocal(string texto, string curp)
            {
                int i = 1;
                char[] vocales = new char[] { 'A', 'E', 'I', 'O', 'U' };
                int contador;
                int condicion = curp.Length + 1;

                while (curp.Length != condicion)
                {
                    contador = 0;
                    foreach (char vocal in vocales) if (texto[i] == vocal) contador++;
                    if (contador == 1) curp += texto[i];
                    else i++;
                }
                return curp;
            }

            //  Metodo Persona
            public Persona(string nombreInput, string apellidoPaternoInput, string apellidoMaternoInput, string ddInput, string mmInput, string aaInput, string sexoInput, string lugarNacimientoInput)
            {
                nombre = nombreInput.ToUpper();
                apellidoPaterno = apellidoPaternoInput.ToUpper();
                apellidoMaterno = apellidoMaternoInput.ToUpper();
                dd = ddInput;
                mm = mmInput;
                aa = aaInput;
                sexo = sexoInput.ToUpper();
                lugarNacimiento = lugarNacimientoInput.ToUpper();   

                //Construccion del Curp
                curp += apellidoPaterno[0];
                curp = primeraVocal(apellidoPaterno, curp);
                curp += apellidoMaterno[0];
                curp += nombre[0];
                curp += aa;
                curp += mm;
                curp += dd;
                curp += sexo;
                curp += lugarNacimiento;
                curp = primeraConstante(apellidoPaterno, curp);
                curp = primeraConstante(apellidoMaterno, curp);
                curp = primeraConstante(nombre, curp);  // <-- Curp Finalmente construido
            }
        }

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
        static public string validarFecha()
        {

            return;
        }
        */

        static public string validarSexo()
        {
            char sexoSalida;
            while (!((Char.TryParse(Console.ReadLine().ToUpper(), out sexoSalida)) && ((sexoSalida == 'H') || (sexoSalida == 'M'))))
                Console.Write("             Sexo [H/M]: ");
            
            return sexoSalida.ToString();
        }

        static public string encontrarEstado(string estadoInput)
        {
            //Declarando diccionario de Estados
            //--------------------------------------------------------------------
            Dictionary<string, string> estados = new Dictionary<string, string>();
            estados.Add("AGUASCALIENTES", "AS");
            estados.Add("BAJA CALIFORNIA", "BC");
            estados.Add("BAJA CALIFORNIA SUR", "BS");
            estados.Add("CAMPECHE", "CC");
            estados.Add("CHIAPAS", "CS");
            estados.Add("CHIHUAHUA", "CH");
            estados.Add("COAHUILA", "CL");
            estados.Add("COLIMA", "CM");
            estados.Add("CIUDAD DE MEXICO", "DF");
            estados.Add("DURANGO", "DG");
            estados.Add("GUANAJUATO", "GT");
            estados.Add("GUERRERO", "GR");
            estados.Add("HIDALGO", "HG");
            estados.Add("JALISCO", "JC");
            estados.Add("ESTADO DE MEXICO", "MC");
            estados.Add("MICHOACAN", "MN");
            estados.Add("MORELOS", "MS");
            estados.Add("NAYARIT", "NT");
            estados.Add("NUEVO LEON", "NL");
            estados.Add("OAXACA", "OC");
            estados.Add("PUEBLA", "PL");
            estados.Add("QUERETARO", "QT");
            estados.Add("QUINTANA ROO", "QR");
            estados.Add("SAN LUIS POTOSI", "SP");
            estados.Add("SINALOA", "SL");
            estados.Add("SONORA", "SR");
            estados.Add("TABASCO", "TC");
            estados.Add("TAMAULIPAS", "TS");
            estados.Add("TLAXCALA", "TL");
            estados.Add("VERACRUZ", "VZ");
            estados.Add("YUCATAN", "YN");
            estados.Add("ZACATECAS", "ZS");
            //--------------------------------------------------------------------
            
            string claveEstado = "";
            foreach (KeyValuePair<string, string> estado in estados)
            {
                if (estadoInput == estado.Key)
                {
                    claveEstado += estado.Value;
                    break;
                }
            }
            return claveEstado;
        }

        //Funcion Principal
        static void Main(string[] args)
        {
            string nombreInp;
            string apellidoPaternoInp;
            string apellidoMaternoInp;
            string ddInp, mmInp, aaInp;
            string sexoInp;
            string lugarNacimientoInp;

            do
            {
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("                      Generar CURP");
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
                    Console.Write("             Sexo [H/M]: "); sexoInp = validarSexo();  //sexoInp = Convert.ToChar(Console.ReadLine());
                    Console.Write("    Lugar de Nacimiento: "); lugarNacimientoInp = encontrarEstado(Console.ReadLine().ToUpper());
                Console.WriteLine("---------------------------------------------------------\n");

                Persona yo = new Persona(nombreInp, apellidoPaternoInp, apellidoMaternoInp, ddInp, mmInp, aaInp, sexoInp, lugarNacimientoInp);
                Console.WriteLine($"    Curp: {yo.curp}");
            }
            while (condicionSalida());
        }
    }
}