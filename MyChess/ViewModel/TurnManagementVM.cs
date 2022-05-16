// <copyright file="TurnManagementVM.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>Manages the turn history of a chess game.</summary>

namespace MyChess.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using MyChess.Model.Turn;

    /// <summary>
    /// A class that manages the turn history of a chess game.
    /// </summary>
    public class TurnManagementVM
    {
        /// <summary>
        /// The command to be executed when a turn is recovered.
        /// </summary>
        /// <value>The command.</value>
        private ICommand recoverCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnManagementVM"/> class.
        /// </summary>
        public TurnManagementVM()
        {
            this.recoverCommand = new Command(obj =>
            {
                if (obj is TurnVM vm)
                {
                    this.RevertTo(Turns.IndexOf(vm));
                }
            });

            this.Turns = new ObservableCollection<TurnVM>();
            this.Turns.Add(new TurnVM(this.Turns.Count + 1, new Turn(Model.ChessPieces.Color.white, new Model.Point(0, 0), new Model.Point(1, 1)), this.recoverCommand));
            this.Turns.Add(new TurnVM(this.Turns.Count + 1, new Turn(Model.ChessPieces.Color.black, new Model.Point(7, 7), new Model.Point(0, 7)), this.recoverCommand));
            this.Turns.Add(new TurnVM(this.Turns.Count + 1, new Turn(Model.ChessPieces.Color.white, new Model.Point(6, 6), new Model.Point(2, 4)), this.recoverCommand));
        }

        /// <summary>
        /// Gets or sets the observable collection of <see cref="TurnVM"/>s.
        /// </summary>
        /// <value>An observable collection.</value>
        public ObservableCollection<TurnVM> Turns { get; set; }

        /// <summary>
        /// Adds a turn to the history.
        /// </summary>
        /// <param name="turn">The <see cref="Turn"/> to add.</param>
        public void AddTurn(Turn turn)
        {
            this.Turns.Add(new TurnVM(this.Turns.Count + 1, turn, this.recoverCommand));
        }

        /// <summary>
        /// Reverts the current turn to a previous one.
        /// </summary>
        /// <param name="turn">The amount of turns to revert.</param>
        public void RevertTo(int turn)
        {
            if (turn < 1)
            {
                turn = 1;
            }

            if (turn > this.Turns.Count)
            {
                return;
            }

            for (int i = this.Turns.Count - 1; i > turn; i--)
            {
                this.Turns.RemoveAt(i);
            }
        }
    }
}
