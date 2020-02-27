using System;
using Chess_Board;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Screen.PrintBoard(board);
        }
    }
}