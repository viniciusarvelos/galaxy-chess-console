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

    }
}
