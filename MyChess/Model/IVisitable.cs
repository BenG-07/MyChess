// <copyright file="IVisitable.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Defines what is needed for a visitable class in a chess game.</summary>

namespace MyChess.Model
{
    /// <summary>
    /// Defines what is needed for a class that can be visited in a chess game. 
    /// </summary>
    public interface IVisitable
    {
        /// <summary>
        /// Accepts a Visitor and calls an implementation for it.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        void Accept(IVisitor visitor);

        /// <summary>
        /// Accepts a Visitor and calls an implementation for it.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>The result.</returns>
        T Accept<T>(IVisitor<T> visitor);
    }
}
