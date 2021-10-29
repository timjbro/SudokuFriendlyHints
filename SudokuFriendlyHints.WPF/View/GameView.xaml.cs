using SudokuFriendlyHints.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : UserControl
    {
        public Game()
        {
            InitializeComponent();

            DataContext = new GameViewModel();
        }

        private void UserControl_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            var gameViewModel = DataContext as GameViewModel;
            if (gameViewModel == null)
                throw new ApplicationException($"{nameof(UserControl_PreviewKeyUp)}() datacontext was invalid.");

            int digit = (int)e.Key - (int)Key.D0;
            if (digit >= 1 && digit <= 9)
            {
                gameViewModel.ActiveDigit = digit;
                e.Handled = true;
            }
            else if (e.Key == Key.P)
            {
                gameViewModel.IsInPencilMode = !gameViewModel.IsInPencilMode;
                e.Handled = true;
            }
        }
    }
}
