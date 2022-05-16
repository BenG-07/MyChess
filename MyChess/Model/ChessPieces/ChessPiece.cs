// <copyright file="ChessPiece.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>The base for a chess piece in a chess game.</summary>

namespace MyChess.Model.ChessPieces
{
    /// <summary>
    /// A class that represents a <see cref="ChessPiece"/> in a <see cref="ChessGame"/>.
    /// </summary>
    public abstract class ChessPiece : IVisitable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPiece"/> class.
        /// </summary>
        /// <param name="color">The color of the <see cref="ChessPiece"/></param>
        public ChessPiece(Color color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets or sets the value for the Color of a <see cref="ChessPiece"/>.
        /// </summary>
        /// <value>The Color.</value>
        public Color Color { get; set; }

        /// <summary>
        /// Accepts a Visitor and calls an implementation for it.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public abstract void Accept(IVisitor visitor);

        /// <summary>
        /// Accepts a Visitor and calls an implementation for it.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>The result.</returns>
        public abstract T Accept<T>(IVisitor<T> visitor);
    }
}
