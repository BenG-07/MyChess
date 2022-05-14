using MyChess.Model.ChessPieces;
using System;
using System.Collections.Generic;

namespace MyChess.Model.PieceFinders
{
    public class KingFinder : PieceFinder
    {
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

        public override bool Visit(King king) => true;
    }
}
