using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyChess.Model.ChessPieces;
using MyChess.Model.ChessPieceFinders;
using MyChess.Model.ChessPieceMovers;

namespace MyChess.Model
{
    public class ChessBoard
    {
        private ChessPiece[,] board;
        private ChessPieceThreatener threatener;
        private ChessPieceMover mover;

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
            this.threatener = new ChessPieceThreatener();
            this.mover = new ChessPieceMover();
        }

        public static ChessBoard CopyOf(ChessBoard board)
        {
            ChessBoard newBoard = new ChessBoard(board.BoardWidth, board.BoardHeight);
            for (int x = 0; x < board.BoardWidth; x++)
            {
                for (int y = 0; y < board.BoardHeight; y++)
                {
                    newBoard.board[x, y] = board.board[x,y];
                }
            }

            return newBoard;
        }

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

            return piece.Accept(this.mover)(this, point);
        }

        public List<Point> GetThreatenedTiles(Point point)
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

            return piece.Accept(this.threatener)(this, point);
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

        public ChessPiece RemovePiece(Point point)
        {
            if (!this.IsInBounds(point) || !this.IsOccupied(point))
            {
                return null;
            }

            ChessPiece removedPiece = board[point.X, point.Y];
            this.board[point.X, point.Y] = null;
            return removedPiece;
        }

        public bool MovePiece(Point start, Point destination)
        {
            ChessPiece piece = this.RemovePiece(start);
            this.PlacePiece(piece, destination);

            return true;
        }

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
