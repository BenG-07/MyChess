using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyChess.Model.ChessPieces;

namespace MyChess.Model
{
    public interface IVisitor
    {
        void Visit(Pawn pawn);
        void Visit(Rook rook);
        void Visit(Bishop bishop);
        void Visit(Knight knight);
        void Visit(Queen queen);
        void Visit(King king);
    }

    public interface IVisitor<T>
    {
        T Visit(Pawn pawn);
        T Visit(Rook rook);
        T Visit(Bishop bishop);
        T Visit(Knight knight);
        T Visit(Queen queen);
        T Visit(King king);
    }
}
