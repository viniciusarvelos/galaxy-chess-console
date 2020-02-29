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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   CONSOLE CHESS"); // game title
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($" {8 - i}  "); // lines reference
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j)); // print pieces
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("     A  B  C  D  E  F  G  H "); // columns reference
            Console.WriteLine();
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions) // overcharge to show possible positions
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   CONSOLE CHESS"); // game title
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($" {8 - i}  "); // lines reference
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    PrintPiece(board.Piece(i, j)); // print pieces
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("     A  B  C  D  E  F  G  H "); // columns reference
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
            if (piece == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"[ ]"); // print blank pieces
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (piece.Color == Color.Red)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[{piece}]"); // print white pieces
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"[{piece}]"); // print black pieces
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
