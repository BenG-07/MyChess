// <copyright file="Command.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Weirer Benjamin</author>
// <summary>A command that can be set and executed later.</summary>

namespace MyChess.ViewModel
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A command that can be set and executed later.
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// The action to perform.
        /// </summary>
        private Action<object> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public Command(Action<object> action)
        {
            this.action = action;
        }

        /// <summary>
        /// An event that fires when the can execute flag changes.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Checks if the command can be executed.
        /// </summary>
        /// <param name="parameter">Is ignored.</param>
        /// <returns>The boolean value true.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the action with the given parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}
