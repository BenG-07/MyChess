// <copyright file="ChessBackgroundGrid.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>The graphical representation of a chess board.</summary>

namespace MyChess.ViewModel
{
    using System.Collections.Generic;
    using MyChess.Model;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// The graphical representation of a chess board.
    /// </summary>
    public class ChessBackgroundGrid
    {
        /// <summary>
        /// Contains the tiles which should be highlighted based on the piece the player wants to move.
        /// </summary>
        private List<Tile> highlightedTiles;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBackgroundGrid"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the tiles of the chess board.
        /// </summary>
        /// <value>A single tile.</value>
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

        /// <summary>
        /// A callback for when the player selected/deselected a piece.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public void SelectedPieceChangedCB(object sender, SelectedPieceChangedEventArgs e)
        {
            foreach (var tile in this.highlightedTiles)
            {
                tile.Color = tile.Point.X % 2 == tile.Point.Y % 2 ? Color.white : Color.black;
            }

            this.highlightedTiles.Clear();

            foreach (var item in e.PossibleTiles)
            {
                foreach (var tile in this.Tiles)
                {
                    if (tile.Point == item)
                    {
                        this.highlightedTiles.Add(tile);
                    }
                }
            }

            // Hier müsste die farbe des tiles geändet werden...
        }
    }
}
