using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Demo.ViewModels
{
	public class HexStringToByteConverter : IValueConverter
	{
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return "0";
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null) value = "0";
			byte[] result = default(byte[]);
			try
			{
				result = GeneralMethods.HexStringToBytes(value.ToString());
			}
			catch { }
			finally { }
			return result;
		}
	}

	public class HexStringToByteConverter2 : IValueConverter
	{
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null) value = "0";
			byte[] result = default(byte[]);
			try
			{
				result = GeneralMethods.HexStringToBytes(value.ToString());
			}
			catch { }
			finally { }
			return result;
		
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return "0";
		}
	}
}
