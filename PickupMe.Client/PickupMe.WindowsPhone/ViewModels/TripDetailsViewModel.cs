using System;
using System.ComponentModel;
using System.Windows.Navigation;
using PickupMe.WindowsPhone.Models;
using SmartNavigation;

namespace PickupMe.WindowsPhone.ViewModels
{
	public class TripDetailsViewModel : INotifyPropertyChanged
	{
		[OnNavigatedTo]
		public void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		[OnNavigatingFrom]
		public void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public StartTripCreationDataModel DataModel { get; set; }

		public void Init()
		{
		}

		private void NotifyPropertyChanged(String propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (null != handler)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}