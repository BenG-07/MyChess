// <copyright file="ChessBoard.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Represents a chess board.</summary>

namespace MyChess.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MyChess.Model.ChessPieceFinders;
    using MyChess.Model.ChessPieceMovers;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// Manages all necessities for a chess board.
    /// </summary>
    public class ChessBoard
    {
        /// <summary>
        /// A 2d array with <see cref="ChessPiece"/>s on it (null if empty).
        /// </summary>
        private ChessPiece[,] board;

        /// <summary>
        /// An analyzer for all threats.
        /// </summary>
        private ChessPieceThreatener threatener;

        /// <summary>
        /// An analyzer for all possible moves.
        /// </summary>
        private ChessPieceMover mover;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBoard"/> class.
        /// </summary>
        /// <param name="width">The width of the chess board.</param>
        /// <param name="height">The height of the chess board.</param>
        public ChessBoard(int width, int height)
        {
            this.board = new ChessPiece[width, height];
            this.threatener = new ChessPieceThreatener();
            this.mover = new ChessPieceMover();
        }

        /// <summary>
        /// Gets the width of the board.
        /// </summary>
        /// <value>The width of the board.</value>
        public int BoardWidth
        {
            get => this.board.GetLength(0);
        }

        /// <summary>
        /// Gets the height of the board.
        /// </summary>
        /// <value>The height of the board.</value>
        public int BoardHeight
        {
            get => this.board.GetLength(1);
        }

        /// <summary>
        /// Creates a copy of the board with all information.
        /// </summary>
        /// <param name="board">The board to copy.</param>
        /// <returns>A new instance of a board with the same values as the reference board.</returns>
        public static ChessBoard CopyOf(ChessBoard board)
        {
            ChessBoard newBoard = new ChessBoard(board.BoardWidth, board.BoardHeight);
            for (int x = 0; x < board.BoardWidth; x++)
            {
                for (int y = 0; y < board.BoardHeight; y++)
                {
                    newBoard.board[x, y] = board.board[x, y];
                }
            }

            return newBoard;
        }

        /// <summary>
        /// Gets all possible moves for a <see cref="ChessPiece"/> at a certain <see cref="Point"/> on the board.
        /// </summary>
        /// <param name="point">The <see cref="Point"/> of the <see cref="ChessPiece"/>.</param>
        /// <returns>A list with all possible moves.</returns>
        public List<Point> GetPossibleMoves(Point point)
        {
            if (!this.IsInBounds(point))
            {
                throw new Exception($"The value {nameof(point)} is out of bounds!");
            }

            ChessPiece piece = this.board[point.X, point.Y];

            if (piece == null)
            {
                return null;
            }

            return piece.Accept(this.mover)(this, point);
        }

        /// <summary>
        /// Gets all threatened <see cref="Point"/>s for a <see cref="ChessPiece"/> at a certain <see cref="Point"/> on the board.
        /// </summary>
        /// <param name="point">The <see cref="Point"/> of the <see cref="ChessPiece"/>.</param>
        /// <returns>A list with all threatened <see cref="Point"/>s.</returns>
        public List<Point> GetThreatenedTiles(Point point)
        {
            if (!this.IsInBounds(point))
            {
                throw new Exception($"The value {nameof(point)} is out of bounds!");
            }

            ChessPiece piece = this.board[point.X, point.Y];

            if (piece == null)
            {
                return null;
            }

            return piece.Accept(this.threatener)(this, point);
        }

        /// <summary>
        /// Checks if a <see cref="Point"/> is within the board.
        /// </summary>
        /// <param name="point">The <see cref="Point"/> in question.</param>
        /// <returns>Whether the <see cref="Point"/> is inside the board or not.</returns>
        public bool IsInBounds(Point point) => point.X >= 0 && point.Y >= 0 && point.X < this.BoardWidth && point.Y < this.BoardHeight;

        /// <summary>
        /// Checks if a <see cref="Point"/> is occupied.
        /// </summary>
        /// <param name="point">The <see cref="Point"/> in question.</param>
        /// <returns>Whether the <see cref="Point"/> is occupied or not.</returns>
        public bool IsOccupied(Point point)
        {
            if (!this.IsInBounds(point))
            {
                throw new Exception();
            }

            return this.board[point.X, point.Y] != null;
        }

        /// <summary>
        /// Checks if a <see cref="Point"/> is occupied by a certain <see cref="Color"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point"/> in question.</param>
        /// <param name="color">The <see cref="Color"/> in question.</param>
        /// <returns>Whether the <see cref="Point"/> is occupied by the <see cref="Color"/> player or not.</returns>
        public bool IsOccupied(Point point, Color color)
        {
            if (!this.IsInBounds(point))
            {
                throw new Exception();
            }

            return this.board[point.X, point.Y] != null && this.board[point.X, point.Y].Color == color;
        }

        /// <summary>
        /// Places a <see cref="ChessPiece"/> at a certain <see cref="Point"/> on the board.
        /// </summary>
        /// <param name="piece">The <see cref="ChessPiece"/> to place.</param>
        /// <param name="point">The <see cref="Point"/> to place the <see cref="ChessPiece"/> at.</param>
        /// <returns>Whether the <see cref="ChessPiece"/> could be placed or not.</returns>
        public bool PlacePiece(ChessPiece piece, Point point)
        {
            if (this.IsOccupied(point))
            {
                return false;
            }

            this.board[point.X, point.Y] = piece;
            return true;
        }

        /// <summary>
        /// Removes a <see cref="ChessPiece"/> at a certain <see cref="Point"/> on the board.
        /// </summary>
        /// <param name="point">The <see cref="Point"/> to remove the <see cref="ChessPiece"/> at.</param>
        /// <returns>The <see cref="ChessPiece"/> that was removed.</returns>
        public ChessPiece RemovePiece(Point point)
        {
            if (!this.IsInBounds(point) || !this.IsOccupied(point))
            {
                return null;
            }

            ChessPiece removedPiece = this.board[point.X, point.Y];
            this.board[point.X, point.Y] = null;
            return removedPiece;
        }

        /// <summary>
        /// Moves a piece from one <see cref="Point"/> to another.
        /// </summary>
        /// <param name="start">The start <see cref="Point"/>.</param>
        /// <param name="destination">The destination <see cref="Point"/>.</param>
        /// <returns>Whether the piece could be moved or not.</returns>
        public bool MovePiece(Point start, Point destination)
        {
            ChessPiece piece = this.RemovePiece(start);
            this.PlacePiece(piece, destination);

            return true;
        }

        /// <summary>
        /// Checks if a certain <see cref="Color"/> player is in check.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> of the player.</param>
        /// <returns>Whether the player is in check or not.</returns>
        public bool IsInCheck(Color color)
        {
            Point kingPosition = new KingFinder().GetPiecePosition(this.GetPiecesAndPositions(color));
            List<Point> enemies = this.GetPiecesPositions(color.Invert());
            foreach (var enemy in enemies)
            {
                if (this.GetThreatenedTiles(enemy).Any(p => p.X == kingPosition.X && p.Y == kingPosition.Y))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a certain <see cref="Color"/> player has possible moves.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> of the player.</param>
        /// <returns>Whether the player has possible moves or not.</returns>
        public bool HasMoves(Color color)
        {
            List<Point> pieces = this.GetPiecesPositions(color);
            foreach (var piece in pieces)
            {
                if (this.GetPossibleMoves(piece).Count != 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets all <see cref="ChessPiece"/> on the board with their corresponding <see cref="Point"/> from a certain <see cref="Color"/>.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> of the player to get all pieces from.</param>
        /// <returns>A key-value pair of all <see cref="Point"/>s and <see cref="ChessPiece"/>s from the <see cref="Color"/> player.</returns>
        public Dictionary<Point, ChessPiece> GetPiecesAndPositions(Color color)
        {
            Dictionary<Point, ChessPiece> pieces = new Dictionary<Point, ChessPiece>();
            for (int x = 0; x < this.BoardWidth; x++)
            {
                for (int y = 0; y < this.BoardHeight; y++)
                {
                    ChessPiece piece = this.board[x, y];
                    if (piece == null || piece.Color != color)
                    {
                        continue;
                    }

                    pieces.Add(new Point(x, y), piece);
                }
            }

            return pieces;
        }

        /// <summary>
        /// Gets all <see cref="ChessPiece"/> on the board with their corresponding <see cref="Point"/>.
        /// </summary>
        /// <returns>A key-value pair of all <see cref="Point"/>s and <see cref="ChessPiece"/>s.</returns>
        public Dictionary<Point, ChessPiece> GetPiecesAndPositions()
        {
            Dictionary<Point, ChessPiece> pieces = new Dictionary<Point, ChessPiece>();
            for (int x = 0; x < this.BoardWidth; x++)
            {
                for (int y = 0; y < this.BoardHeight; y++)
                {
                    ChessPiece piece = this.board[x, y];
                    if (piece == null)
                    {
                        continue;
                    }

                    pieces.Add(new Point(x, y), piece);
                }
            }

            return pieces;
        }

        /// <summary>
        /// Gets all <see cref="Point"/>s of the <see cref="ChessPiece"/>s from a certain <see cref="Color"/>.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> of the player to get all <see cref="Point"/>s from.</param>
        /// <returns>A list of all <see cref="Point"/>s of the <see cref="ChessPiece"/>s from the <see cref="Color"/> player.</returns>
        public List<Point> GetPiecesPositions(Color color)
        {
            List<Point> positions = new List<Point>();
            for (int x = 0; x < this.BoardWidth; x++)
            {
                for (int y = 0; y < this.BoardHeight; y++)
                {
                    ChessPiece piece = this.board[x, y];
                    if (piece == null || piece.Color != color)
                    {
                        continue;
                    }

                    positions.Add(new Point(x, y));
                }
            }

            return positions;
        }
    }
}
