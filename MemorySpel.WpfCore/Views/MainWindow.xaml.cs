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

        public DispatcherTimer Timer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            this.StartGame();
            this.MemoryCardsControl.DataContext = new MemoryCardsViewModel(this.ViewModel.Difficulty);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.ViewModel.ElapsedTime += TimeSpan.FromSeconds(1);
        }

        private void StartGame()
        {
            var startGameDialog = new StartGameDialog();
            startGameDialog.CenterWindowOnScreen();
            if (startGameDialog.ShowDialog() != true)
            {
                this.Close();
            }

            this.ViewModel.StartTime = DateTime.Now;
            this.Timer = new DispatcherTimer(DispatcherPriority.Background);
            this.Timer.Interval = TimeSpan.FromSeconds(1);
            this.Timer.IsEnabled = true;
            this.Timer.Tick += Timer_Tick;
        }

        public void EndGame()
        {
            this.ViewModel.TotalTime = DateTime.Now - this.ViewModel.StartTime;
            this.Timer.Stop();            
            var endGameDialog = new EndGameDialog();
            endGameDialog.CenterWindowOnScreen();
            endGameDialog.DataContext = this.DataContext;
            endGameDialog.ShowDialog();
            this.Close();
        }                
    }
}
