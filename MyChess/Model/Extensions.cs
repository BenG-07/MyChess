// <copyright file="Extensions.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>A collection of all extension methods necessary for a chess game.</summary>

namespace MyChess.Model
{
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// A static class with various extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// An extension to invert the color of a player.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to invert.</param>
        /// <returns>The inverted <see cref="Color"/>.</returns>
        public static Color Invert(this Color color) => color == Color.white ? Color.black : Color.white;
    }
}
