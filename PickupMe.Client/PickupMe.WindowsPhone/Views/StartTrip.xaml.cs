
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using SmartNavigation;

namespace PickupMe.WindowsPhone
{
	public partial class StartTrip : UserControl
	{
		public StartTrip()
		{
			InitializeComponent();
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			this.DataForm.Commit();
			//SmartNavigationService.Current.Navigate("/Views/TripDetails.xaml");
		}
	}
}
