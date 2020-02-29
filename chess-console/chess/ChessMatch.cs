using System;
using Chess_Board;

namespace Chess_Game
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.Red;
            PlacePieces();
            Finished = false;
        }

        public void ExecuteMove(Position origin, Position destination) // method used to capture a piece
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMoveQuantity();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(p, destination);
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

        private void PlacePieces()
        {
            Board.PlacePiece(new Rook(Board, Color.Red), new ChessPosition('c', 1).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Red), new ChessPosition('c', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Red), new ChessPosition('d', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Red), new ChessPosition('e', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Red), new ChessPosition('e', 1).ToPosition());
            Board.PlacePiece(new King(Board, Color.Red), new ChessPosition('d', 1).ToPosition());

            Board.PlacePiece(new Rook(Board, Color.Blue), new ChessPosition('c', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Blue), new ChessPosition('c', 8).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Blue), new ChessPosition('d', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Blue), new ChessPosition('e', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Blue), new ChessPosition('e', 8).ToPosition());
            Board.PlacePiece(new King(Board, Color.Blue), new ChessPosition('d', 8).ToPosition());
        }
    }
}
