namespace Chess_Board
{
    class Piece
    {
        public Position Position { get; set; } // int (X, Y)
        public Color Color { get; protected set; } // color of the piece (black or white)
        public int Moviments { get; protected set; } // number of moviments
        public Board Board { get; set; } // board wich the piece belongs to

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            Moviments = 0; // initial number of moviments at the start of the game
        }


    }
}
