using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PickupMe.Shared.Model;

namespace PickupMe.Shared.Controllers
{
	public class SuggestionController
	{
		private static HttpClient client = new HttpClient();

		public async Task<IEnumerable<string>> GetSuggestions(string input)
		{
			if (input.Length > 2)
			{
				var query =
					string.Format(
						"https://maps.googleapis.com/maps/api/place/autocomplete/json?input={0}&types=geocode&language=ru&sensor=false&key=AIzaSyBxsGBUa2QPx1GMrldH8Mpqbbq5aJjohrU",
						input);

				var resp = client.GetAsync(query).Result;
				//Suggestion prediction = await resp.Content.ReadAsAsync<Suggestion>();
				//return prediction.Predictions.Select(t => t.Description);

				return new List<string> { "asd", "asd" };
			}

			return new List<string> {"asd", "asd"};
		}
	}
}