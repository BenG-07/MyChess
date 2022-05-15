using MyChess.Model.ChessPieces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MyChess.ViewModel
{
    class TileColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string whiteTileSource = "Images/Tiles/WhiteTile.png";
            string blackTileSource = "Images/Tiles/BlackTile.png";

            switch ((Model.ChessPieces.Color)value)
            {
                case Model.ChessPieces.Color.white:
                    if (targetType == typeof(ImageSource))
                    {
                        return (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + whiteTileSource);
                    }

                    return whiteTileSource;
                    //targetType == typeof(String) ? (ImageSource)new ImageSourceConverter().ConvertFrom(whiteTileSource) : whiteTileSource;

                case Model.ChessPieces.Color.black:
                    if (targetType == typeof(ImageSource))
                    {
                        return (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + blackTileSource);
                    }

                    return blackTileSource;

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
