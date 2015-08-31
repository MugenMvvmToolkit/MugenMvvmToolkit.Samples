using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;

namespace Validation.WinRT.Converters
{
    public class CollectionToStringConverter : IValueConverter
    {
        #region Implementation of interfaces

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var items = value as IEnumerable<object>;
            if (items == null)
                return null;
            return string.Join(Environment.NewLine, items);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}