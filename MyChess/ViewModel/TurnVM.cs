using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyChess.Model.Turn;

namespace MyChess.ViewModel
{
    public class TurnVM : INotifyPropertyChanged
    {
        public int TurnNumber { get; set; }
        public Turn Turn { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RecoverCommand { get; private set; }

        protected virtual void FireOnPropertyChanged([CallerMemberName] string propName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public TurnVM(int turnNumber, Turn turn, ICommand recoverCommand)
        {
            this.TurnNumber = turnNumber;
            this.Turn = turn;
            this.RecoverCommand = recoverCommand;
        }
    }
}
