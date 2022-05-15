using MyChess.Model;
using MyChess.Model.ChessPieces;
using System;

namespace MyChess.Model.Turn
{
    public class Turn
    {
        public Color Color { get; set; }
        public Point Start { get; set; }
        public Point Destination { get; set; }
        public Tuple<Point, ChessPiece> AttackedPiece { get; set; }

        public Turn(Color color, Point start, Point destination, Tuple<Point, ChessPiece> attackedPiece = null)
        {
            this.Color = color;
            this.Start = start;
            this.Destination = destination;
            this.AttackedPiece = attackedPiece;
        }

        public override string ToString()
        {
            return $"{Convert.ToChar(this.Start.X + 65)}{this.Start.Y} - {Convert.ToChar(this.Destination.X + 65)}{this.Destination.Y}"; ;
        }
    }
}
