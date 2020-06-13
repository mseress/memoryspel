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

        public MemoryCardViewModel()
        {            
            this.Height = 150;
            this.Width = 200;
        }
    }
}
