using MemorySpel.WpfCore.ViewModels;
using System;
using System.Windows;
using System.Windows.Threading;

namespace MemorySpel.WpfCore.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get { return this.DataContext as MainWindowViewModel; } }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            var startGameDialog = new StartGameDialog();
            startGameDialog.CenterWindowOnScreen();
            if (startGameDialog.ShowDialog() != true)
            {
                this.Close();
            }

            this.ViewModel.StartTime = DateTime.Now;
            var timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += Timer_Tick;

            this.MemoryCardsControl.DataContext = new MemoryCardsViewModel(this.ViewModel.Difficulty);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.ViewModel.ElapsedTime += TimeSpan.FromSeconds(1);
        }
    }
}
