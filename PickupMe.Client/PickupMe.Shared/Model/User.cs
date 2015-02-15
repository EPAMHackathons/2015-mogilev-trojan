using System.Collections.Generic;

namespace PickupMe.Shared.Model
{
	public class User
	{
		public string Id { get; set; }
		public string Token { get; set; }
		public string Source { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string AvatarUri { get; set; }
		public IEnumerable<Car> Cars { get; set; }
	}
}