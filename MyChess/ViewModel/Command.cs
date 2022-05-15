using System;
using System.Windows.Input;

namespace MyChess.ViewModel
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> action;

        public Command(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}