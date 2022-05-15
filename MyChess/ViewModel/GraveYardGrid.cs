using MyChess.Model;
using MyChess.Model.ChessPieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.ViewModel
{
    public class GraveYardGrid
    {
        public IEnumerable<Tile> Tiles { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public GraveYardGrid()
        {
            this.Width = 2;
            this.Height = 8;

            Tile[] tiles = new Tile[this.Width * this.Height];
            int index = 0;
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    tiles[index++] = new Tile(new Point(x, y), x % 2 == y % 2 ? Color.white : Color.black);
                }
            }

            Tiles = tiles;
        }
    }
}
