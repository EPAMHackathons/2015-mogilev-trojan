using System;
using Telerik.Windows.Controls;

namespace PickupMe.WindowsPhone.ViewModels
{
	public class PickupAppointment : IAppointment
	{
		public DateTime EndDate { get; set; }

		public DateTime StartDate { get; set; }

		public string Subject { get; set; }

		public string AdditionalInfo { get; set; }

		public string Id { get; set; }
	}
}