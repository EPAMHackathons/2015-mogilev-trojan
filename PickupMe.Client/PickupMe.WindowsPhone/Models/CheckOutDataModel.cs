
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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.DataForm;
using PickupMe.WindowsPhone.SampleData;

namespace PickupMe.WindowsPhone.Models
{
	public class StartTripCreationDataModel
	{
		public string Origination
		{
			get;
			set;
		}

		public string Destination
		{
			get;
			set;
		}

		public DateTime? TripDate
		{
			get;
			set;
		}

		[GenericListEditor(typeof(CountriesInfoProvider))]
		public string SearchType
		{
			get;
			set;
		}
	}
}
