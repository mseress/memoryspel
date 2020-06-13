using System.Windows;
using System.Windows.Controls;

namespace MemorySpel.WpfCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int NumberOfRows { get; set; }

        public int NumberOfColumns { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.NumberOfRows = 5;
            this.NumberOfColumns = 5;
            this.AddCards();
        }

        private void AddCards()
        {
            this.SetupMainGrid();
            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {                    
                    var card = new MemoryCard();    
                    card.DataContext = new MemoryCardViewModel();

                    Grid.SetRow(card, i);
                    Grid.SetColumn(card, j);
                    card.Margin = new Thickness(10);
                    this.MainGrid.Children.Add(card);
                }
            }
        }

        private void SetupMainGrid()
        {
            for (int i = 0; i < this.NumberOfRows; i++)
            {
                this.MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < this.NumberOfColumns; i++)
            {
                this.MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
        }
    }
}
