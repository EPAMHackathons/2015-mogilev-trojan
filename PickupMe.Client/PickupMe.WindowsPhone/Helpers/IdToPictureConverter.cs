
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using PickupMe.WindowsPhone.ViewModels;

namespace PickupMe.WindowsPhone.Helpers
{
	public class IdToPictureConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int id = int.Parse(value.ToString());
			UserProfileViewModel viewModel = new UserProfileViewModel();
			foreach (PersonViewModel person in viewModel.People)
			{
				
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
