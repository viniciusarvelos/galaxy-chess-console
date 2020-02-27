using Chess_Board;

namespace Chess_Game
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(color, board) { }

        public override string ToString()
        {
            return "R";
        }
    }
}
