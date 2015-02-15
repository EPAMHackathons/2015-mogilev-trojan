
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PickupMe.WindowsPhone.ViewModels;
using SmartNavigation;
using Telerik.Windows.Controls;

namespace PickupMe.WindowsPhone
{
	public partial class UserCars : UserControl
	{
		public UserCars()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SmartNavigationService.Current.Navigate<CreateCarViewModel>("/Views/CreateCar.xaml", t => t.Init());
		}
	}
}
