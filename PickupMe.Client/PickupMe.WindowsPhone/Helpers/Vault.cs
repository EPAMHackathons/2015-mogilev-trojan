namespace PickupMe.WindowsPhone.Helpers
{
	public class Vault
	{
		private static string _authToken = null;
		private static string _userId = null;

		public static string AuthToken
		{
			get
			{
				return _authToken;
			}
			set
			{
				if (_authToken == null)
				{
					_authToken = value;
				}
			}
		}

		public static string UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				if (_userId == null)
				{
					_userId = value;
				}
			}
		}

	}
}