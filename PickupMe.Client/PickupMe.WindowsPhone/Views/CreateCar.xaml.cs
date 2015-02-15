
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

namespace PickupMe.WindowsPhone
{
	public partial class CreateCar : PhoneApplicationPage
	{
		public CreateCar()
		{
			InitializeComponent();
		}

		private void SignUp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
		{
			this.NavigationService.Navigate(new Uri("/SignUp.xaml", UriKind.RelativeOrAbsolute));
		}
	}
}
