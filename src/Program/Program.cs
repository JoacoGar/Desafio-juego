﻿using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    class Juego
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    class Tablero
    {
        bool[,] b //variable que representa el tablero
        int width //variabe que representa el ancho del tablero
        int height //variabe que representa altura del tablero
        while (true)
        {
            Console.Clear();
            StringBuilder s = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (b[x, y])
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }

                s.Append("\n");
            }

            Console.WriteLine(s.ToString());
            //=================================================
            //Invocar método para calcular siguiente generación
            //=================================================
            Thread.Sleep(300);
        }
    }

    class logica
    {
        bool[,] gameBoard =  /* contenido del tablero */;
        int boardWidth = gameBoard.GetLength(0);
        int boardHeight = gameBoard.GetLength(1);

        bool[,] cloneboard = new bool[boardWidth, boardHeight];
        public static funcionDeJuego();
        {
            for (int x = 0;
                 x < boardWidth;
                 x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && gameBoard[i, j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }

                    if (gameBoard[x, y])
                    {
                        aliveNeighbors--;
                    }

                    if (gameBoard[x, y] && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard[x, y] = false;
                    }
                    else if (gameBoard[x, y] && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard[x, y] = false;
                    }
                    else if (!gameBoard[x, y] && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard[x, y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard[x, y] = gameBoard[x, y];
                    }
                }
            }

            gameBoard = cloneboard;
        }
    }

    class archivo
    {
        string url = "ruta del archivo";
        string content = File.ReadAllText(url);
        string[] contentLines = content.Split('\n');

        bool[,] board = new bool[contentLines.Length, contentLines[0].Length];
        public pasarMatriz();
        {
            for (int y = 0;
                 y < contentLines.Length;
                 y++)

            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        board[x, y] = true;
                    }
                }
            }
        }
    }
}