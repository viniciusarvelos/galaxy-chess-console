using System;
using Chess_Board;
using System.Collections.Generic;

namespace Chess_Game
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.Red;
            Finished = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PlacePieces();
        }

        public void ExecuteMove(Position origin, Position destination) // method used to capture a piece
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMoveQuantity();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(p, destination);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
        }

        public void TurnPlay(Position origin, Position destination) // execute move and pass turn
        {
            ExecuteMove(origin, destination);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos) // method used to check if the origin position is valid
        {
            if (Board.Piece(pos) == null)
            {
                throw new BoardException("There is no piece on the selected origin position!");
            }
            if (CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("The selected piece don't belong to the current player!");
            }
            if (!Board.Piece(pos).PossibleMovesAllowed())
            {
                throw new BoardException("There is no possible moves to the selected piece!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination) // method used to check if the destination position is valid
        { 
            if (!Board.Piece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Invalid destination position!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.Red)
            {
                CurrentPlayer = Color.Blue;
            }
            else
            {
                CurrentPlayer = Color.Red;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color) // retuns all captured pieces of the designed color
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInPlay(Color color) // retuns all pieces in play of the designed color
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void PlaceNewPiece(char column, int line, Piece piece) // method to easy the placement of the initial pieces
        {
            Board.PlacePiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces() // method to place initial pieces
        {
            PlaceNewPiece('c', 1, new Rook(Board, Color.Red));
            PlaceNewPiece('c', 2, new Rook(Board, Color.Red));
            PlaceNewPiece('d', 2, new Rook(Board, Color.Red));
            PlaceNewPiece('e', 2, new Rook(Board, Color.Red));
            PlaceNewPiece('e', 1, new Rook(Board, Color.Red));
            PlaceNewPiece('d', 1, new King(Board, Color.Red));

            PlaceNewPiece('c', 7, new Rook(Board, Color.Blue));
            PlaceNewPiece('c', 8, new Rook(Board, Color.Blue));
            PlaceNewPiece('d', 7, new Rook(Board, Color.Blue));
            PlaceNewPiece('e', 7, new Rook(Board, Color.Blue));
            PlaceNewPiece('e', 8, new Rook(Board, Color.Blue));
            PlaceNewPiece('d', 8, new King(Board, Color.Blue));
        }
    }
}
