using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyChess.Model;
using MyChess.Model.ChessPieces;

namespace MyChess.ViewModel
{
    public class ChessPiecesVM : INotifyPropertyChanged
    {
        public IEnumerable<ChessPieceTileVM> PieceVMs { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        private ChessGame game;

        private ChessPiece selectedPiece;

        public event PropertyChangedEventHandler PropertyChanged;

        public ChessPiece SelectedPiece
        {
            get { return this.selectedPiece; }
            set 
            {
                selectedPiece = value;
                this.FireOnPropertyChanged(nameof(this.SelectedPiece));
            }
        }

        public ICommand SelectCommand { get; set; }

        public ChessPiecesVM()
        {
            this.SelectCommand = new Command(obj =>
            {
                if (obj is ChessPieceTileVM vm)
                {
                    if (this.SelectedPiece.Equals(vm.Piece))
                    {
                        this.SelectedPiece = null;
                        this.FireOnPropertyChanged();
                    }

                    this.SelectedPiece = vm.Piece;
                }
            });

            var args = System.Environment.GetCommandLineArgs();
            this.Width = 8;
            this.Height = 10;

            this.game = new ChessGame(this.Width, this.Height);
            this.game.Start();

            ChessPieceTileVM[] tiles = new ChessPieceTileVM[32];
            int index = 0;
            foreach (var item in game.Board.GetPiecesAndPositions())
            {
                tiles[index++] = new ChessPieceTileVM(item.Key, item.Value, this.SelectCommand);
            }

            this.PieceVMs = tiles;
        }

        private void PropertyChangedCB(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }

        protected virtual void FireOnPropertyChanged([CallerMemberName] string propName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
