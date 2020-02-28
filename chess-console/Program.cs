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
                Board board = new Board(8, 8);

                board.PlacePiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PlacePiece(new Rook(board, Color.White), new Position(1, 3));
                board.PlacePiece(new King(board, Color.Black), new Position(0, 7));

                Screen.PrintBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}