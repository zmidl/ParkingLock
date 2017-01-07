using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Demo.ViewModels
{
	public class ByteStringToByteConverter : IValueConverter
	{
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			byte result = 0x00;
			try
			{
				result = byte.Parse(value.ToString());
			}
			catch { }
			return result;
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			byte result = 0x00;
			try
			{
				result = byte.Parse(value.ToString());
			}
			catch { }
			return result;
		}
	}
}
