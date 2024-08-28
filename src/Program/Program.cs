using System;
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
        bool[,] b; // Variable que representa el tablero
        int width; // Variable que representa el ancho del tablero
        int height; // Variable que representa la altura del tablero

        public Tablero(int width, int height)
        {
            this.width = width;
            this.height = height;
            b = new bool[width, height];
        }

        public void Mostrar()
        {
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
                // Invocar método para calcular la siguiente generación
                //=================================================
                Thread.Sleep(300);
            }
        }
    }

    class Logica
    {
        bool[,] gameBoard;
        int boardWidth;
        int boardHeight;
        bool[,] cloneBoard;

        public Logica(bool[,] initialBoard)
        {
            gameBoard = initialBoard;
            boardWidth = gameBoard.GetLength(0);
            boardHeight = gameBoard.GetLength(1);
            cloneBoard = new bool[boardWidth, boardHeight];
        }

        public void FuncionDeJuego()
        {
            for (int x = 0; x < boardWidth; x++)
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
                        // Celula muere por baja población
                        cloneBoard[x, y] = false;
                    }
                    else if (gameBoard[x, y] && aliveNeighbors > 3)
                    {
                        // Celula muere por sobrepoblación
                        cloneBoard[x, y] = false;
                    }
                    else if (!gameBoard[x, y] && aliveNeighbors == 3)
                    {
                        // Celula nace por reproducción
                        cloneBoard[x, y] = true;
                    }
                    else
                    {
                        // Celula mantiene el estado que tenía
                        cloneBoard[x, y] = gameBoard[x, y];
                    }
                }
            }

            gameBoard = cloneBoard;
        }
    }

    class Archivo
    {
        string url = "ruta del archivo";
        bool[,] board;

        public Archivo(string filePath)
        {
            url = filePath;
            CargarMatriz();
        }

        private void CargarMatriz()
        {
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');

            board = new bool[contentLines.Length, contentLines[0].Length];
            for (int y = 0; y < contentLines.Length; y++)
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

        public bool[,] ObtenerMatriz()
        {
            return board;
        }
    }
}
