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
using PickupMe.WindowsPhone.Helpers;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace PickupMe.WindowsPhone
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			// Set the data context of the listbox control to the sample data
			DataContext = App.ViewModel;
			this.Loaded += new RoutedEventHandler(MainPage_Loaded);

			//Shows the rate reminder message, according to the settings of the RateReminder.
			(App.Current as App).rateReminder.Notify();
		}

		void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			if (!App.ViewModel.IsDataLoaded)
			{
				App.ViewModel.LoadData();
			}

			if (Vault.AuthToken == null)
			{
				this.NavigationService.Navigate(new Uri("/Views/AuthPage.xaml", UriKind.RelativeOrAbsolute));
			}
		}

		/// <summary>
		/// Navigates to about page.
		/// </summary>
		private void GoToAbout(object sender, GestureEventArgs e)
		{
			this.NavigationService.Navigate(new Uri("Views/About.xaml", UriKind.RelativeOrAbsolute));
		}
	}
}
