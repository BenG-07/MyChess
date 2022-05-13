using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Model
{
    class ChessGame
    {
        public ChessBoard Board { get; set; }

        public ChessPieceMovement ChessPieceMovement { get; set; }

        public ChessGame()
        {
            this.Board = new ChessBoard(8, 8);
            this.ChessPieceMovement = new ChessPieceMovement();
        }


    }
}
