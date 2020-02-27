using System;

namespace Chess_Board
{
    class BoardException : Exception
    {
        public BoardException(string msg) : base(msg) { }
    }
}
