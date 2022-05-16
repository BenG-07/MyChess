// <copyright file="Point.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>A point in 2 dimensional space.</summary>

namespace MyChess.Model
{
    /// <summary>
    /// A point in 2 dimensional space.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// The x coordinate.
        /// </summary>
        private int x;

        /// <summary>
        /// The y coordinate.
        /// </summary>
        private int y;

        /// <summary>
        /// Initializes a new instance of the Point class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        /// <value>The y coordinate.</value>
        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        /// <value>The y coordinate.</value>
        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// Adds two <see cref="Point"/>s together.
        /// </summary>
        /// <param name="a">The first <see cref="Point"/>.</param>
        /// <param name="b">The second <see cref="Point"/>.</param>
        /// <returns>The resulting <see cref="Point"/> after adding all axis together.</returns>
        public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);

        /// <summary>
        /// Subtracts <see cref="Point"/> from another.
        /// </summary>
        /// <param name="a">The reference <see cref="Point"/>.</param>
        /// <param name="b">The <see cref="Point"/> to subtract.</param>
        /// <returns>The resulting <see cref="Point"/> after subtracting the second from the first.</returns>
        public static Point operator -(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y);

        /// <summary>
        /// Creates a copy of a <see cref="Point"/> reference.
        /// </summary>
        /// <param name="point">The reference.</param>
        /// <returns>A new instance of a <see cref="Point"/> with the same values as the reference.</returns>
        public static Point CopyOf(Point point)
        {
            return new Point(point.X, point.Y);
        }

        /// <summary>
        /// Compares two <see cref="Point"/>s.
        /// </summary>
        /// <param name="a">The first <see cref="Point"/>.</param>
        /// <param name="b">The second <see cref="Point"/>.</param>
        /// <returns>Whether the two <see cref="Point"/>s are at the same location or not.</returns>
        public static bool operator ==(Point a, Point b) => a.X == b.X && a.Y == b.Y;

        /// <summary>
        /// Compares two <see cref="Point"/>s.
        /// </summary>
        /// <param name="a">The first <see cref="Point"/>.</param>
        /// <param name="b">The second <see cref="Point"/>.</param>
        /// <returns>Whether the two <see cref="Point"/>s are at different locations or not.</returns>
        public static bool operator !=(Point a, Point b) => a.X != b.X || a.Y != b.Y;

        /// <summary>
        /// Tries to parse a string to a point object.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <param name="p">The reference to the point object.</param>
        /// <returns>Whether the action was successful or not.</returns>
        public static bool TryParse(string s, out Point p)
        {
            p = new Point(0, 0);

            string[] parts;

            if ((parts = s.Split(',')).Length != 2 || !parts[0].StartsWith("X: ") || !parts[1].StartsWith(" Y: ") || !int.TryParse(parts[0].Substring(3, parts[0].Length), out int tempX) || !int.TryParse(parts[0].Substring(4, parts[0].Length), out int tempY))
            {
                return false;
            }

            p.X = tempX;
            p.Y = tempY;

            return true;
        }

        /// <summary>
        /// The ToString method.
        /// </summary>
        /// <returns>The point parameters as a formatted string.</returns>
        public override string ToString()
        {
            return $"X: {this.X}, Y: {this.Y}";
        }
    }
}
