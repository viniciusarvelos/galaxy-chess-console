using Chess_Board;

namespace Chess_Game
{
    class King : Piece
    {

        private ChessMatch Match;

        public King(Board board, Color color, ChessMatch match) : base(color, board)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos) // test if the position is clear or is there is a enemy piece
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        private bool RookCastlingTest(Position pos) // tests if the Rook is eligible to Castling
        {
            Piece p = Board.Piece(pos);
            return p != null && p is Rook && p.Color == Color && p.Moves == 0;
        }

        public override bool[,] PossibleMoves() // possible moves of King piece
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);

            // N
            pos.DefineValues(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // S
            pos.DefineValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // W
            pos.DefineValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // E
            pos.DefineValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // NE
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // NW
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // SW
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // SE
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Special Move - Castling
            if (Moves == 0 && !Match.Check)
            {
                // Small Castling
                Position posR1 = new Position(Position.Line, Position.Column + 3);
                if (RookCastlingTest(posR1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.Piece(p1)  == null && Board.Piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
                // Big Castling
                Position posR2 = new Position(Position.Line, Position.Column - 4);
                if (RookCastlingTest(posR2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
