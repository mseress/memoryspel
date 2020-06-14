using System.Windows;

namespace Memoryspel.WpfCore.ViewModels
{
    public class MemoryCardViewModel : ViewModel
    {
        /// <summary>
        /// A heuristical good proportion for the sides of a card (width / height).
        /// </summary>
        private const double SIDE_PROPORTION = 313.0 / 499.0;

        private double _height;

        public double Height
        {
            get { return _height; }
            set 
            {
                if (_height != value)
                {
                    _height = value;
                    this.OnPropertyChanged();
                }                
            }
        }

        private double _width;

        public double Width
        {
            get { return _width; }
            set 
            {
                if (_width != value)
                {
                    _width = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private MemoryCardStatus _status;

        public MemoryCardStatus Status
        {
            get { return _status; }
            set 
            { 
                if (_status != value)
                {
                    _status = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public UIElement Content { get; set; }

        public double WindowWidth { get; private set; }

        public double WindowHeight { get; private set; }

        public int NumberOfRows { get; private set; }

        public int NumberOfColumns { get; private set; }

        /// <summary>
        /// The margin of a <see cref="MemoryCard"/> has to be at least this big.
        /// </summary>
        public int MinimumMargin { get; set; }

        public MemoryCardViewModel(double windowWidth, double windowHeight, int numberOfRows, int numberOfColumns)
        {            
            this.NumberOfRows = numberOfRows;
            this.NumberOfColumns = numberOfColumns;
            this.WindowHeight = windowHeight;
            this.WindowWidth = windowWidth;
            this.MinimumMargin = 10;

            // calculating the right size for the card
            var maxWidthForCard = this.WindowWidth / this.NumberOfColumns - this.MinimumMargin * 2;
            var maxHeightForCard = this.WindowHeight / this.NumberOfRows - this.MinimumMargin * 2;
            if (maxHeightForCard <= maxWidthForCard)
            {
                this.Height = maxHeightForCard;
                this.Width = this.Height * SIDE_PROPORTION;
            }
            else
            {
                this.Width = maxWidthForCard;
                this.Height = Width / SIDE_PROPORTION;
                if (this.Height > maxHeightForCard)
                {
                    this.Height = maxHeightForCard;
                    this.Width = this.Height * SIDE_PROPORTION;
                }
            }
        }
    }
}
