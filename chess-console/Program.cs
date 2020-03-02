using System;
using Chess_Board;
using Chess_Game;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = match.Board.Piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.WriteLine($"Turn: {match.Turn}");
                        Console.Write("Player: ");
                        if (match.CurrentPlayer == Color.Empire)
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
                        Console.Write("Destination: ");
                        Position destination = Screen.ReadChessPosition().ToPosition();
                        match.ValidateDestinationPosition(origin, destination);

                        match.TurnPlay(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
                
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}