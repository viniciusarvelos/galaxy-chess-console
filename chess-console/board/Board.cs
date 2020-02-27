namespace Chess_Board
{
    class Board
    {
        public int Lines { get; set; } // chess = 8 (1-8)
        public int Columns { get; set; } // chess = 8 (A-H)
        public Piece[,] Pieces; // array of pieces

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }

        public Piece Piece(int line, int column) // method used to access the piece on the designated line and column
        {
            return Pieces[line, column];
        }

        public Piece Piece(Position pos) // improvement to method to allow it to receive a pos type 'Position'
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool ExistsPiece(Position pos) // method used to determine if already exists a piece on the position
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void PlacePiece(Piece p, Position pos) // place pieces on board in the designated position
        {
            if (ExistsPiece(pos))
            {
                throw new BoardException("Already exists a piece on this position!");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Position pos) // method to test if the position is valid
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos) // method used to launch a expection if the position is invalid
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
