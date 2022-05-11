using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
