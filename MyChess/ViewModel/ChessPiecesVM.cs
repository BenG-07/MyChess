using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MyChess.Model;
using MyChess.Model.ChessPieces;

namespace MyChess.ViewModel
{
    public class ChessPiecesVM : INotifyPropertyChanged
    {
        public ChessPieceTileVM[] PieceVMs { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        private ChessGame game;

        private ChessPiece selectedPiece;

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<SelectedPieceChangedEventArgs> SelectedPieceChanged;

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
                    if (this.SelectedPiece != null && this.SelectedPiece == vm.Piece)
                    {
                        this.SelectedPiece = null;
                        this.FireOnPropertyChanged();
                    }

                    this.SelectedPiece = vm.Piece;
                    this.FireOnPropertyChanged();

                    this.FireOnSelectedPieceChanged(this.game.Board.GetPossibleMoves(vm.Point));
                }
            });

            var args = System.Environment.GetCommandLineArgs();
            int width = 8, height = 8;
            if (args.Length >= 2 && !int.TryParse(args[1], out width))
            {
                width = 8;
            }

            if (args.Length >= 3 && !int.TryParse(args[1], out height))
            {
                height = 8;
            }

            this.Width = width;
            this.Height = height;

            this.game = new ChessGame(this.Width, this.Height);
            this.game.Start();

            ChessPieceTileVM[] tiles = new ChessPieceTileVM[this.Width * this.Height];
            foreach (var item in game.Board.GetPiecesAndPositions())
            {
                tiles[item.Key.X * this.Height + item.Key.Y] = new ChessPieceTileVM(this.FlipYAxis(item.Key), item.Value, this.SelectCommand);
            }

            this.PieceVMs = tiles;
        }

        private void PropertyChangedCB(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(sender, e);
        }

        protected virtual void FireOnPropertyChanged([CallerMemberName] string propName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected virtual void FireOnSelectedPieceChanged(List<Point> possibleTiles)
        {
            this.SelectedPieceChanged?.Invoke(this, new SelectedPieceChangedEventArgs(possibleTiles));
        }

        private Point FlipYAxis(Point point)
        {
            return new Point(point.X, this.Height - point.Y - 1);
        }
    }
}
