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
            this.MemoryCardsControl.DataContext = new MemoryCardsViewModel(6, 12);
            this.DataContext = new MainWindowViewModel();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            var startGameDialog = new StartGameDialog();
            if (startGameDialog.ShowDialog() != true)
            {
                this.Close();
            }

            this.ViewModel.StartTime = DateTime.Now;
            var timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.ViewModel.ElapsedTime += TimeSpan.FromSeconds(1);
        }
    }
}
