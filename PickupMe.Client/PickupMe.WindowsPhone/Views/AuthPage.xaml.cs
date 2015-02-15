using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Windows.Security.Authentication.Web;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PickupMe.WindowsPhone.Helpers;

namespace PickupMe.WindowsPhone.Views
{
	public partial class AuthPage : PhoneApplicationPage
	{
		#region OAuth
		public static string AuthorizationUrl
		{
			get
			{
				return "https://oauth.vk.com/authorize?client_id=4782857&redirect_uri=http://api.vk.com/blank.html&display=wap&scope=9999999&response_type=token";
			}
		}

		public static async void OAuthVk()
		{
			const string vkUri = "https://oauth.vk.com/authorize?client_id=3881112&scope=9999999&" +
									"redirect_uri=http://oauth.vk.com/blank.html&display=touch&response_type=token";
			Uri requestUri = new Uri(vkUri);
			Uri callbackUri = new Uri("http://oauth.vk.com/blank.html");

			WebAuthenticationResult result = await WebAuthenticationBroker.AuthenticateAsync(
				WebAuthenticationOptions.None, requestUri, callbackUri);

			switch (result.ResponseStatus)
			{
				case WebAuthenticationStatus.ErrorHttp:
					MessageBox.Show("Не удалось открыть страницу сервиса Попробуйте войти в приложения позже!");
					break;
				case WebAuthenticationStatus.Success:
					string responseString = result.ResponseData;
					MessageBox.Show(responseString);
					break;
			}
		}

		#endregion

		public AuthPage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			AuthBrowser.Navigate(new Uri(AuthorizationUrl));
		}

		private void AuthBrowser_OnLoadCompleted(object sender, NavigationEventArgs e)
		{
			string responceData = e.Uri.OriginalString;
			if (responceData.Contains("access_token"))
			{
				var parameters = responceData.Split('#')[1].Split('&');
				var accessToken = parameters[0].Substring(parameters[0].IndexOf("=", StringComparison.Ordinal)).Remove(0, 1);
				var userId = parameters[0].Substring(parameters[2].IndexOf("=", StringComparison.Ordinal)).Remove(0, 1);
				Vault.AuthToken = accessToken;
				Vault.UserId = userId;
				NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
			}
		}
	}
}