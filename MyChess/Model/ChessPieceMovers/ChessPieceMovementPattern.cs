// <copyright file="ChessPieceMovementPattern.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>A class that defines the movement pattern for all chess pieces.</summary>

namespace MyChess.Model.ChessPieceMovers
{
    using MyChess.Model.ChessPieces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A class that defines the movement pattern for all <see cref="ChessPiece"/> objects.
    /// </summary>
    public abstract class ChessPieceMovementPattern : IVisitor<Func<ChessBoard, Point, List<Point>>>
    {
        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="pawn">The <see cref="Pawn"/> visiting.</param>
        /// <returns>A function that takes a <see cref="ChessBoard"/> and a <see cref="Point"/> and returns all possible moves for the piece at said <see cref="Point"/> on the <see cref="ChessBoard"/>.</returns>
        public Func<ChessBoard, Point, List<Point>> Visit(Pawn pawn)
        {
            return (board, point) =>
            {
                List<Point> possibleMoves = new List<Point>();

                int moveOnYAxis = pawn.Color == Color.white ? 1 : -1;

                // Go forward - cant attack
                Point target = point + new Point(0, moveOnYAxis);
                this.AddMoveIfIsNonAttack(board, target, pawn.Color, possibleMoves);

                // Go diagonal left - can only move if enemy is there
                target = point + new Point(-1, moveOnYAxis);
                this.AddMoveIfIsAttack(board, target, pawn.Color, possibleMoves);

                // Go diagonal right - can only move if enemy is there
                target = point + new Point(1, moveOnYAxis);
                this.AddMoveIfIsAttack(board, target, pawn.Color, possibleMoves);

                return possibleMoves;
            };
        }

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="rook">The <see cref="Rook"/> visiting.</param>
        /// <returns>A function that takes a <see cref="ChessBoard"/> and a <see cref="Point"/> and returns all possible moves for the piece at said <see cref="Point"/> on the <see cref="ChessBoard"/>.</returns>
        public Func<ChessBoard, Point, List<Point>> Visit(Rook rook)
        {
            return (board, point) =>
            {
                List<Point> possibleMoves = new List<Point>();

                // Right
                Point target = point;
                do
                {
                    target += new Point(1, 0);
                } while (this.IsNextMovePossible(board, point, target, rook.Color, possibleMoves));

                // Left
                target = point;
                do
                {
                    target += new Point(-1, 0);
                } while (this.IsNextMovePossible(board, point, target, rook.Color, possibleMoves));

                // UP
                target = point;
                do
                {
                    target += new Point(0, 1);
                } while (this.IsNextMovePossible(board, point, target, rook.Color, possibleMoves));

                // Down
                target = point;
                do
                {
                    target += new Point(0, -1);
                } while (this.IsNextMovePossible(board, point, target, rook.Color, possibleMoves));

                return possibleMoves;
            };
        }

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="bishop">The <see cref="Bishop"/> visiting.</param>
        /// <returns>A function that takes a <see cref="ChessBoard"/> and a <see cref="Point"/> and returns all possible moves for the piece at said <see cref="Point"/> on the <see cref="ChessBoard"/>.</returns>
        public Func<ChessBoard, Point, List<Point>> Visit(Bishop bishop)
        {
            return (board, point) =>
            {
                List<Point> possibleMoves = new List<Point>();

                // Right up
                Point target = point;
                do
                {
                    target += new Point(1, 1);
                } while (this.IsNextMovePossible(board, point, target, bishop.Color, possibleMoves));

                // Left down
                target = point;
                do
                {
                    target += new Point(-1, -1);
                } while (this.IsNextMovePossible(board, point, target, bishop.Color, possibleMoves));

                // UP left
                target = point;
                do
                {
                    target += new Point(-1, 1);
                } while (this.IsNextMovePossible(board, point, target, bishop.Color, possibleMoves));

                // Down right
                target = point;
                do
                {
                    target += new Point(1, -1);
                } while (this.IsNextMovePossible(board, point, target, bishop.Color, possibleMoves));

                return possibleMoves;
            };
        }

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="knight">The <see cref="Knight"/> visiting.</param>
        /// <returns>A function that takes a <see cref="ChessBoard"/> and a <see cref="Point"/> and returns all possible moves for the piece at said <see cref="Point"/> on the <see cref="ChessBoard"/>.</returns>
        public Func<ChessBoard, Point, List<Point>> Visit(Knight knight)
        {
            return (board, point) =>
            {
                List<Point> possibleMoves = new List<Point>();

                Point target = point + new Point(1, 2);
                this.IsNextMovePossible(board, point, target, knight.Color, possibleMoves);
                target = point + new Point(2, 1);
                this.IsNextMovePossible(board, point, target, knight.Color, possibleMoves);
                target = point + new Point(2, -1);
                this.IsNextMovePossible(board, point, target, knight.Color, possibleMoves);
                target = point + new Point(1, -2);
                this.IsNextMovePossible(board, point, target, knight.Color, possibleMoves);
                target = point + new Point(-1, 2);
                this.IsNextMovePossible(board, point, target, knight.Color, possibleMoves);
                target = point + new Point(-2, 1);
                this.IsNextMovePossible(board, point, target, knight.Color, possibleMoves);
                target = point + new Point(-2, -1);
                this.IsNextMovePossible(board, point, target, knight.Color, possibleMoves);
                target = point + new Point(-1, -2);
                this.IsNextMovePossible(board, point, target, knight.Color, possibleMoves);

                return possibleMoves;
            };
        }

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="queen">The <see cref="Queen"/> visiting.</param>
        /// <returns>A function that takes a <see cref="ChessBoard"/> and a <see cref="Point"/> and returns all possible moves for the piece at said <see cref="Point"/> on the <see cref="ChessBoard"/>.</returns>
        public Func<ChessBoard, Point, List<Point>> Visit(Queen queen)
        {
            return (board, point) =>
            {
                List<Point> possibleMoves = new List<Point>();

                // Right
                Point target = point;
                do
                {
                    target += new Point(1, 0);
                } while (this.IsNextMovePossible(board, point, target, queen.Color, possibleMoves));

                // Left
                target = point;
                do
                {
                    target += new Point(-1, 0);
                } while (this.IsNextMovePossible(board, point, target, queen.Color, possibleMoves));

                // UP
                target = point;
                do
                {
                    target += new Point(0, 1);
                } while (this.IsNextMovePossible(board, point, target, queen.Color, possibleMoves));

                // Down
                target = point;
                do
                {
                    target += new Point(0, -1);
                } while (this.IsNextMovePossible(board, point, target, queen.Color, possibleMoves));

                // Right up
                target = point;
                do
                {
                    target += new Point(1, 1);
                } while (this.IsNextMovePossible(board, point, target, queen.Color, possibleMoves));

                // Left down
                target = point;
                do
                {
                    target += new Point(-1, -1);
                } while (this.IsNextMovePossible(board, point, target, queen.Color, possibleMoves));

                // UP left
                target = point;
                do
                {
                    target += new Point(-1, 1);
                } while (this.IsNextMovePossible(board, point, target, queen.Color, possibleMoves));

                // Down right
                target = point;
                do
                {
                    target += new Point(1, -1);
                } while (this.IsNextMovePossible(board, point, target, queen.Color, possibleMoves));

                return possibleMoves;
            };
        }

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="king">The <see cref="King"/> visiting.</param>
        /// <returns>A function that takes a <see cref="ChessBoard"/> and a <see cref="Point"/> and returns all possible moves for the piece at said <see cref="Point"/> on the <see cref="ChessBoard"/>.</returns>
        public Func<ChessBoard, Point, List<Point>> Visit(King king)
        {
            return (board, point) =>
            {
                List<Point> possibleMoves = new List<Point>();

                // Right
                Point target = point + new Point(0, 1);
                this.IsNextMovePossible(board, point, target, king.Color, possibleMoves);

                // Left
                target = point + new Point(1, 1);
                this.IsNextMovePossible(board, point, target, king.Color, possibleMoves);

                // UP
                target = point + new Point(1, 0);
                this.IsNextMovePossible(board, point, target, king.Color, possibleMoves);

                // Down
                target = point + new Point(1, -1);
                this.IsNextMovePossible(board, point, target, king.Color, possibleMoves);

                // Right up
                target = point + new Point(1, 0);
                this.IsNextMovePossible(board, point, target, king.Color, possibleMoves);

                // Left down
                target = point + new Point(-1, -1);
                this.IsNextMovePossible(board, point, target, king.Color, possibleMoves);

                // UP left
                target = point + new Point(-1, 0);
                this.IsNextMovePossible(board, point, target, king.Color, possibleMoves);

                // Down right
                target = point + new Point(-1, 1);
                this.IsNextMovePossible(board, point, target, king.Color, possibleMoves);

                return possibleMoves;
            };
        }

        /// <summary>
        /// Checks if the target <see cref="Point"/> is inside of the <see cref="ChessBoard"/> and if there is an enemy <see cref="ChessPiece"/> at this <see cref="Point"/>.
        /// </summary>
        /// <param name="board">The <see cref="ChessBoard"/>.</param>
        /// <param name="target">The destination <see cref="Point"/> for the current move.</param>
        /// <param name="color">The color of the <see cref="ChessPiece"/> that is moving.</param>
        /// <param name="points">The list of possible moves for the <see cref="ChessPiece"/> in question.</param>
        /// <returns>Whether the move is valid or not.</returns>
        protected virtual bool AddMoveIfIsNonAttack(ChessBoard board, Point target, Color color, List<Point> points)
        {
            if (board.IsInBounds(target) && !board.IsOccupied(target))
            {
                points.Add(target);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the target <see cref="Point"/> is inside of the <see cref="ChessBoard"/> and if there is an enemy <see cref="ChessPiece"/> at this <see cref="Point"/>.
        /// </summary>
        /// <param name="board">The <see cref="ChessBoard"/>.</param>
        /// <param name="target">The destination <see cref="Point"/> for the current move.</param>
        /// <param name="color">The color of the <see cref="ChessPiece"/> that is moving.</param>
        /// <param name="points">The list of possible moves for the <see cref="ChessPiece"/> in question.</param>
        /// <returns>Whether the move is valid or not.</returns>
        protected virtual bool AddMoveIfIsAttack(ChessBoard board, Point target, Color color, List<Point> points)
        {
            if (board.IsInBounds(target) && board.IsOccupied(target, color.Invert()))
            {
                points.Add(target);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Evaluates if the target field is also the last tile to move to (either enemy piece or out of bounds).
        /// </summary>
        /// <param name="board">The <see cref="ChessBoard"/>.</param>
        /// <param name="start">The <see cref="Point"/> of the <see cref="ChessPiece"/> to move.</param>
        /// <param name="target">The destination <see cref="Point"/> for the current move.</param>
        /// <param name="color">The color of the <see cref="ChessPiece"/> that is moving.</param>
        /// <param name="points">The list of possible moves for the <see cref="ChessPiece"/> in question.</param>
        /// <returns>Whether it is the last possible move in the current direction.</returns>
        protected virtual bool IsNextMovePossible(ChessBoard board, Point start, Point target, Color color, List<Point> points)
        {
            if (board.IsInBounds(target) && !board.IsOccupied(target, color))
            {
                points.Add(target);

                return !board.IsOccupied(target, color.Invert());
            }

            return false;
        }
    }
}
