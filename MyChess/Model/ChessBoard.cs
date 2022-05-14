using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyChess.Model.ChessPieces;
using MyChess.Model.PieceFinders;

namespace MyChess.Model
{
    public class ChessBoard
    {
        private ChessPiece[,] board;
        private ChessPieceMovement mover;

        public int BoardWidth
        {
            get => this.board.GetLength(0);
        }
        public int BoardHeight
        {
            get => this.board.GetLength(1);
        }

        public ChessBoard(int width, int height)
        {
            this.board = new ChessPiece[width, height];
            this.mover = new ChessPieceMovement();
        }

        // TODO
        public List<Point> GetPossibleMoves(Point point)
        {
            if (!this.IsInBounds(point))
            {
                throw new Exception($"The value {nameof(point)} is out of bounds!");
            }

            ChessPiece piece = board[point.X, point.Y];

            if (piece == null)
            {
                return null;
            }

            return piece.Accept(mover)(this, point);
        }

        public bool IsInBounds(Point point) => point.X >= 0 && point.Y >= 0 && point.X < this.BoardWidth && point.Y < this.BoardHeight;

        public bool IsOccupied(Point point)
        {
            if (!this.IsInBounds(point))
            {
                throw new Exception();
            }

            return board[point.X, point.Y] != null;
        }

        public bool IsOccupied(Point point, Color color)
        {
            if (!this.IsInBounds(point))
            {
                throw new Exception();
            }

            return board[point.X, point.Y] != null && board[point.X, point.Y].Color == color;
        }

        private ChessPiece GetPiece(Point point)
        {
            if (!this.IsInBounds(point))
            {
                throw new Exception();
            }

            ChessPiece piece = board[point.X, point.Y];

            if (piece == null)
            {
                throw new Exception();
            }

            return piece;
        }

        public bool PlacePiece(ChessPiece piece, Point point)
        {
            if (this.IsOccupied(point))
            {
                return false;
            }

            this.board[point.X, point.Y] = piece;
            return true;
        }

        public bool IsInCheck(Color color)
        {
            Point kingPosition = new KingFinder().GetPiecePosition(this.GetPiecesAndPosition(color));

            return true;
        }

        public Dictionary<Point, ChessPiece> GetPiecesAndPosition(Color color)
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
    }
}
