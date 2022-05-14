using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyChess.Model.ChessPieces;

namespace MyChess.Model
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);

        T Accept<T>(IVisitor<T> visitor);
    }
}
