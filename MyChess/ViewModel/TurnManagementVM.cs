using MyChess.Model.Turn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyChess;
using System.Windows.Input;

namespace MyChess.ViewModel
{
    public class TurnManagementVM
    {
        private ICommand recoverCommand;

        public ObservableCollection<TurnVM> Turns { get; set; }

        public TurnManagementVM()
        {
            this.recoverCommand = new Command(obj =>
            {
                if (obj is TurnVM vm)
                {
                    this.RevertTo(Turns.IndexOf(vm));
                }
            });

            Turns = new ObservableCollection<TurnVM>();
            Turns.Add(new TurnVM(this.Turns.Count + 1, new Turn(Model.ChessPieces.Color.white, new Model.Point(0, 0), new Model.Point(1, 1)), this.recoverCommand));
            Turns.Add(new TurnVM(this.Turns.Count + 1, new Turn(Model.ChessPieces.Color.black, new Model.Point(7, 7), new Model.Point(0, 7)), this.recoverCommand));
            Turns.Add(new TurnVM(this.Turns.Count + 1, new Turn(Model.ChessPieces.Color.white, new Model.Point(6, 6), new Model.Point(2, 4)), this.recoverCommand));
        }

        public void AddTurn(Turn turn)
        {
            this.Turns.Add(new TurnVM(this.Turns.Count + 1, turn, this.recoverCommand));
        }

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

            for (int i = this.Turns.Count - 1; i > turn ; i--)
            {
                this.Turns.RemoveAt(i);
            }
        }
    }
}
