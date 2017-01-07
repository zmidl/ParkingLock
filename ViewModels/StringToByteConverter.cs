using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Demo.ViewModels
{
	public class StringToByteConverter : IValueConverter
	{
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int result = 0;
			try
			{
				result = byte.Parse(value.ToString());
			}
			catch { }
			return result;
			//throw new NotImplementedException();
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value.ToString();
			//throw new NotImplementedException();
		}
	}
}
