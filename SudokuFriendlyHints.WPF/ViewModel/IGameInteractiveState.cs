using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuFriendlyHints.WPF.ViewModel
{
    public interface IGameInteractiveState
    {
        int ActiveDigit { get; }

        bool IsInPencilMode { get; }

        void OnCellDigitSet(CellViewModel cell);
    }
}
