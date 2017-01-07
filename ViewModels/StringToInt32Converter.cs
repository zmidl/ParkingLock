using System;
using System.Globalization;
using System.Windows.Data;

namespace Demo.ViewModels
{
	public class StringToInt32Converter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int result = 0;
			try
			{
				result = int.Parse(value.ToString());
			}
			catch { }
			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value.ToString();
		}
	}
}
