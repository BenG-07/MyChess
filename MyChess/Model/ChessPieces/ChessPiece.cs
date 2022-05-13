using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Model.ChessPieces
{
    public abstract class ChessPiece : IVisitable
    {
        public Color Color { get; set; }

        public ChessPiece(Color color)
        {
            this.Color = color;
        }

        public abstract void Accept(IVisitor visitor);
        public abstract T Accept<T>(IVisitor<T> visitor);
    }
}
