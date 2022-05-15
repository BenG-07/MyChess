using MyChess.Model;
using MyChess.Model.ChessPieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.ViewModel
{
    class ChessBackgroundGrid
    {
        public IEnumerable<Tile> Tiles { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        private List<Tile> highlightedTiles;

        public ChessBackgroundGrid()
        {
            var args = System.Environment.GetCommandLineArgs();
            int width = 8, height = 8;
            if (args.Length >= 2 && !int.TryParse(args[1], out width))
            {
                width = 8;
            }

            if (args.Length >= 3 && !int.TryParse(args[1], out height))
            {
                height = 8;
            }

            this.Width = width;
            this.Height = height;

            Tile[] tiles = new Tile[this.Width * this.Height];
            int index = 0;
            for (int y = this.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    tiles[index++] = new Tile(new Point(x, y), x % 2 == y % 2 ? Color.white : Color.black);
                }
            }

            this.Tiles = tiles;
            this.highlightedTiles = new List<Tile>();
        }

        public void SelectedPieceChangedCB(object sender, SelectedPieceChangedEventArgs e)
        {
            foreach (var tile in this.highlightedTiles)
            {
                tile.Color = tile.Point.X % 2 == tile.Point.Y % 2 ? Color.white : Color.black;
            }
            highlightedTiles.Clear();

            foreach (var item in e.PossibleTiles)
            {
                foreach (var tile in this.Tiles)
                {
                    if (tile.Point == item)
                    {
                        highlightedTiles.Add(tile);
                    }
                }
            }

            // Hier müsste die farbe des tiles geändet werden...
        }
    }
}
