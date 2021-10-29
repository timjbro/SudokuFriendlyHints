using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SudokuFriendlyHints.WPF.ViewModel
{
    public class CellViewModel : ViewModelBase
    {
        private readonly IGameInteractiveState _gameInteractiveState;

        public CellViewModel(IGameInteractiveState gameInteractiveState)
        {
            _gameInteractiveState = gameInteractiveState;

            for (int i = 0; i < 9; i++)
                PencilMarks[i] = new ObservableBoolean();
        }

        #region Pencil

        public ObservableBoolean[] PencilMarks { get; } = new ObservableBoolean[9];

        private RelayCommand<object> _ClickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (_ClickCommand == null)
                {
                    _ClickCommand = new RelayCommand<object>((p) =>
                    {
                        if (_gameInteractiveState.IsInPencilMode)
                        {
                            int pencilIndex = _gameInteractiveState.ActiveDigit - 1;
                            if (pencilIndex < 0 || pencilIndex >= PencilMarks.Length)
                                return;

                            PencilMarks[pencilIndex].Value = !PencilMarks[pencilIndex].Value;
                        }
                        else
                        {
                            if (Digit == _gameInteractiveState.ActiveDigit)
                                Digit = 0;
                            else if (Digit == 0)
                                Digit = _gameInteractiveState.ActiveDigit;
                        }
                    });
                }

                return _ClickCommand;
            }
        }

        #endregion

        #region Digit

        private int _Digit = 0;
        public int Digit
        {
            get => _Digit;
            set
            {
                if (_Digit == value)
                    return;

                _Digit = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasDigit));
            }
        }

        public bool HasDigit => Digit != 0;

        #endregion
    }
}
