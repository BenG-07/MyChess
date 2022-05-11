using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Model
{
    public abstract class ChessPiece : IVisitable
    {
        public abstract void Accept(IVisitor visitor);
    }
}
