﻿using System;
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

        public int Width { get; set; }

        public int Height { get; set; }

        public ChessGrid()
        {
            var args = System.Environment.GetCommandLineArgs();
            this.Width = 8;
            this.Height = 10;
            Tile[] tiles= new Tile[this.Width * this.Height];
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
