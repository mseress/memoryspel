using System;
using System.Collections.Generic;
using System.Text;

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

        public Difficulty Difficulty { get; set; }
    }
}
