/*
  Creado por: Francisco Martinez Rivas 1MM4
  Fecha creacion: 07/05/2021
  Ultima modificacion: 07/05/2021

  Descripcion del Programa:
  Ejecicio 18,
  Programa que permita obtener diversas soluciones de el problema de las 8 reinas. (Enlaces a un sitio externo.) En el programa, el usuario ingresará la posición de una de las reinas, y este deberá arrojar la(s) solución(es) de colocar las otras 7 reinas 

  Fuentes: 
  https://es.wikipedia.org/wiki/Problema_de_las_ocho_reinas
*/

using System;
using System.Collections.Generic;
using System.Threading;

namespace reinas
{
    class problema8reinas
    {
        public enum StatCell
        {
            Free,
            Full,
            Block,
            QueenTemp
        }

        public struct Point
        {
            public int x;
            public int y;

            public Point(int ax, int ay)
            {
                this = default(Point);
                this.x = ax;
                this.y = ay;
            }
        }

        private static StatCell[,] Board;
        private static List<StatCell[,]> listSol;
        private static Point[] PosQueen;
        private static int BoardSize;
        private static int tWait;
        private static bool withInterface;

        public static void ShowSol()
        {
            checked
            {
                if (withInterface)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    DrawBoard(problema8reinas.Board);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    LocateP(0, 2, "Se Identifico Solucion! [Pulse una tecla para continuar.]");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;
                    LocateP(0, 2, "                                                         ");
                }
            }
        }

        [STAThread]
        public static void Main()
        {
            listSol = new List<StatCell[,]>();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("============================================================");
            Console.WriteLine("                Solucion Problema 8 Reinas                  ");
            Console.WriteLine("............................................................");
            Console.WriteLine("                                                            ");
            Console.WriteLine("1. El problema se resuelve de manera secuencial. La solucion");
            Console.WriteLine("   simula movimientos reales.                               ");
            Console.WriteLine("2. El <Speed> permite retardar los pasos entre movimiento.  ");
            Console.WriteLine("3. El <Size Board> define el problema a n x n Reinas.       ");
            Console.WriteLine("4. <User Interface> visualiza el problema de manera grafica.");
            Console.WriteLine("                                                            ");
            Console.WriteLine("============================================================");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;

            checked
            {
                Console.Write("Inserte el tamaño del tablero (Min=4, Max=8)[Default=4]: ");
                BoardSize = (int)Math.Abs(Val(Console.ReadLine()));
                if (BoardSize < 4 || BoardSize > 8)
                    BoardSize = 4;

                Console.Write("\nInserte la velocidad (lento=1000, rapido=1)[Default=200]: ");
                tWait = (int)Math.Abs(Val(Console.ReadLine()));
                if (tWait < 1 || tWait > 1000) tWait = 200;

                string asnw;
                do
                {
                    Console.Write("\nDesea generar la interface? (Y/N)[Y]: ");
                    asnw = Console.ReadKey().KeyChar.ToString();
                    asnw = asnw.ToUpper();
                } while (!(asnw == "Y" || asnw == "N"));

                if (asnw == "Y")
                    withInterface = true;
                else
                {
                    withInterface = false;
                    tWait = 1;
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Resuelve Problema de las 8 Reinas:\n\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Presione cualquier tecla para terminar.");
                BoardSize--;

                Board = new StatCell[BoardSize + 1, BoardSize + 1];
                PosQueen = new Point[BoardSize + 1];
                int x = 0;
                int y = 0;
                int nQueen = 0;
                int nsol = 0;
                int iter = 0;
                bool EndIter = false;

                iter = 0;
                do
                {
                    iter++;

                    if (CheckPosQueen(x, y))
                    {
                        SetQueen(x, y);
                        PosQueen[nQueen] = new Point(x, y);
                        nQueen++;
                        x += 1;
                        y = 0;

                        if (nQueen > BoardSize)
                        {
                            ShowSol();
                            listSol.Add(Board);
                            nsol++;

                            do
                            {
                                nQueen -= 1;
                                Board = new StatCell[BoardSize + 1, BoardSize + 1];
                                for (int scan = 0; scan <= (nQueen - 1); scan++)
                                {
                                    SetQueen(PosQueen[scan].x, PosQueen[scan].y);
                                }
                                y = PosQueen[nQueen].y + 1;
                                x = PosQueen[nQueen].x;
                            }
                            while (!(y <= BoardSize));
                            //Si Y es > BoardSize, returna una columna menos.
                        }
                        else
                        {
                            if (x > BoardSize)
                            {
                                y++;
                                x = 0;
                                if (y > BoardSize)
                                {
                                    //Fin de las columnas, Solucion Encontrada
                                    y = PosQueen[0].y + 1;
                                    if (y > BoardSize) break;
                                }
                            }
                        }
                    }
                    else
                    {
                        y++;
                        if (y > BoardSize)
                        {
                            //Fin de las columnas, Solucion NO ENCONTRADA
                            do
                            {
                                nQueen -= 1;
                                if (nQueen < 0)
                                {
                                    EndIter = true;
                                    break;
                                }
                                Board = new StatCell[BoardSize + 1, BoardSize + 1];

                                for (int scan = 0; scan <= (nQueen - 1); scan++)
                                {
                                    SetQueen(PosQueen[scan].x, PosQueen[scan].y);
                                }
                                x = PosQueen[nQueen].x;
                                y = PosQueen[nQueen].y + 1;
                            }
                            while (!(y <= BoardSize));
                            //Si Y es > BoardSize, returna una columna menos.
                        }
                    }

                    DrawBoard(Board);
                    LocateP(0, 1, "Solucion:" + nsol + "   #Iteracion:" + iter);
                    Thread.Sleep(tWait / 2);

                } while (!(Console.KeyAvailable || EndIter));

                // Maneja posicion de los mensajes dinamica (en funcion tamano tablero)
                int posY = 8 + (BoardSize * 2) + 1;
                LocateP(0, posY, " ");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("{0} Solucion(s) encontrada(s).   ", nsol);
                Console.WriteLine("---------------------------------");

                Console.WriteLine("");
                Console.WriteLine("Presione cualquier tecla para terminar.");
                Console.ReadKey();
            }
        }

        public static void LocateP(int x, int y, string texto)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write(texto);
        }

        public static void Msg(string amsg)
        {
            LocateP(1, 25, amsg);
            Thread.Sleep(tWait);
            LocateP(1, 25, "                                ");
        }

        public static void DrawBoard(StatCell[,] aBoard)
        {
            if (!withInterface) return;

            int xp = 5;
            Console.CursorVisible = false;
            int boardSize = BoardSize;
            checked
            {
                for (int x = 0; x <= boardSize; x++)
                {
                    xp += 2;
                    int yp = 5;
                    int boardSize2 = BoardSize;
                    for (int y = 0; y <= boardSize2; y++)
                    {
                        yp += 2;
                        string value = "";
                        switch (aBoard[x, y])
                        {
                            case StatCell.Free:
                                value = " ";
                                break;
                            case StatCell.Full:
                                value = "Q";
                                break;
                            case StatCell.Block:
                                value = ".";
                                break;
                            case StatCell.QueenTemp:
                                value = "q";
                                break;
                        }
                        LocateP(xp, yp - 1, "+-+");
                        LocateP(xp, yp, "|" + value + "|");
                        LocateP(xp, yp + 1, "+-+");
                    }
                }
                Console.CursorVisible = true;
            }
        }

        public static int Val(string strg)
        {
            int val;
            int.TryParse(strg, out val);
            return val;
        }

        public static bool CheckPosQueen(int x, int y)
        {
            StatCell[,] array = (StatCell[,])Board.Clone();
            array[x, y] = StatCell.QueenTemp;
            DrawBoard(array);
            if (Board[x, y] == StatCell.Free | Board[x, y] == StatCell.QueenTemp)
            {
                return true;
            }
            Thread.Sleep(tWait / 2);
            return false;
        }

        public static bool SetQueen(int x, int y)
        {
            StatCell[,] array = (StatCell[,])Board.Clone();
            int boardSize = BoardSize;
            checked
            {
                for (int i = 0; i <= boardSize; i++)
                {
                    if (Board[i, y] == StatCell.Free) array[i, y] = StatCell.Block;
                    if (Board[x, i] == StatCell.Free) array[x, i] = StatCell.Block;
                }

                int xb = x; int xs = x;
                int yb = y; int ys = y;
                int boardSize2 = BoardSize;
                for (int j = 0; j <= boardSize2; j++)
                {
                    xs--; ys--;
                    xb++; yb++;
                    if ((xb <= BoardSize & ys >= 0) && array[xb, ys] == StatCell.Free)
                    {
                        array[xb, ys] = StatCell.Block;
                    }
                    if ((xs >= 0 & yb <= BoardSize) && array[xs, yb] == StatCell.Free)
                    {
                        array[xs, yb] = StatCell.Block;
                    }
                    if ((xs >= 0 & ys >= 0) && array[xs, ys] == StatCell.Free)
                    {
                        array[xs, ys] = StatCell.Block;
                    }
                    if ((xb <= BoardSize & yb <= BoardSize) && array[xb, yb] == StatCell.Free)
                    {
                        array[xb, yb] = StatCell.Block;
                    }
                }

                array[x, y] = StatCell.Full;
                Board = array;
                DrawBoard(Board);
                Thread.Sleep((int)Math.Round((double)tWait / 2.0));

                return true;
            }
        }
    }
}
