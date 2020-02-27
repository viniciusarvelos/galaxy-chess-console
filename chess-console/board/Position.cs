
namespace Board
{
    class Position
        // Each piece have a line and column = position on the board
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Line}, {Column}";
        }
    }
}
