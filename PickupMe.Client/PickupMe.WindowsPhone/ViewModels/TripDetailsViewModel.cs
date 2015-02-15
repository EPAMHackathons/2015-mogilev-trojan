using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Device.Location;
using System.Windows.Navigation;
using PickupMe.WindowsPhone.Commands;
using SmartNavigation;

namespace PickupMe.WindowsPhone.ViewModels
{
	public class TripDetailsViewModel : INotifyPropertyChanged
	{
		private string _destination;
		private string _origination;
		private ObservableCollection<SmallTripDetailViewModel> items;

		public string Origination
		{
			get { return _origination; }
			set
			{
				NotifyPropertyChanged("Origination");
				_origination = value;
			}
		}

		public string Destination
		{
			get { return _destination; }
			set
			{
				NotifyPropertyChanged("Destination");
				_destination = value;
			}
		}

		public GeoCoordinate GeoCoordinate
		{
			get { return new GeoCoordinate(47.60097, -122.3331); }
		}

		public ObservableCollection<string> SugestedOrigination { get; set; }

		public ObservableCollection<string> SugestedDestination { get; set; }

		public ObservableCollection<SmallTripDetailViewModel> Items
		{
			get
			{
				if (items == null)
				{
					InitializeItems();
				}
				return items;
			}
			private set { items = value; }
		}

		public string Address
		{
			get { return "Address"; }
		}

		public RelayCommand SearchTrips {
			get
			{
				return new RelayCommand(() =>
				{

				});
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		[OnNavigatedTo]
		public void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		[OnNavigatingFrom]
		public void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
		}

		private void InitializeItems()
		{
			items = new ObservableCollection<SmallTripDetailViewModel>();
			for (int i = 1; i <= 7; i++)
			{
				items.Add(new SmallTripDetailViewModel
				{
					ImageSource = new Uri("Images/Frame.png", UriKind.RelativeOrAbsolute),
					ImageThumbnailSource = new Uri("Images/FrameThumbnail.png", UriKind.RelativeOrAbsolute),
					Title = "Title " + i,
					Information = "Information " + i,
					Group = (i % 2 == 0) ? "EVEN" : "ODD"
				});
			}
		}

		public void Init(string origination, string destination, string type, string id)
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