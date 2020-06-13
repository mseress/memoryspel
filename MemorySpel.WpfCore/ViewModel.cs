using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MemorySpel.WpfCore
{
    /// <summary>
    /// Abstract class to be used for view model classes. Implements <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is called when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method to be called when a property changes so that the UI thread can be notified.
        /// </summary>
        /// <param name="propertyName">The name of the property that just changed.</param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
