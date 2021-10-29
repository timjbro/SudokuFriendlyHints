using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuFriendlyHints.WPF.Model
{
    class Cell
    {
        public int Value { get; set; } = -1;

        public bool[] PencilMarks { get; set; }
    }
}
