// <copyright file="GraveYardGrid.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Represents a graveyard from a chess game.</summary>

namespace MyChess.ViewModel
{
    using System.Collections.Generic;
    using MyChess.Model;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// A class representing a graveyard from a chess game.
    /// </summary>
    public class GraveYardGrid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GraveYardGrid"/> class.
        /// </summary>
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

            this.Tiles = tiles;
        }

        /// <summary>
        /// Gets or sets the chess tiles.
        /// </summary>
        /// <value>The chess tiles.</value>
        public IEnumerable<Tile> Tiles { get; set; }

        /// <summary>
        /// Gets or sets the width of the board.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the board.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; }
    }
}
