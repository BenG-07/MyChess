// <copyright file="IVisitor.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Defines what is needed for a visitor class in a chess game.</summary>

namespace MyChess.Model
{
    using MyChess.Model.ChessPieces;

    /// <summary>
    /// Defines what is needed for a visitor class in a chess game.
    /// </summary>
    public interface IVisitor
    {
        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="pawn">The <see cref="Pawn"/> visiting.</param>
        void Visit(Pawn pawn);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="rook">The <see cref="Rook"/> visiting.</param>
        void Visit(Rook rook);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="bishop">The <see cref="Bishop"/> visiting.</param>
        void Visit(Bishop bishop);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="knight">The <see cref="Knight"/> visiting.</param>
        void Visit(Knight knight);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="queen">The <see cref="Queen"/> visiting.</param>
        void Visit(Queen queen);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="king">The <see cref="King"/> visiting.</param>
        void Visit(King king);
    }

    /// <summary>
    /// Defines what is needed for a visitor class in a chess game.
    /// </summary>
    /// <typeparam name="T">A generic type.</typeparam>
    public interface IVisitor<T>
    {
        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="pawn">The <see cref="Pawn"/> visiting.</param>
        /// <returns>The an instance of the expected generic return type.</returns>
        T Visit(Pawn pawn);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="rook">The <see cref="Rook"/> visiting.</param>
        /// <returns>The an instance of the expected generic return type.</returns>
        T Visit(Rook rook);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="bishop">The <see cref="Bishop"/> visiting.</param>
        /// <returns>The an instance of the expected generic return type.</returns>
        T Visit(Bishop bishop);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="knight">The <see cref="Knight"/> visiting.</param>
        /// <returns>The an instance of the expected generic return type.</returns>
        T Visit(Knight knight);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="queen">The <see cref="Queen"/> visiting.</param>
        /// <returns>The an instance of the expected generic return type.</returns>
        T Visit(Queen queen);

        /// <summary>
        /// The callback for a <see cref="IVisitable"/> object.
        /// </summary>
        /// <param name="king">The <see cref="King"/> visiting.</param>
        /// <returns>The an instance of the expected generic return type.</returns>
        T Visit(King king);
    }
}
