using System;
using Chess_Board;
using Chess_Game;
using System.Collections.Generic;

namespace Chess_Console
{
    class Screen
    {
        public static void PrintMatch(ChessMatch match) // method to print match
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine($"Turn: {match.Turn}");
            Console.Write("Player: ");
            if (match.CurrentPlayer == Color.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{match.CurrentPlayer}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{match.CurrentPlayer}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (match.Check)
            {
                Console.WriteLine("CHECK!");
            }
        }

        public static void PrintCapturedPieces(ChessMatch match) // method to print captured pieces
        {
            Console.WriteLine("Captured pieces:");
            Console.ForegroundColor = ConsoleColor.Red;
            PrintHashSet(match.CapturedPieces(Color.Red));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintHashSet(match.CapturedPieces(Color.Blue));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static void PrintHashSet(HashSet<Piece> set) // print the hashset
        {
            foreach (Piece x in set)
            {
                Console.Write($"[{x}]");
            }
        }

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
