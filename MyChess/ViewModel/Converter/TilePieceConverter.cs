// <copyright file="TilePieceConverter.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>A converter for a chess pieces in a grid.</summary>

namespace MyChess.ViewModel.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    using MyChess.Model;
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// A converter for a <see cref="ChessPiece"/> in a grid.
    /// </summary>
    public class TilePieceConverter : IValueConverter, IVisitor<ImageSource>
    {
        /// <summary>
        /// The path to the white pawn graphic.
        /// </summary>
        private readonly string whitePawn = "Images/ChessPieces/WhitePawn.png";

        /// <summary>
        /// The path to the white rook graphic.
        /// </summary>
        private readonly string whiteRook = "Images/ChessPieces/WhiteRook.png";

        /// <summary>
        /// The path to the white knight graphic.
        /// </summary>
        private readonly string whiteKnight = "Images/ChessPieces/WhiteKnight.png";

        /// <summary>
        /// The path to the white bishop graphic.
        /// </summary>
        private readonly string whiteBishop = "Images/ChessPieces/WhiteBishop.png";

        /// <summary>
        /// The path to the white queen graphic.
        /// </summary>
        private readonly string whiteQueen = "Images/ChessPieces/WhiteQueen.png";

        /// <summary>
        /// The path to the white king graphic.
        /// </summary>
        private readonly string whiteKing = "Images/ChessPieces/WhiteKing.png";

        /// <summary>
        /// The path to the black pawn graphic.
        /// </summary>
        private readonly string blackPawn = "Images/ChessPieces/BlackPawn.png";

        /// <summary>
        /// The path to the black rook graphic.
        /// </summary>
        private readonly string blackRook = "Images/ChessPieces/BlackRook.png";

        /// <summary>
        /// The path to the black knight graphic.
        /// </summary>
        private readonly string blackKnight = "Images/ChessPieces/BlackKnight.png";

        /// <summary>
        /// The path to the black bishop graphic.
        /// </summary>
        private readonly string blackBishop = "Images/ChessPieces/BlackBishop.png";

        /// <summary>
        /// The path to the black queen graphic.
        /// </summary>
        private readonly string blackQueen = "Images/ChessPieces/BlackQueen.png";

        /// <summary>
        /// The path to the black king graphic.
        /// </summary>
        private readonly string blackKing = "Images/ChessPieces/BlackKing.png";

        /// <summary>
        /// Converts a <see cref="ChessPieceTileVM"/> into an <see cref="ImageSource"/>.
        /// </summary>
        /// <param name="value">The <see cref="ChessPieceTileVM"/>.</param>
        /// <param name="targetType">The type <see cref="ImageSource"/>.</param>
        /// <param name="parameter">Is ignored.</param>
        /// <param name="culture">Is ignored too.</param>
        /// <returns>The <see cref="ImageSource"/> for the graphic.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            ChessPiece piece = ((ChessPieceTileVM)value).Piece;

            return piece.Accept(this);
        }

        /// <summary>
        /// Converts an <see cref="ImageSource"/> back into a <see cref="ChessPieceTileVM"/>.
        /// </summary>
        /// <param name="value">The <see cref="ImageSource"/>.</param>
        /// <param name="targetType">The type <see cref="ChessPieceTileVM"/>.</param>
        /// <param name="parameter">Is ignored.</param>
        /// <param name="culture">Is ignored too.</param>
        /// <returns>The <see cref="ChessPieceTileVM"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="pawn">The <see cref="Pawn"/> visiting.</param>
        /// <returns>The <see cref="ImageSource"/> for the pawn graphic.</returns>
        ImageSource IVisitor<ImageSource>.Visit(Pawn pawn) => 
            pawn.Color == Model.ChessPieces.Color.white ? 
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whitePawn) 
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackPawn);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="rook">The <see cref="Rook"/> visiting.</param>
        /// <returns>The <see cref="ImageSource"/> for the pawn graphic.</returns>
        ImageSource IVisitor<ImageSource>.Visit(Rook rook) =>
            rook.Color == Model.ChessPieces.Color.white ?
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteRook)
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackRook);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="bishop">The <see cref="Bishop"/> visiting.</param>
        /// <returns>The <see cref="ImageSource"/> for the pawn graphic.</returns>
        ImageSource IVisitor<ImageSource>.Visit(Bishop bishop) =>
            bishop.Color == Model.ChessPieces.Color.white ?
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteBishop)
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackBishop);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="knight">The <see cref="Knight"/> visiting.</param>
        /// <returns>The <see cref="ImageSource"/> for the pawn graphic.</returns>
        ImageSource IVisitor<ImageSource>.Visit(Knight knight) =>
            knight.Color == Model.ChessPieces.Color.white ?
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteKnight)
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackKnight);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="queen">The <see cref="Queen"/> visiting.</param>
        /// <returns>The <see cref="ImageSource"/> for the pawn graphic.</returns>
        ImageSource IVisitor<ImageSource>.Visit(Queen queen) =>
            queen.Color == Model.ChessPieces.Color.white ?
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteQueen)
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackQueen);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="king">The <see cref="King"/> visiting.</param>
        /// <returns>The <see cref="ImageSource"/> for the pawn graphic.</returns>
        ImageSource IVisitor<ImageSource>.Visit(King king) =>
            king.Color == Model.ChessPieces.Color.white ?
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteKing)
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackKing);
    }
}
