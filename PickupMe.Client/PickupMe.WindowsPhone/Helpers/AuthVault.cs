namespace PickupMe.WindowsPhone.Helpers
{
	public class AuthVault
	{
		private static string _authToken = null;

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
	}
}