using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyChess.Model;
using MyChess.Model.ChessPieces;

namespace MyChess.ViewModel
{
    public class ChessGrid
    {
        public IEnumerable<Tile> Tiles { get; set; }

        public ChessGrid()
        {
            var args = System.Environment.GetCommandLineArgs();
            int width = 9;
            int height = 10;
            Tile[] tiles= new Tile[width * height];
            int index = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[index++] = new Tile(new Point(x, y), x % 2 == y % 2 ? Color.white : Color.black);
                }
            }

            Tiles = tiles;
        }
    }
}
