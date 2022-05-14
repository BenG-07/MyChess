using MyChess.Model.ChessPieces;
using System.Collections.Generic;

namespace MyChess.Model.ChessPieceFinders
{
    public abstract class PieceFinder : IVisitor<bool>
    {
        public abstract Point GetPiecePosition(Dictionary<Point, ChessPiece> pieces);
               
        public virtual bool Visit(Pawn pawn) => false;
               
        public virtual bool Visit(Rook rook) => false;
               
        public virtual bool Visit(Bishop bishop) => false;
               
        public virtual bool Visit(Knight knight) => false;
               
        public virtual bool Visit(Queen queen) => false;
               
        public virtual bool Visit(King king) => false;
    }
}
