﻿using System;
using Chess_Board;
using Chess_Game;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.PlacePiece(new Rook(board, Color.Black), new Position(0, 0));
            board.PlacePiece(new Rook(board, Color.Black), new Position(1, 3));
            board.PlacePiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintBoard(board);
        }
    }
}