using System;
using System.Text;
using System.IO;
using Chess_Board;

namespace Chess_Console
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine();
            Console.WriteLine("   CONSOLE CHESS");
            Console.WriteLine();
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"   {8 - i}  ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null) // check if there is a piece on the position and print
                    {
                        Console.Write("[ - ]");
                    }
                    else
                    {
                        Console.Write($"[ {board.Piece(i, j)} ]");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine($"        A    B    C    D    E    F    G    H ");
            Console.WriteLine();
        }
    }
}
