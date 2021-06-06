using System;
using System.IO.Compression;
using System.Linq;

namespace TicTacToeMultiplayer
{
    public class Board
    {
        private string CurrentPlayer;
        private const string Player1 = "X";
        private const string Player2 = "O";
        private string[] GameBoard;
        private int BoardSize;

        public Board(int size)
        {
            BoardSize = size;
            GameBoard = new string[BoardSize * BoardSize];
            CurrentPlayer = Player1;
        }

        public void GameLoop()
        {
            bool gameSeason = true;
            while (gameSeason)
            {
                DrawBoard();
                Console.WriteLine();
                Console.WriteLine($"Enter position to for {CurrentPlayer}");
                var input = Console.ReadLine();
                input = input.Trim();
                int intInput = int.Parse(input);
                UpdateBoard(intInput);
                if (CheckWin())
                {
                    DrawBoard();
                    Console.WriteLine($"\n {CurrentPlayer} WINS!");
                    gameSeason = false;
                }
                UpdatePlayerTurn();
            }
        }
        
        private void UpdateBoard(int position)
        {
            if (position >= GameBoard.Length || GameBoard[position] != null)
            {
                Console.WriteLine("Wrong position");
                return;
            }
            GameBoard[position] = CurrentPlayer;
        }

        private void UpdatePlayerTurn()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        public void DrawBoard()
        {
            
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write($"{GameBoard[i * BoardSize + j] ?? " "}");
                    if (j < BoardSize - 1)
                    {
                        Console.Write("|");
                    }
                }
                if (i < BoardSize - 1)
                {
                    Console.WriteLine("\n" + string.Join("", Enumerable.Repeat("--", BoardSize)));
                }
            }
        }

        private bool CheckWin()
        {
            return HorizontalWin() || VerticalWin();
        }

        private bool VerticalWin()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                if (GameBoard[i] == null)
                {
                    continue;
                }

                bool inRow = true;
                for (int j = 1; j < BoardSize; j++)
                {
                    if (GameBoard[i] != GameBoard[j * BoardSize + i])
                    {
                        inRow = false;
                    }
                }

                if (inRow)
                {
                    return true;
                }
            }
            return false;
        }

        private bool HorizontalWin()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                if (GameBoard[i * BoardSize] == null)
                {
                    continue;
                }
                bool inRow = true;
                for (int j = 1; j < BoardSize; j++)
                {
                    if (GameBoard[i * BoardSize + j] != GameBoard[i * BoardSize])
                    {
                        inRow = false;
                    }
                }

                if (inRow)
                {
                    return true;
                }
            }
            return false;
        }

        private bool DiagnoalWin()
        {
            return false;
            //if (_gameBoard[0] == null || _gameBoard[_boardSize] == null || _gameBoard[_gameBoard.])
        }
    }
}