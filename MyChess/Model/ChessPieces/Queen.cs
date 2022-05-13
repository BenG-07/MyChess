namespace MyChess.Model.ChessPieces
{
    public class Queen : ChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Queen"/> class.
        /// </summary>
        /// <param name="color">The color of the <see cref="ChessPiece"/></param>
        public Queen(Color color) : base(color)
        {
        }

        /// <summary>
        /// Accepts a Visitor and calls an implementation for it.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        /// <summary>
        /// Accepts a Visitor and calls an implementation for it.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>The result.</returns>
        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
