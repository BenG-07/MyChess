using MyChess.Model.ChessPieces;
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

        public ChessGame()
        {
            this.Board = new ChessBoard(8, 8);
        }

        public void Start()
        {
            this.PlaceFigures();
            var temp = this.Board.GetPossibleMoves(new Point(0, 1)); // 0, 2
            this.Board.PlacePiece(new Knight(Color.black), new Point(1, 2));
            this.Board.PlacePiece(new Knight(Color.black), new Point(2, 2));
            var temp2 = this.Board.GetPossibleMoves(new Point(1, 1)); // 2, 2
            this.Board.PlacePiece(new Knight(Color.white), new Point(7, 2));
            this.Board.PlacePiece(new Knight(Color.white), new Point(5, 2));
            var temp3 = this.Board.GetPossibleMoves(new Point(6, 1)); // 6, 2
        }

        private void PlaceFigures()
        {
            int topRow = this.Board.BoardHeight - 1;
            this.Board.PlacePiece(new Rook(Color.black), new Point(0, topRow));
            this.Board.PlacePiece(new Knight(Color.black), new Point(1, topRow));
            this.Board.PlacePiece(new Bishop(Color.black), new Point(2, topRow));
            this.Board.PlacePiece(new Queen(Color.black), new Point(3, topRow));
            this.Board.PlacePiece(new King(Color.black), new Point(4, topRow));
            this.Board.PlacePiece(new Bishop(Color.black), new Point(5, topRow));
            this.Board.PlacePiece(new Knight(Color.black), new Point(6, topRow));
            this.Board.PlacePiece(new Rook(Color.black), new Point(7, topRow));
            for (int i = 0; i < 8; i++)
            {
                this.Board.PlacePiece(new Pawn(Color.black), new Point(i, topRow - 1));
            }

            this.Board.PlacePiece(new Rook(Color.white), new Point(0, 0));
            this.Board.PlacePiece(new Knight(Color.white), new Point(1, 0));
            this.Board.PlacePiece(new Bishop(Color.white), new Point(2, 0));
            this.Board.PlacePiece(new Queen(Color.white), new Point(3, 0));
            this.Board.PlacePiece(new King(Color.white), new Point(4, 0));
            this.Board.PlacePiece(new Bishop(Color.white), new Point(5, 0));
            this.Board.PlacePiece(new Knight(Color.white), new Point(6, 0));
            this.Board.PlacePiece(new Rook(Color.white), new Point(7, 0));
            for (int i = 0; i < 8; i++)
            {
                this.Board.PlacePiece(new Pawn(Color.white), new Point(i, 1));
            }
        }
    }
}
