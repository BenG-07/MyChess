using MyChess.Model.ChessPieces;
using MyChess.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MyChess.ViewModel.Converter
{
    public class TilePieceConverter : IValueConverter, IVisitor<ImageSource>
    {
        private readonly string whitePawn = "Images/ChessPieces/WhitePawn.png";
        private readonly string whiteRook = "Images/ChessPieces/WhiteRook.png";
        private readonly string whiteKnight = "Images/ChessPieces/WhiteKnight.png";
        private readonly string whiteBishop = "Images/ChessPieces/WhiteBishop.png";
        private readonly string whiteQueen = "Images/ChessPieces/WhiteQueen.png";
        private readonly string whiteKing = "Images/ChessPieces/WhiteKing.png";

        private readonly string blackPawn = "Images/ChessPieces/BlackPawn.png";
        private readonly string blackRook = "Images/ChessPieces/BlackRook.png";
        private readonly string blackKnight = "Images/ChessPieces/BlackKnight.png";
        private readonly string blackBishop = "Images/ChessPieces/BlackBishop.png";
        private readonly string blackQueen = "Images/ChessPieces/BlackQueen.png";
        private readonly string blackKing = "Images/ChessPieces/BlackKing.png";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            ChessPiece piece = ((ChessPieceTileVM)value).Piece;

            return piece.Accept(this);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        ImageSource IVisitor<ImageSource>.Visit(Pawn pawn) => 
            pawn.Color == Model.ChessPieces.Color.white ? 
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whitePawn) 
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackPawn);
        

        ImageSource IVisitor<ImageSource>.Visit(Rook rook) =>
            rook.Color == Model.ChessPieces.Color.white ?
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteRook)
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackRook);

        ImageSource IVisitor<ImageSource>.Visit(Bishop bishop) =>
            bishop.Color == Model.ChessPieces.Color.white ?
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteBishop)
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackBishop);

        ImageSource IVisitor<ImageSource>.Visit(Knight knight) =>
            knight.Color == Model.ChessPieces.Color.white ?
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteKnight)
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackKnight);

        ImageSource IVisitor<ImageSource>.Visit(Queen queen) =>
            queen.Color == Model.ChessPieces.Color.white ?
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteQueen)
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackQueen);

        ImageSource IVisitor<ImageSource>.Visit(King king) =>
            king.Color == Model.ChessPieces.Color.white ?
            (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteKing)
            : (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackKing);
    }
}
