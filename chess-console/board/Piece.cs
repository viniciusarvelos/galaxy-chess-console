namespace Chess_Board
{
    abstract class Piece // class was convert to abstract because of the abstract method
    {
        public Position Position { get; set; } // int (X, Y)
        public Color Color { get; protected set; } // color of the piece (black or white)
        public int Moves { get; protected set; } // number of moviments
        public Board Board { get; set; } // board wich the piece belongs to

        public Piece(Color color, Board board)
        {
            Position = null; // null position because the Class Board uses a method to position pieces
            Color = color;
            Board = board;
            Moves = 0; // initial number of moviments at the start of the game
        }

        public void IncreaseMoveQuantity() // increase moviment to 1 to allow play
        {
            Moves++;
        }

        public void DecreaseMoveQuantity() // decrease moviment to 0 to undo play
        {
            Moves--;
        }

        public bool PossibleMovesAllowed() // checks if exists any possible values on the array
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos) // determines if this piece can move to postion
        {
            return PossibleMoves()[pos.Line, pos.Column];
        }

        public abstract bool[,] PossibleMoves(); // generic method to be implemented on each piece
    }
}
