using MyChess.Model.ChessPieces;
using System.Collections.Generic;

namespace MyChess.Model.ChessPieceMovers
{
    public class ChessPieceMover : ChessPieceMovementPattern
    {
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
