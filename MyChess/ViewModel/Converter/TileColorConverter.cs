// <copyright file="TileColorConverter.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>A converter for a chess tile in a grid.</summary>

namespace MyChess.ViewModel.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// A class to convert a <see cref="Color"/> into an <see cref="ImageSource"/>.
    /// </summary>
    public class TileColorConverter : IValueConverter
    {
        /// <summary>
        /// The path to the white tile graphic.
        /// </summary>
        private readonly string whiteTileSource = "Images/Tiles/WhiteTile.png";

        /// <summary>
        /// The path to the white tile graphic.
        /// </summary>
        private readonly string blackTileSource = "Images/Tiles/BlackTile.png";

        /// <summary>
        /// Converts a <see cref="Color"/> into an <see cref="ImageSource"/>.
        /// </summary>
        /// <param name="value">The <see cref="Color"/>.</param>
        /// <param name="targetType">The type <see cref="ImageSource"/>.</param>
        /// <param name="parameter">Is ignored.</param>
        /// <param name="culture">Is not used.</param>
        /// <returns>The <see cref="ImageSource"/> for the graphic.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Model.ChessPieces.Color)value)
            {
                case Model.ChessPieces.Color.white:
                    return (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.whiteTileSource);

                case Model.ChessPieces.Color.black:
                    return (ImageSource)new ImageSourceConverter().ConvertFrom("../../View/" + this.blackTileSource);

                default:
                    throw new NotImplementedException("Invalid Color!");
            }
        }

        /// <summary>
        /// Converts an <see cref="ImageSource"/> back into a <see cref="Color"/>.
        /// </summary>
        /// <param name="value">The <see cref="ImageSource"/>.</param>
        /// <param name="targetType">The type <see cref="Color"/>.</param>
        /// <param name="parameter">Is ignored.</param>
        /// <param name="culture">Is ignored too.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
