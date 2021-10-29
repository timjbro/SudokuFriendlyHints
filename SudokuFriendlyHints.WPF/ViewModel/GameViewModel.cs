using SudokuFriendlyHints.WPF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuFriendlyHints.WPF.ViewModel
{
    class GameViewModel : ViewModelBase, IGameInteractiveState
	{
		private const int gridDimention = 9;
		private const int gridCellCount = gridDimention * gridDimention;

		public CellViewModel[] CellViewModels { get; } = new CellViewModel[gridCellCount];

		public GameViewModel()
		{
			for (int i = 0; i < gridCellCount; i++)
				CellViewModels[i] = new CellViewModel(this);
		}

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
    }
}
