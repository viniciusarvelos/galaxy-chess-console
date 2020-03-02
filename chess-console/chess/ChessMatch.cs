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
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.Rebel;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PlacePieces();
        }

        public Piece ExecuteMove(Position origin, Position destination) // method used to capture a piece
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMoveQuantity();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(p, destination);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece) // undo move
        {
            Piece p = Board.RemovePiece(destination);
            p.DecreaseMoveQuantity();
            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, destination);
                Captured.Remove(capturedPiece);
            }
            Board.PlacePiece(p, origin);
        }

        public void TurnPlay(Position origin, Position destination) // execute move and pass turn
        {
            Piece capturedPiece = ExecuteMove(origin, destination);

            if (InCheck(CurrentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }
            if (InCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (CheckmateTest(Adversary(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
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
            if (!Board.Piece(origin).PossibleMove(destination))
            {
                throw new BoardException("Invalid destination position!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.Empire)
            {
                CurrentPlayer = Color.Rebel;
            }
            else
            {
                CurrentPlayer = Color.Empire;
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
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Adversary(Color color) // method to determine which color is the adversary
        {
            if (color == Color.Empire)
            {
                return Color.Rebel;
            }
            else
            {
                return Color.Empire;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInPlay(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool InCheck(Color color) // tests if the king is in check
        {
            Piece k = King(color);
            if (k == null)
            {
                throw new BoardException($"There is no {color} King in the board!");
            }
            foreach (Piece x in PiecesInPlay(Adversary(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[k.Position.Line, k.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckmateTest(Color color) // test checkmate
        {
            if (!InCheck(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInPlay(color))
            {
                bool[,] mat = x.PossibleMoves();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = ExecuteMove(origin, destination);
                            bool checkTest = InCheck(color);
                            UndoMove(origin, destination, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceNewPiece(char column, int line, Piece piece) // method to easy the placement of the initial pieces
        {
            Board.PlacePiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces() // method to place initial pieces
        {
            PlaceNewPiece('c', 1, new Rook(Board, Color.Empire));
            PlaceNewPiece('d', 1, new King(Board, Color.Empire));
            PlaceNewPiece('h', 7, new Rook(Board, Color.Empire));

            PlaceNewPiece('b', 8, new Rook(Board, Color.Rebel));
            PlaceNewPiece('a', 8, new King(Board, Color.Rebel));
        }
    }
}
