// <copyright file="ChessPieceMover.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>A class to check if a move is valid.</summary>

namespace MyChess.Model.ChessPieceMovers
{
    using System.Collections.Generic;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// A class to check if a move is valid.
    /// </summary>
    public class ChessPieceMover : ChessPieceMovementPattern
    {
        /// <summary>
        /// Evaluates if the target <see cref="Point"/> is also the last tile to move to (either enemy piece or out of bounds) and the own <see cref="King"/> is not threatened by any enemy <see cref="ChessPiece"/> after completing the move.
        /// </summary>
        /// <param name="board">The <see cref="ChessBoard"/>.</param>
        /// <param name="start">The <see cref="Point"/> of the <see cref="ChessPiece"/> to move.</param>
        /// <param name="target">The destination <see cref="Point"/> for the current move.</param>
        /// <param name="color">The color of the <see cref="ChessPiece"/> that is moving.</param>
        /// <param name="points">The list of possible moves for the <see cref="ChessPiece"/> in question.</param>
        /// <returns>Whether it is the last possible move in the current direction.</returns>
        protected override bool IsNextMovePossible(ChessBoard board, Point start, Point target, Color color, List<Point> points)
        {
            if (board.IsInBounds(target) && !board.IsOccupied(target, color))
            {
                ChessBoard newBoard = ChessBoard.CopyOf(board);
                newBoard.MovePiece(start, target);
                if (!newBoard.IsInCheck(color))
                {
                    points.Add(target);
                }

                return !board.IsOccupied(target, color.Invert());
            }

            return false;
        }
    }
}
