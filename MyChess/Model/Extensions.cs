using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyChess.Model.ChessPieces;

namespace MyChess.Model
{
    public static class Extensions
    {
        public static Color Invert(this Color color) => color == Color.white ? Color.black : Color.white;
    }
}
