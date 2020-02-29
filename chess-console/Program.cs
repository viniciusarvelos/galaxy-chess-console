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
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = match.Board.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, possiblePositions);

                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    match.ExecuteMove(origin, destination);
                }
                
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}