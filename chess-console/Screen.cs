using System;
using Chess_Board;

namespace Chess_Console
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            Console.WriteLine();
            Console.WriteLine("   CONSOLE CHESS"); // game title
            Console.WriteLine();
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"   {8 - i}  "); // lines
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null) // check if there is a piece on the position and print
                    {
                        ConsoleColor aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"[   ]"); // print blank pieces
                        Console.ForegroundColor = aux;
                    }
                    else
                    {
                        PrintPiece(board.Piece(i, j)); // pieces
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("        A    B    C    D    E    F    G    H "); // columns
            Console.WriteLine();
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write($"[ {piece} ]"); // print white pieces
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"[ {piece} ]"); // print black pieces
                Console.ForegroundColor = aux;
            }
        }
    }
}
