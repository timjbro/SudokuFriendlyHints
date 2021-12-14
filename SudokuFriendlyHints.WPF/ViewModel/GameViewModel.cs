using SudokuFriendlyHints.WPF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuFriendlyHints.WPF.ViewModel
{
    public class GameViewModel : ViewModelBase, IGameInteractiveState
    {
        private const int gridDimention = 9;
        private const int gridCellCount = gridDimention * gridDimention;

        private CellViewModel[,] _cellViewModels2D = new CellViewModel[gridDimention, gridDimention];
        public CellViewModel[] CellViewModels { get; } = new CellViewModel[gridCellCount];

        public GameViewModel()
        {
            for (int x = 0; x < gridDimention; x++)
            {
                for (int y = 0; y < gridDimention; y++)
                {
                    int index = x + (y * gridDimention);
                    var cell = new CellViewModel(this, x, y);
                    CellViewModels[index] = cell;
                    _cellViewModels2D[x, y] = cell;
                }
            }
        }

        #region User Input

        private int _ActiveDigit = 1;
        public int ActiveDigit
        {
            get => _ActiveDigit;
            set
            {
                if (_ActiveDigit == value)
                    return;

                _ActiveDigit = value;
                OnPropertyChanged();
            }
        }

        private bool _IsInPencilMode;
        public bool IsInPencilMode
        {
            get => _IsInPencilMode;
            set
            {
                if (_IsInPencilMode == value)
                    return;

                _IsInPencilMode = value;
                OnPropertyChanged();
            }
        }

        public void HighlightActiveDigits()
        {
            foreach (var cell in CellViewModels)
            {
                cell.UpdateHighlight();
            }
        }

        public void OnCellDigitSet(CellViewModel cell)
        {
            // Clear Row Pencil Marks
            for (int x = 0; x < gridDimention; x++)
            {
                var tempCell = _cellViewModels2D[x, cell.Y];
                tempCell.PencilMarks[cell.Digit - 1].Value = false;
                tempCell.UpdateHighlight();
            }

            // Clear Column Pencil Marks
            for (int y = 0; y < gridDimention; y++)
            {
                var tempCell = _cellViewModels2D[cell.X, y];
                tempCell.PencilMarks[cell.Digit - 1].Value = false;
                tempCell.UpdateHighlight();
            }

            // Clear Block Pencil Marks
            int blockX = (cell.X / 3) * 3;
            int blockY = (cell.Y / 3) * 3;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    var tempCell = _cellViewModels2D[blockX + x, blockY + y];
                    tempCell.PencilMarks[cell.Digit - 1].Value = false;
                    tempCell.UpdateHighlight();
                }
            }
        }

        #endregion
    }
}
