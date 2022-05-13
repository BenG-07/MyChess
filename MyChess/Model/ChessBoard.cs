using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyChess.Model.ChessPieces;

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

        // TODO
        public bool IsProtectingKing(Point point)
        {
            ChessPiece piece = this.GetPiece(point);

            return false;
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
    }
}
