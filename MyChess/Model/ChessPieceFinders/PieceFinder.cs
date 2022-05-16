// <copyright file="PieceFinder.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>The abstract base to generate a piece finder for a chess game.</summary>

namespace MyChess.Model.ChessPieceFinders
{
    using System.Collections.Generic;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// The abstract base to generate a <see cref="PieceFinder"/> for a chess game.
    /// </summary>
    public abstract class PieceFinder : IVisitor<bool>
    {
        /// <summary>
        /// Scans a <see cref="ChessBoard"/> for a specified <see cref="ChessPiece"/> instance.
        /// </summary>
        /// <param name="pieces">A key-value pair for all <see cref="Point"/> and <see cref="ChessPiece"/> on a <see cref="ChessBoard"/>.</param>
        /// <returns>The position of the <see cref="ChessPiece"/>.</returns>
        public abstract Point GetPiecePosition(Dictionary<Point, ChessPiece> pieces);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="pawn">The <see cref="Pawn"/> visiting.</param>
        /// <returns>The boolean value false.</returns>
        public virtual bool Visit(Pawn pawn) => false;

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="rook">The <see cref="Rook"/> visiting.</param>
        /// <returns>The boolean value false.</returns>
        public virtual bool Visit(Rook rook) => false;

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="bishop">The <see cref="Bishop"/> visiting.</param>
        /// <returns>The boolean value false.</returns>
        public virtual bool Visit(Bishop bishop) => false;

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="knight">The <see cref="Knight"/> visiting.</param>
        /// <returns>The boolean value false.</returns>
        public virtual bool Visit(Knight knight) => false;

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="queen">The <see cref="Queen"/> visiting.</param>
        /// <returns>The boolean value false.</returns>
        public virtual bool Visit(Queen queen) => false;

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="king">The <see cref="King"/> visiting.</param>
        /// <returns>The boolean value false.</returns>
        public virtual bool Visit(King king) => false;
    }
}
