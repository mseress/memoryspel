using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MemorySpel.WpfCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int NumberOfRows { get; set; }

        public int NumberOfColumns { get; set; }

        public List<MemoryCard> Cards { get; set; }

        private static readonly Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            this.NumberOfRows = 5;
            this.NumberOfColumns = 6;
            this.AddCards();
        }

        private void AddCards()
        {
            this.Cards = new List<MemoryCard>();
            this.SetupMainGrid();
            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {                    
                    var card = new MemoryCard();
                    card.DataContext = new MemoryCardViewModel(this.ActualWidth, this.ActualHeight, this.NumberOfRows, this.NumberOfColumns);

                    Grid.SetRow(card, i);
                    Grid.SetColumn(card, j);
                    this.MainGrid.Children.Add(card);
                    this.Cards.Add(card);
                }
            }

            this.AddRandomContentsToCards();
        }

        private void AddRandomContentsToCards()
        {
            for (int i = 0; i < this.Cards.Count; i += 2)
            {
                this.AddRandomContentsToCardPair(this.Cards[i], this.Cards[i + 1]);
            }

            // TODO: randomize/shuffle the whole list and then update the grid
        }

        private void AddRandomContentsToCardPair(MemoryCard card1, MemoryCard card2)
        {
            var viewModel1 = card1.DataContext as MemoryCardViewModel;
            var viewModel2 = card2.DataContext as MemoryCardViewModel;
            var stackPanel = new StackPanel();            
            var numberOfShapes = _random.Next(1, 4);
            for (int i = 0; i < numberOfShapes; i++)
            {
                var color = new System.Windows.Media.Color()
                {
                    A = 255,
                    R = (byte)_random.Next(0, 256),
                    G = (byte)_random.Next(0, 256),
                    B = (byte)_random.Next(0, 256),
                };

                Shape shape = null;
                if (_random.Next(0, 2) % 2 == 0)
                {                    
                    shape = new System.Windows.Shapes.Rectangle();                    
                    shape.Width = viewModel1.Width / 3;
                    shape.Height = viewModel1.Width / 4;
                }
                else
                {
                    shape = new Ellipse();
                    shape.Width = shape.Height = viewModel1.Width / 4;
                }

                // TODO: create 2 identical instances instead of reusing the same reference
                shape.Fill = new SolidColorBrush(color);
                shape.HorizontalAlignment = HorizontalAlignment.Center;
                shape.Margin = new Thickness(8);
                stackPanel.Children.Add(shape);
            }
            
            viewModel1.Content = viewModel2.Content = stackPanel;
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
