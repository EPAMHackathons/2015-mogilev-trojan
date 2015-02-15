using System.Collections.Generic;
using System.Threading.Tasks;
using PickupMe.Shared.Model;
using System.Net.Http;
using PickupMe.WindowsPhone.Helpers;

namespace PickupMe.Shared.Controllers
{
	public class UserController
	{
		private static HttpClient client = new HttpClient();

		public UserController()
		{
			client.DefaultRequestHeaders.Add("PickUpMe-UserToken", Vault.UserId);
			client.DefaultRequestHeaders.Add("PickUpMe-UserTokenSource", "vk");
		}

		public Task<User> GetProfile()
		{
			string query = string.Format("http://epam.azurewebsites.net/api/user");
			var resp = client.GetAsync(query).Result;
			return resp.Content.ReadAsAsync<User>();
		}
	}
}