// <copyright file="ChessPiecesVM.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Represents a chessboard with chess pieces.</summary>

namespace MyChess.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using MyChess.Model;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// A class to represent a chessboard with chess pieces.
    /// </summary>
    public class ChessPiecesVM : INotifyPropertyChanged
    {
        /// <summary>
        /// The <see cref="ChessGame"/>.
        /// </summary>
        private ChessGame game;

        /// <summary>
        /// The selected <see cref="ChessPiece"/>.
        /// </summary>
        private ChessPiece selectedPiece;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPiecesVM"/> class.
        /// </summary>
        public ChessPiecesVM()
        {
            this.SelectCommand = new Command(obj =>
            {
                if (obj is ChessPieceTileVM vm)
                {
                    if (this.SelectedPiece != null && this.SelectedPiece == vm.Piece)
                    {
                        this.SelectedPiece = null;
                        this.FireOnPropertyChanged();
                    }

                    this.SelectedPiece = vm.Piece;
                    this.FireOnPropertyChanged();

                    this.FireOnSelectedPieceChanged(this.game.Board.GetPossibleMoves(vm.Point));
                }
            });

            var args = System.Environment.GetCommandLineArgs();
            int width = 8, height = 8;
            if (args.Length >= 2 && !int.TryParse(args[1], out width))
            {
                width = 8;
            }

            if (args.Length >= 3 && !int.TryParse(args[1], out height))
            {
                height = 8;
            }

            this.Width = width;
            this.Height = height;

            this.game = new ChessGame(this.Width, this.Height);
            this.game.Start();

            ChessPieceTileVM[] tiles = new ChessPieceTileVM[this.Width * this.Height];
            foreach (var item in this.game.Board.GetPiecesAndPositions())
            {
                tiles[(item.Key.X * this.Height) + item.Key.Y] = new ChessPieceTileVM(this.FlipYAxis(item.Key), item.Value, this.SelectCommand);
            }

            this.PieceVMs = tiles;
        }

        /// <summary>
        /// An event that is fired when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// An event that is fired when a piece is selected/deselected.
        /// </summary>
        public event EventHandler<SelectedPieceChangedEventArgs> SelectedPieceChanged;

        /// <summary>
        /// Gets or sets the chess tiles with pieces.
        /// </summary>
        /// <value>The chess tiles with pieces.</value>
        public ChessPieceTileVM[] PieceVMs { get; set; }

        /// <summary>
        /// Gets or sets the width of the board.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the board.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the selected <see cref="ChessPiece"/> on the board.
        /// </summary>
        /// <value>The selected <see cref="ChessPiece"/>.</value>
        public ChessPiece SelectedPiece
        {
            get 
            { 
                return this.selectedPiece; 
            }

            set
            {
                this.selectedPiece = value;
                this.FireOnPropertyChanged(nameof(this.SelectedPiece));
            }
        }

        /// <summary>
        /// Gets or sets the command to be executed when a <see cref="ChessPiece"/> is selected/deselected.
        /// </summary>
        /// <value>The command.</value>
        public ICommand SelectCommand { get; set; }

        /// <summary>
        /// Fires the property changed event.
        /// </summary>
        /// <param name="propName">The name of the property that changed.</param>
        protected virtual void FireOnPropertyChanged([CallerMemberName] string propName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// Fires the selection changed event.
        /// </summary>
        /// <param name="possibleTiles">The list of all threatened tiles.</param>
        protected virtual void FireOnSelectedPieceChanged(List<Point> possibleTiles)
        {
            this.SelectedPieceChanged?.Invoke(this, new SelectedPieceChangedEventArgs(possibleTiles));
        }

        /// <summary>
        /// A callback for when the property changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void PropertyChangedCB(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Flips the Y axis of a <see cref="Point"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point"/>.</param>
        /// <returns>A new point with inverted Y value.</returns>
        private Point FlipYAxis(Point point)
        {
            return new Point(point.X, this.Height - point.Y - 1);
        }
    }
}
