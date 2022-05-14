using MyChess.Model.ChessPieces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyChess.ViewModel
{
    class TileColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Color)value)
            {
                case Color.white:
                    return "Images/Tiles/WhiteTile.png";

                case Color.black:
                    return "Images/Tiles/BlackTile.png";

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
