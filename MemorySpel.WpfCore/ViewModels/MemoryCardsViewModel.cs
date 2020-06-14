using MemorySpel.WpfCore.Views;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MemorySpel.WpfCore.ViewModels
{
    public class MemoryCardsViewModel : ViewModel
    {
        public List<MemoryCard> Cards { get; private set; }

        public int NumberOfRows { get; private set; }

        public int NumberOfColumns { get; private set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public MemoryCardsViewModel(int numberOfRows, int numberOfColumns)
        {
            this.NumberOfColumns = numberOfColumns;
            this.NumberOfRows = numberOfRows;            
        }        

        public void SetupCards()
        {
            this.Cards = new List<MemoryCard>();
            for (int i = 0; i < this.NumberOfRows * this.NumberOfColumns; i++)
            {
                var card = new MemoryCard();
                card.DataContext = new MemoryCardViewModel(this.Width, this.Height, this.NumberOfRows, this.NumberOfColumns);
                this.Cards.Add(card);
            }

            this.SetupCardPairs();
        }

        private void SetupCardPairs()
        {
            for (int i = 0; i < this.Cards.Count; i += 2)
            {
                this.AddRandomContentsToCardPair(this.Cards[i], this.Cards[i + 1]);
                this.Cards[i].Tag = this.Cards[i + 1].Tag = i;
            }

            this.Cards.Shuffle();
        }

        private void AddRandomContentsToCardPair(MemoryCard card1, MemoryCard card2)
        {
            var viewModel1 = card1.DataContext as MemoryCardViewModel;
            var viewModel2 = card2.DataContext as MemoryCardViewModel;
            var stackPanel1 = new StackPanel();
            var stackPanel2 = new StackPanel();
            stackPanel1.VerticalAlignment = stackPanel2.VerticalAlignment = VerticalAlignment.Center;
            var numberOfShapes = RandomHelper.Random.Next(1, 4);
            for (int i = 0; i < numberOfShapes; i++)
            {
                Shape shape = null;
                if (RandomHelper.Random.Next(0, 2) % 2 == 0)
                {
                    shape = new Rectangle();
                    shape.Width = viewModel1.Width / 3;
                    shape.Height = viewModel1.Width / 4;
                }
                else
                {
                    shape = new Ellipse();
                    shape.Width = shape.Height = viewModel1.Width / 4;
                }

                shape.Fill = new SolidColorBrush(RandomHelper.NextColor());
                shape.HorizontalAlignment = HorizontalAlignment.Center;
                shape.Margin = new Thickness(8);
                stackPanel1.Children.Add(shape);
                stackPanel2.Children.Add(this.CopyShape(shape));
            }

            viewModel1.Content = stackPanel1;
            viewModel2.Content = stackPanel2;
        }

        private Shape CopyShape(Shape shape)
        {
            Shape copiedShape = null;
            if (shape is Rectangle)
            {
                copiedShape = new Rectangle();
            }
            else if (shape is Ellipse)
            {
                copiedShape = new Ellipse();
            }
            else
            {
                throw new NotImplementedException("Unknown shape type.");
            }

            copiedShape.Fill = shape.Fill;
            copiedShape.Width = shape.Width;
            copiedShape.Height = shape.Height;
            copiedShape.HorizontalAlignment = shape.HorizontalAlignment;
            copiedShape.Margin = shape.Margin;
            return copiedShape;
        }
    }
}
