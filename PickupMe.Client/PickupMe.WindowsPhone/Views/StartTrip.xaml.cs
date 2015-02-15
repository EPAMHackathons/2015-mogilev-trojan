
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PickupMe.Shared.Model;
using PickupMe.WindowsPhone.ViewModels;
using SmartNavigation;
using Telerik.Windows.Controls;

namespace PickupMe.WindowsPhone
{
	public partial class StartTrip : UserControl
	{
		WebServiceAutoCompleteProvider webServiceProviderOrigin = new WebServiceAutoCompleteProvider();
		WebServiceAutoCompleteProvider webServiceProviderDestination = new WebServiceAutoCompleteProvider();

		public StartTrip()
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
	}
}
