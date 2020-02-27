using System;
using Chess_Board;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board B = new Board(3, 4);

            Console.WriteLine($"Position: {B}");
        }
    }
}