using MyChess.Model;
using MyChess.Model.ChessPieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyChess.ViewModel
{
    public class ChessPieceTileVM : INotifyPropertyChanged
    {
        private Point point;

        public Point Point
        {
            get { return point; }
            set 
            { 
                point = value;
                this.FireOnPropertyChanged();
            }
        }

        private ChessPiece piece;

        public ChessPiece Piece
        {
            get { return piece; }
            set 
            { 
                piece = value;
                this.FireOnPropertyChanged();
            }
        }
        
        public ICommand SelectCommand { get; set; }

        public ChessPieceTileVM(Point point, ChessPiece piece, ICommand selectCommand)
        {
            this.Point = point;
            this.Piece = piece;
            this.SelectCommand = selectCommand;
        }

        protected virtual void FireOnPropertyChanged([CallerMemberName] string propName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
