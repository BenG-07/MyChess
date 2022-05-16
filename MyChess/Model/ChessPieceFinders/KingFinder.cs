// <copyright file="KingFinder.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Finds all kings on a chessboard.</summary>

namespace MyChess.Model.ChessPieceFinders
{
    using System;
    using System.Collections.Generic;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// A class to find the <see cref="King"/> instance on a <see cref="ChessBoard"/>.
    /// </summary>
    public class KingFinder : PieceFinder
    {
        /// <summary>
        /// Scans a <see cref="ChessBoard"/> for the <see cref="King"/> instance.
        /// </summary>
        /// <param name="pieces">A key-value pair for all <see cref="Point"/> and <see cref="ChessPiece"/> on a <see cref="ChessBoard"/>.</param>
        /// <returns>The position of the <see cref="King"/>.</returns>
        public override Point GetPiecePosition(Dictionary<Point, ChessPiece> pieces)
        {
            foreach (var piece in pieces)
            {
                if (piece.Value.Accept(this))
                {
                    return piece.Key;
                }
            }

            throw new Exception($"Error 404: King not found!");
        }

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="king">The <see cref="King"/> visiting.</param>
        /// <returns>The boolean value true.</returns>
        public override bool Visit(King king) => true;
    }
}
