using SudokuFriendlyHints.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SudokuFriendlyHints.WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameViewModel GameViewModel { get; } = new GameViewModel();

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void GameView_KeyUp(object sender, KeyEventArgs e)
        {
            int digit = (int)e.Key - (int)Key.D0;
            if (digit >= 1 && digit <= 9)
            {
                GameViewModel.ActiveDigit = digit;
                e.Handled = true;
            }
            else if (e.Key == Key.P)
            {
                GameViewModel.IsInPencilMode = !GameViewModel.IsInPencilMode;
                e.Handled = true;
            }

            GameViewModel.HighlightActiveDigits();
        }
    }
}
