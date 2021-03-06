using Memoryspel.WpfCore.ViewModels;
using Memoryspel.WpfCore.Views;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Memoryspel.WpfCore.Converters
{
    public class MemoryCardStatusConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var data = this.GetData(values);
            if (data is null)
            {
                return null;
            }

            switch (data.Item1)
            {
                case MemoryCardStatus.TurnedDown:
                    var content = data.Item2.FindResource("TurnedDownContent");
                    return content;
                case MemoryCardStatus.TurnedUp:
                    return data.Item2.ViewModel.Content;
                case MemoryCardStatus.Removed:
                    data.Item2.Visibility = Visibility.Hidden;
                    data.Item2.IsEnabled = false;
                    return data.Item2.ViewModel.Content;
                default:
                    throw new NotImplementedException();
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private Tuple<MemoryCardStatus, MemoryCard> GetData(object[] values)
        {
            MemoryCard card = null;
            MemoryCardStatus? status = null;
            if (values != null)
            {
                foreach (var value in values)
                {
                    if (value is MemoryCardStatus)
                    {
                        status = (MemoryCardStatus)value;
                    }
                    else if (value is MemoryCard)
                    {
                        card = (MemoryCard)value;
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid type.", nameof(value));
                    }
                }

                if (status.HasValue && card != null)
                {
                    return new Tuple<MemoryCardStatus, MemoryCard>(status.Value, card);
                }

                return null;
            }

            return null;
        }
    }
}