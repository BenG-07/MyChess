using MyChess.Model.ChessPieces;
using System;
using System.Collections.Generic;

namespace MyChess.Model
{
    public class ChessPieceMovement : IVisitor<Func<ChessBoard, Point, List<Point>>>
    {
        public ChessPieceMovement()
        {

        }

        public Func<ChessBoard, Point, List<Point>> Visit(Pawn pawn)
        {
            return (board, point) =>
            {
                List<Point> possibleMoves = new List<Point>();

                // Go forward
                Point target = point + new Point(0, 1);
                this.AddMoveIfPossible(board, target, possibleMoves);

                // Go diagonal left
                target = point + new Point(-1, 1);
                this.AddMoveIfPossible(board, target, possibleMoves);

                // Go diagonal right
                target = point + new Point(1, 1);
                this.AddMoveIfPossible(board, target, possibleMoves);

                return possibleMoves;
            };
        }

        public Func<ChessBoard, Point, List<Point>> Visit(Rook rook)
        {
            throw new NotImplementedException();
        }

        public Func<ChessBoard, Point, List<Point>> Visit(Bishop bishop)
        {
            throw new NotImplementedException();
        }

        public Func<ChessBoard, Point, List<Point>> Visit(Knight knight)
        {
            throw new NotImplementedException();
        }

        public Func<ChessBoard, Point, List<Point>> Visit(Queen queen)
        {
            throw new NotImplementedException();
        }

        public Func<ChessBoard, Point, List<Point>> Visit(King king)
        {
            throw new NotImplementedException();
        }

        private bool AddMoveIfPossible(ChessBoard board, Point target, List<Point> points)
        {
            if (board.IsInBounds(target) && !board.IsOccupied(target))
            {
                points.Add(Point.CopyOf(target));
                return true;
            }

            return false;
        }

    }
}
