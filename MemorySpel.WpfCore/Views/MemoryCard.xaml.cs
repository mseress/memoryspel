using MemorySpel.WpfCore.ViewModels;
using System.Windows.Controls;

namespace MemorySpel.WpfCore.Views
{
    /// <summary>
    /// Interaction logic for MemoryCard.xaml
    /// </summary>
    public partial class MemoryCard : Border
    {
        public MemoryCard()
        {
            InitializeComponent();
        }

        private void Border_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
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
        }
    }
}
