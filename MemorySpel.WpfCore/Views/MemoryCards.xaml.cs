using MemorySpel.WpfCore.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MemorySpel.WpfCore.Views
{
    /// <summary>
    /// Interaction logic for MemoryCards.xaml
    /// </summary>
    public partial class MemoryCards : UserControl
    {
        public MemoryCardsViewModel ViewModel { get { return this.DataContext as MemoryCardsViewModel; } }

        public bool IsRendered { get; private set; }

        public MemoryCards()
        {
            InitializeComponent();            
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            // HACK: for some reason the OnRender method is called twice, so we manually have to make sure we only run the 
            // setup logic once. The setup logic has to be run after rendering, because the control's size is only finalized 
            // then - which is needed for determining the right size for the cards
            if (!this.IsRendered)
            {
                this.ViewModel.Width = this.MainGrid.ActualWidth;
                this.ViewModel.Height = this.MainGrid.ActualHeight;
                this.ViewModel.SetupCards();
                this.SetupMainGrid();
                this.AddCardsToGrid();
                this.IsRendered = true;
            }            
        }

        private void AddCardsToGrid()
        {
            for (int i = 0; i < this.ViewModel.NumberOfRows; i++)
            {
                for (int j = 0; j < this.ViewModel.NumberOfColumns; j++)
                {
                    var card = this.ViewModel.Cards[i * this.ViewModel.NumberOfColumns + j];
                    Grid.SetRow(card, i);
                    Grid.SetColumn(card, j);
                    this.MainGrid.Children.Add(card);
                }
            }
        }

        private void SetupMainGrid()
        {
            for (int i = 0; i < this.ViewModel.NumberOfRows; i++)
            {
                this.MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < this.ViewModel.NumberOfColumns; i++)
            {
                this.MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
        }

        private void UserControl_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var turnedUpCards = this.ViewModel.Cards.Where(c => c.ViewModel.Status == MemoryCardStatus.TurnedUp).ToArray();
            if (turnedUpCards.Count() == 2)
            {
                if (turnedUpCards[0].Tag == turnedUpCards[1].Tag)
                {
                    foreach (var card in turnedUpCards)
                    {
                        card.ViewModel.Status = MemoryCardStatus.Removed;
                    }
                }
                else
                {
                    foreach (var card in turnedUpCards)
                    {
                        card.ViewModel.Status = MemoryCardStatus.TurnedDown;
                    }
                }
            }            
        }
    }
}
