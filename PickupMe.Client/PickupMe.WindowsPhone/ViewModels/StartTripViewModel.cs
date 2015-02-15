using System;
using System.Collections.Generic;
using System.Linq;
using PickupMe.Shared.Model;
using PickupMe.WindowsPhone.Commands;
using SmartNavigation;
using Telerik.Windows.Controls;

namespace PickupMe.WindowsPhone.ViewModels
{
	public class StartTripViewModel : ViewModelBase
	{
		private DateTime _date = DateTime.Now;
		private string _destination;
		private string _origination;
		private string _searchType;
		private Car _selectedCar;
		private int _sits = 1;

		private IEnumerable<Car> _userCars = new List<Car>
		{
			new Car
			{
				Id = "1",
				Make = "atest1",
				Model = "otest1",
			},
			new Car
			{
				Id = "1",
				Make = "atest2",
				Model = "otest2",
			}
		};

		public IEnumerable<string> TripTypes
		{
			get { return new List<string> { "Passenger", "Driver", "Package" }; }
		}

		public string SearchType
		{
			get
			{
				return _searchType;
			}
			set
			{
				_searchType = value;
				OnPropertyChanged("SearchType");
			}
		}

		public string Origination
		{
			get { return _origination; }
			set
			{
				_origination = value;
				OnPropertyChanged("Origination");
			}
		}

		public string Destination
		{
			get { return _destination; }
			set
			{
				_destination = value;
				OnPropertyChanged("Destination");
			}
		}

		public DateTime Date
		{
			get { return _date; }
			set
			{
				_date = value;
				OnPropertyChanged("Date");
			}
		}

		public int Sits
		{
			get { return _sits; }
			set
			{
				_sits = value;
				OnPropertyChanged("Sits");
			}
		}

		public string ButtonText
		{
			get
			{
				switch (_searchType)
				{
					case "Driver":
						return "Create trip";
					case "Passenger":
						return "Search for driver";
					case "Package":
						return "Search for driver";
					default:
						return "Search";
				}

				return "Search";
			}
		}

		public bool IsSelectCarVisible
		{
			get
			{
				return _searchType == "Driver";
			}
		}

		public Car SelectedCar
		{
			get
			{
				return _selectedCar;
			}
			set
			{
				_selectedCar = value;
				OnPropertyChanged("SelectedCar");
			}
		}

		public IEnumerable<Car> UserCars
		{
			get { return _userCars; }
			set
			{
				_userCars = value;
				OnPropertyChanged("UserCars");
			}
		}

		public RelayCommand SubmitCommand
		{
			get
			{
				return new RelayCommand(() =>
					{
						if (_searchType == "Driver")
						{
							return;
						}

						SmartNavigationService.Current.Navigate<TripDetailsViewModel>(
							"/Views/TripDetails.xaml",
							t => t.Init(this._origination, this._destination, this._searchType, null));
					});
			}
		}
	}

}