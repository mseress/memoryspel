using System.Windows;

namespace MemorySpel.WpfCore
{
    public class MemoryCardViewModel : ViewModel
    {
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

        public int Margin { get; set; }

        public MemoryCardViewModel(double windowWidth, double windowHeight, int numberOfRows, int numberOfColumns)
        {            
            this.NumberOfRows = numberOfRows;
            this.NumberOfColumns = numberOfColumns;
            this.WindowHeight = windowHeight;
            this.WindowWidth = windowWidth;
            this.Margin = 10;

            this.Width = this.WindowWidth / this.NumberOfColumns - this.Margin * 2;
            this.Height = this.WindowHeight / this.NumberOfRows - this.Margin * 2;
        }
    }
}
