using System;

namespace MemorySpel.WpfCore.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private TimeSpan _elapsedTime;

        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
            set 
            { 
                if (_elapsedTime != value)
                {
                    _elapsedTime = value;
                    this.OnPropertyChanged();
                }                
            }
        }

        public DateTime StartTime { get; set; }

        public TimeSpan? TotalTime { get; set; }

        public Difficulty Difficulty { get; set; }

        private int _numberOfClicks;

        public int NumberOfClicks
        {
            get { return _numberOfClicks; }
            set 
            { 
                if (_numberOfClicks != value)
                {
                    _numberOfClicks = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
