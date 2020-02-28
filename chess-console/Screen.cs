using System;
using Chess_Board;
using Chess_Game;

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
                Console.Write($"   {8 - i}  "); // lines reference
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null) // check if there is a piece on the position and print
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"[   ]"); // print blank pieces
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        PrintPiece(board.Piece(i, j)); // pieces
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("        A    B    C    D    E    F    G    H "); // columns reference
            Console.WriteLine();
        }

        public static ChessPosition ReadChessPosition() // reads the user input and converts to a postion on the board
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse($"{s[1]}");
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece) // prints the piece on the specified color
        {
            if (piece.Color == Color.White)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"[ {piece} ]"); // print white pieces
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"[ {piece} ]"); // print black pieces
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
