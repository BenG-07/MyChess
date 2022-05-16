// <copyright file="Turn.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Represents a turn of a chess game.</summary>

namespace MyChess.Model.Turn
{
    using System;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// A class to manage all necessary properties of a <see cref="Turn"/> in a <see cref="ChessGame"/>.
    /// </summary>
    public class Turn
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Turn"/> class.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> of the moving piece.</param>
        /// <param name="start">The start <see cref="Point"/>.</param>
        /// <param name="destination">The destination <see cref="Point"/>.</param>
        /// <param name="attackedPiece">The <see cref="Point"/> of the attacked <see cref="ChessPiece"/>.</param>
        public Turn(Color color, Point start, Point destination, Tuple<Point, ChessPiece> attackedPiece = null)
        {
            this.Color = color;
            this.Start = start;
            this.Destination = destination;
            this.AttackedPiece = attackedPiece;
        }

        /// <summary>
        /// Gets or sets the <see cref="Color"/> of the <see cref="ChessPiece"/> that moved.
        /// </summary>
        /// <value>The <see cref="Color"/>.</value>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Point"/> of the <see cref="ChessPiece"/> to move.
        /// </summary>
        /// <value>The start <see cref="Point"/>.</value>
        public Point Start { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Point"/> of the <see cref="ChessPiece"/> to move to.
        /// </summary>
        /// <value>The destination <see cref="Point"/>.</value>
        public Point Destination { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Tuple"/> of a <see cref="Point"/> and <see cref="ChessPiece"/> that says at what point a certain piece was attacked.
        /// </summary>
        /// <value>The <see cref="Point"/> of the attacked <see cref="ChessPiece"/>.</value>
        public Tuple<Point, ChessPiece> AttackedPiece { get; set; }

        /// <summary>
        /// The converter to a <see cref="String"/>.
        /// </summary>
        /// <returns>The start <see cref="Point"/> and destination <see cref="Point"/> in standard chess style.</returns>
        public override string ToString() => $"{Convert.ToChar(this.Start.X + 65)}{this.Start.Y} - {Convert.ToChar(this.Destination.X + 65)}{this.Destination.Y}";
    }
}
