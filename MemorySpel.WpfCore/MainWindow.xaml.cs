﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

            this.SetupCardPairs();
        }

        private void SetupCardPairs()
        {
            for (int i = 0; i < this.Cards.Count; i += 2)
            {
                this.AddRandomContentsToCardPair(this.Cards[i], this.Cards[i + 1]);
                this.Cards[i].Tag = this.Cards[i + 1].Tag = i;
            }

            // TODO: randomize/shuffle the whole list and then update the grid
        }

        private void AddRandomContentsToCardPair(MemoryCard card1, MemoryCard card2)
        {
            var viewModel1 = card1.DataContext as MemoryCardViewModel;
            var viewModel2 = card2.DataContext as MemoryCardViewModel;
            var stackPanel1 = new StackPanel();            
            var stackPanel2 = new StackPanel();
            stackPanel1.VerticalAlignment = stackPanel2.VerticalAlignment = VerticalAlignment.Center;
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

                shape.Fill = new SolidColorBrush(color);
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
            if (shape is System.Windows.Shapes.Rectangle)
            {
                copiedShape = new System.Windows.Shapes.Rectangle();                
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
