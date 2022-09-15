using System;
using System.Globalization;
using System.Windows.Data;

namespace Demo
{
    class AgregatingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var grouppViewModel = values[0] as GroupStateViewModel;

            var group = values[2] as CollectionViewGroup;
            grouppViewModel?.Init(group);
            var tmp = values[1];
            if (parameter?.ToString() == "Price")
            {
                return grouppViewModel.PriceImpactSum;
            }
            return grouppViewModel.TimeImpactSum;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}