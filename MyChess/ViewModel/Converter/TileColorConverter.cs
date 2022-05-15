using MyChess.Model.ChessPieces;
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
    public class TileColorConverter : IValueConverter
    {
        private readonly string whiteTileSource = "Images/Tiles/WhiteTile.png";
        private readonly string blackTileSource = "Images/Tiles/BlackTile.png";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            switch ((Model.ChessPieces.Color)value)
            {
                case Model.ChessPieces.Color.white:
                    if (targetType == typeof(ImageSource))
                    {
                        return (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteTileSource);
                    }

                    return this.whiteTileSource;
                    //targetType == typeof(String) ? (ImageSource)new ImageSourceConverter().ConvertFrom(this.whiteTileSource) : this.whiteTileSource;

                case Model.ChessPieces.Color.black:
                    if (targetType == typeof(ImageSource))
                    {
                        return (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackTileSource);
                    }

                    return this.blackTileSource;

                default:
                    throw new NotImplementedException("Invalid Color!");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
