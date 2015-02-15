using System;
using PickupMe.WindowsPhone.SampleData;
using Telerik.Windows.Controls.DataForm;

namespace PickupMe.WindowsPhone.Models
{
	public class StartTripCreationDataModel
	{
		public string Origination { get; set; }

		public string Destination { get; set; }

		public DateTime? TripDate { get; set; }

		[GenericListEditor(typeof (CountriesInfoProvider))]
		public string SearchType { get; set; }
	}
}