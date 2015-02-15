using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PickupMe.Shared.Controllers;
using PickupMe.Shared.Model;
using Telerik.Windows.Controls;

namespace PickupMe.WindowsPhone
{
	public partial class TripDetails : PhoneApplicationPage
	{
		WebServiceAutoCompleteProvider webServiceProviderOrigin = new WebServiceAutoCompleteProvider();
		WebServiceAutoCompleteProvider webServiceProviderDestination = new WebServiceAutoCompleteProvider();

		public TripDetails()
		{
			InitializeComponent();
			webServiceProviderOrigin.InputChanged += this.webServiceProviderOrigin_InputChanged;
			webServiceProviderDestination.InputChanged += this.webServiceProviderDestination_InputChanged;
			this.radAutoCompleteOrigin.InitSuggestionsProvider(webServiceProviderOrigin);
			this.radAutoCompleteDestination.InitSuggestionsProvider(webServiceProviderDestination);
		}

		private void webServiceProviderOrigin_InputChanged(object sender, EventArgs e)
		{
			HttpClient client = new HttpClient();
			var query =
					string.Format(
						"https://maps.googleapis.com/maps/api/place/autocomplete/json?input={0}&types=geocode&language=ru&sensor=true&key=AIzaSyBxsGBUa2QPx1GMrldH8Mpqbbq5aJjohrU",
						this.radAutoCompleteOrigin.Text);

			var awaiter = client.GetAsync(query).GetAwaiter();
			awaiter.OnCompleted(() =>
			{
				if (awaiter.IsCompleted)
				{
					var result = awaiter.GetResult().Content.ReadAsAsync<Suggestion>();
					this.webServiceProviderOrigin.LoadSuggestions(result.Result.Predictions.Select(t => t.Description));
				}
			});
		}

		private void webServiceProviderDestination_InputChanged(object sender, EventArgs e)
		{
			HttpClient client = new HttpClient();
			var query =
					string.Format(
						"https://maps.googleapis.com/maps/api/place/autocomplete/json?input={0}&types=geocode&language=ru&sensor=true&key=AIzaSyBxsGBUa2QPx1GMrldH8Mpqbbq5aJjohrU",
						this.radAutoCompleteDestination.Text);

			var awaiter = client.GetAsync(query).GetAwaiter();
			awaiter.OnCompleted(() =>
			{
				if (awaiter.IsCompleted)
				{
					var result = awaiter.GetResult().Content.ReadAsAsync<Suggestion>();
					this.webServiceProviderDestination.LoadSuggestions(result.Result.Predictions.Select(t => t.Description));
				}
			});
		}

		private void RadAutoComplete_GotFocus(object sender, RoutedEventArgs e)
		{
		}

		private void RadAutoComplete_LostFocus(object sender, RoutedEventArgs e)
		{
		}

	}
}