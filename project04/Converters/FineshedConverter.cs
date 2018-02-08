using System;
using System.Globalization;
using Xamarin.Forms;

namespace project04.Converters
{
    public class FineshedConverter: IValueConverter
    {
        public object Convert(object value,Type targetType, object parameter, CultureInfo culture)
        {
            var valor = (bool) value;

            if (valor == false)
            {
                return "https://storage.googleapis.com/material-icons/external-assets/v4/icons/svg/ic_cancel_black_24px.svg";
            }
            else
            {
                return "https://storage.googleapis.com/material-icons/external-assets/v4/icons/svg/ic_check_circle_black_24px.svg";
            }
        }

        public object ConvertBack(object value, Type targetType,object parameter, CultureInfo culture)
        {
            return false;
        }

        public FineshedConverter()
        {
        }
    }
}
