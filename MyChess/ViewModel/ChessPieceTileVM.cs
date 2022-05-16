// <copyright file="ChessPieceTileVM.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Represents a tile with a chess pieces.</summary>

namespace MyChess.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using MyChess.Model;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// Represents a tile with a chess pieces.
    /// </summary>
    public class ChessPieceTileVM : INotifyPropertyChanged
    {
        /// <summary>
        /// The <see cref="Point"/>.
        /// </summary>
        private Point point;

        /// <summary>
        /// The <see cref="ChessPiece"/>.
        /// </summary>
        private ChessPiece piece;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPieceTileVM"/> class.
        /// </summary>
        /// <param name="point">The <see cref="Point"/>.</param>
        /// <param name="piece">The <see cref="ChessPiece"/>.</param>
        /// <param name="selectCommand">The command.</param>
        public ChessPieceTileVM(Point point, ChessPiece piece, ICommand selectCommand)
        {
            this.Point = point;
            this.Piece = piece;
            this.SelectCommand = selectCommand;
        }

        /// <summary>
        /// An event that is fired when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the <see cref="Point"/>.
        /// </summary>
        /// <value>The <see cref="Point"/>.</value>
        public Point Point
        {
            get
            {
                return this.point;
            }

            set
            {
                this.point = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ChessPiece"/>.
        /// </summary>
        /// <value>The <see cref="ChessPiece"/>.</value>
        public ChessPiece Piece
        {
            get 
            { 
                return this.piece; 
            }

            set
            {
                this.piece = value;
                this.FireOnPropertyChanged();
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
    }
}
