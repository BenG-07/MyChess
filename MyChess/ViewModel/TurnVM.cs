// <copyright file="TurnVM.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Represents the vm of a turn in a chess game.</summary>

namespace MyChess.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using MyChess.Model.Turn;

    /// <summary>
    /// A class to graphically represents a turn history of a chess game.
    /// </summary>
    public class TurnVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TurnVM"/> class.
        /// </summary>
        /// <param name="turnNumber">The current turn number.</param>
        /// <param name="turn">The <see cref="Turn"/> taken.</param>
        /// <param name="recoverCommand">The command to recover to a <see cref="Turn"/>.</param>
        public TurnVM(int turnNumber, Turn turn, ICommand recoverCommand)
        {
            this.TurnNumber = turnNumber;
            this.Turn = turn;
            this.RecoverCommand = recoverCommand;
        }

        /// <summary>
        /// An event to fire when a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the current turn.
        /// </summary>
        /// <value>The turn number.</value>
        public int TurnNumber { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Turn"/> taken.
        /// </summary>
        /// <value>The <see cref="Turn"/> made.</value>
        public Turn Turn { get; set; }

        /// <summary>
        /// Gets the command to be executed when a turn is recovered.
        /// </summary>
        /// <value>The command.</value>
        public ICommand RecoverCommand { get; private set; }

        /// <summary>
        /// Fires the property changed event.
        /// </summary>
        /// <param name="propName">The name of the property that changed.</param>
        protected virtual void FireOnPropertyChanged([CallerMemberName] string propName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
