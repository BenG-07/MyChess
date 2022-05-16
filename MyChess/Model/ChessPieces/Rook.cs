// <copyright file="Rook.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Represents a rook in a chess game.</summary>

namespace MyChess.Model.ChessPieces
{
    /// <summary>
    /// A class that represents a <see cref="Rook"/> in a <see cref="ChessGame"/>.
    /// </summary>
    public class Rook : ChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rook"/> class.
        /// </summary>
        /// <param name="color">The color of the <see cref="ChessPiece"/></param>
        public Rook(Color color) : base(color)
        {
        }

        /// <summary>
        /// Accepts a Visitor and calls an implementation for it.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        /// <summary>
        /// Accepts a Visitor and calls an implementation for it.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>The result.</returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
