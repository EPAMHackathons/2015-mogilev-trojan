using System;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace PickupMe.WindowsPhone.ViewModels
{
	public class ProfileMessage : ConversationViewMessage, IComparable
	{
		public ProfileMessage(string text, DateTime timeStamp, ConversationViewMessageType type, string senderId, int? group = null)
			: base(text, timeStamp, type)
		{
			this.SenderId = senderId;
			this.Group = group;
		}

		public string SenderId
		{
			get;
			private set;
		}

		public int? Group
		{
			get;
			set;
		}

		public SolidColorBrush MessageBackground
		{
			get
			{
				int id = int.Parse(this.SenderId) % 6;
				switch (id)
				{
					case 0: return new SolidColorBrush(Color.FromArgb(255, 51, 153, 51));
					case 1: return new SolidColorBrush(Color.FromArgb(255, 27, 161, 226));
					case 2: return new SolidColorBrush(Color.FromArgb(255, 255, 0, 151));
					case 3: return new SolidColorBrush(Color.FromArgb(255, 240, 150, 9));
					case 4: return new SolidColorBrush(Color.FromArgb(255, 0, 171, 169));
					case 5: return new SolidColorBrush(Color.FromArgb(255, 140, 191, 38));
				}
				return App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush;
			}
		}

		public string FormattedTimeStamp
		{
			get
			{
				return this.TimeStamp.ToShortTimeString();
			}
		}

		public override bool Equals(object obj)
		{
			ProfileMessage secondMessage = obj as ProfileMessage;

			if (obj is DataGroup)
			{
				secondMessage = (obj as DataGroup).Key as ProfileMessage;
			}

			return this.Group == secondMessage.Group;
		}

		public override int GetHashCode()
		{
			return this.Group.GetHashCode();
		}

		public int CompareTo(object obj)
		{
			ProfileMessage targetMessage = obj as ProfileMessage;

			if (targetMessage != null)
			{
				return this.Group > targetMessage.Group ? 1 : this.Group == targetMessage.Group ? 0 : -1;
			}

			if (obj is DataGroup)
			{
				targetMessage = (obj as DataGroup).Key as ProfileMessage;

				return this.Group > targetMessage.Group ? 1 : this.Group == targetMessage.Group ? 0 : -1;
			}

			return 0;
		}
	}
}