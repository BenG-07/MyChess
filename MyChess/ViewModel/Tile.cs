namespace MyChess.ViewModel
{
    using MyChess.Model;
    using MyChess.Model.ChessPieces;

    public class Tile
    {
        public Point Point { get; set; }
        public Color Color { get; set; }

        public Tile(Point point, Color color)
        {
            this.Point = point;
            this.Color = color;
        }
    }
}
