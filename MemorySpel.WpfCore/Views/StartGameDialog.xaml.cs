using Memoryspel.WpfCore.ViewModels;
using System.Windows;

namespace Memoryspel.WpfCore.Views
{
    /// <summary>
    /// Interaction logic for StartGameDialog.xaml
    /// </summary>
    public partial class StartGameDialog : Window
    {
        public StartGameDialog()
        {
            InitializeComponent();
        }

        private void EasyDifficultyButton_Click(object sender, RoutedEventArgs e)
        {
            this.SelectDifficulty(Difficulty.Easy);
        }

        private void NormalDifficultyButton_Click(object sender, RoutedEventArgs e)
        {

            this.SelectDifficulty(Difficulty.Normal);
        }

        private void HardDifficultyButton_Click(object sender, RoutedEventArgs e)
        {
            this.SelectDifficulty(Difficulty.Hard);
        }

        private void SelectDifficulty(Difficulty difficulty)
        {
            if (Application.Current.MainWindow.DataContext is MainWindowViewModel viewModel)
            {
                viewModel.Difficulty = difficulty;
            }

            this.DialogResult = true;
        }
    }
}
