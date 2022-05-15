using MyChess.Model;
using System.Collections.Generic;

namespace MyChess.ViewModel
{
    public class SelectedPieceChangedEventArgs
    {
        public List<Point> PossibleTiles { get; set; }

        public SelectedPieceChangedEventArgs(List<Point> possibleTiles)
        {
            this.PossibleTiles = possibleTiles;
        }
    }
}