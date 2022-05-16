// <copyright file="Tile.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Represents a chess tile on a chess board.</summary>

namespace MyChess.ViewModel
{
    using MyChess.Model;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// A class representing a chess tile on a chess board.
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        /// <param name="point">The <see cref="Point"/> of the tile.</param>
        /// <param name="color">The <see cref="Color"/> of the tile.</param>
        public Tile(Point point, Color color)
        {
            this.Point = point;
            this.Color = color;
        }

        /// <summary>
        /// Gets or sets the <see cref="Point"/>.
        /// </summary>
        /// <value>The <see cref="Point"/>.</value>
        public Point Point { get; set; }

        /// <summary>
        /// Gets or sets the value for the Color of a <see cref="ChessPiece"/>.
        /// </summary>
        /// <value>The Color.</value>
        public Color Color { get; set; }
    }
}
