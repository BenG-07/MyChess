// <copyright file="TilePositionConverter.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>A converter for a tile in a grid.</summary>

namespace MyChess.ViewModel.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// A converter for a tile in a grid.
    /// </summary>
    public class TilePositionConverter : IValueConverter
    {
        /// <summary>
        /// Converts a tile index into a tile position based on the parameter.
        /// </summary>
        /// <param name="value">The index.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The value to multiply the index with.</param>
        /// <param name="culture">Is ignored.</param>
        /// <returns>The exact position of a tile.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
        }

        /// <summary>
        /// Converts a tile position into a tile index based on the parameter.
        /// </summary>
        /// <param name="value">The position.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The value to divide the position with.</param>
        /// <param name="culture">Is ignored.</param>
        /// <returns>The index of a tile.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) / System.Convert.ToDouble(parameter);
        }
    }
}
