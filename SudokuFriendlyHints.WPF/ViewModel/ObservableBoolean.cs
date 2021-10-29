using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuFriendlyHints.WPF.ViewModel
{
    public class ObservableBoolean : ViewModelBase
    {
        private bool _value;
        public bool Value
        {
            get => _value;
            set
            {
                if (_value == value)
                    return;

                _value = value;
                OnPropertyChanged();
            }
        }
    }
}
