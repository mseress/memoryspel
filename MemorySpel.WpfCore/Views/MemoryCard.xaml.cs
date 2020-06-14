using MemorySpel.WpfCore.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MemorySpel.WpfCore.Views
{
    /// <summary>
    /// Interaction logic for MemoryCard.xaml
    /// </summary>
    public partial class MemoryCard : Border
    {
        public MemoryCardViewModel ViewModel { get { return this.DataContext as MemoryCardViewModel; } }

        public MemoryCard()
        {
            InitializeComponent();
        }

        private void Border_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // flipping the card
            if (sender is MemoryCard memoryCard && memoryCard.DataContext is MemoryCardViewModel viewModel)
            {
                if (viewModel.Status == MemoryCardStatus.TurnedDown)
                {
                    viewModel.Status = MemoryCardStatus.TurnedUp;
                }
                else if (viewModel.Status == MemoryCardStatus.TurnedUp)
                {
                    viewModel.Status = MemoryCardStatus.TurnedDown;
                }
            }

            // incrementing click count
            (Application.Current.MainWindow as MainWindow).ViewModel.NumberOfClicks++;
        }
    }
}
