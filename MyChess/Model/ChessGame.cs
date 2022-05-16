// <copyright file="ChessGame.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Represents a chess game.</summary>

namespace MyChess.Model
{
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// The management class of a chess game.
    /// </summary>
    public class ChessGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessGame"/> class.
        /// </summary>
        /// <param name="boardWidth">The width of the board.</param>
        /// <param name="boardHeight">The height of the board.</param>
        public ChessGame(int boardWidth, int boardHeight)
        {
            this.Board = new ChessBoard(boardWidth, boardHeight);
            this.CurrentPlayer = Color.white;
        }

        /// <summary>
        /// Gets the <see cref="ChessBoard"/>.
        /// </summary>
        /// <value>The <see cref="ChessBoard"/> of the game.</value>
        public ChessBoard Board { get; }

        /// <summary>
        /// Gets or sets the <see cref="Color"/> of the current player.
        /// </summary>
        /// <value>The <see cref="Color"/> of the player.</value>
        public Color CurrentPlayer { get; set; }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start()
        {
            this.PlaceFigures();
        }

        /// <summary>
        /// Places all figures onto the board.
        /// </summary>
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
