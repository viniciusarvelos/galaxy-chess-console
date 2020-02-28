using System;
using Chess_Board;
using Chess_Game;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition pos1 = new ChessPosition('a', 1);
            ChessPosition pos2 = new ChessPosition('c', 7);

            Console.WriteLine(pos1);

            Console.WriteLine(pos1.ToPosition());
            Console.WriteLine(pos2.ToPosition());
        }
    }
}