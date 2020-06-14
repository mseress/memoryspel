using MemorySpel.WpfCore.ViewModels;
using MemorySpel.WpfCore.Views;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MemorySpel.WpfCore.Converters
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
                    var viewModel = data.Item2.DataContext as MemoryCardViewModel;
                    return viewModel.Content;
                case MemoryCardStatus.Removed:
                    throw new NotImplementedException();
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