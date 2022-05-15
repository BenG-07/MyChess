using MyChess.Model.ChessPieces;
using System;
using System.Collections.Generic;

namespace MyChess.Model.ChessPieceMovers
{
    public abstract class ChessPieceMovementPattern : IVisitor<Func<ChessBoard, Point, List<Point>>>
    {
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

        protected virtual bool AddMoveIfIsNonAttack(ChessBoard board, Point target, Color color, List<Point> points)
        {
            if (board.IsInBounds(target) && !board.IsOccupied(target))
            {
                points.Add(target);
                return true;
            }

            return false;
        }

        protected virtual bool AddMoveIfIsAttack(ChessBoard board, Point target, Color color, List<Point> points)
        {
            if (board.IsInBounds(target) && board.IsOccupied(target, color.Invert()))
            {
                points.Add(target);
                return true;
            }

            return false;
        }

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
