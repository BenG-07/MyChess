// <copyright file="SelectedPieceChangedEventArgs.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>The event arguments for when a seleceted piece changes.</summary>

namespace MyChess.ViewModel
{
    using System.Collections.Generic;
    using MyChess.Model;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// The event arguments for when a selected piece changes.
    /// </summary>
    public class SelectedPieceChangedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedPieceChangedEventArgs"/> class.
        /// </summary>
        /// <param name="possibleTiles">The possible tiles.</param>
        public SelectedPieceChangedEventArgs(List<Point> possibleTiles)
        {
            this.PossibleTiles = possibleTiles;
        }

        /// <summary>
        /// Gets or sets the list of the possible tiles a <see cref="ChessPiece"/> can move to.
        /// </summary>
        /// <value>The possible tiles.</value>
        public List<Point> PossibleTiles { get; set; }
    }
}
