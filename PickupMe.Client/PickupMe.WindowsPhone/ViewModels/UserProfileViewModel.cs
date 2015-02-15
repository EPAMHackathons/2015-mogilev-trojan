using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using PickupMe.Shared.Controllers;
using PickupMe.WindowsPhone.Helpers;
using Telerik.Windows.Controls;

namespace PickupMe.WindowsPhone.ViewModels
{
	public class UserProfileViewModel : ViewModelBase
	{
		private string DefaultUserId = "4";
		private PersonViewModel conversationBuddy;
		private int currentGroup;
		private ObservableCollection<ProfileMessage> messages;
		private ObservableCollection<PersonViewModel> people;
		private ProfileMessage previousMessage;
		private PersonViewModel you;
		private UserController userController;

		public UserProfileViewModel()
		{
			//var user = userController.GetProfile();
		}

		public PersonViewModel You
		{
			get { return you; }
			set
			{
				you = value;
				OnPropertyChanged("You");
			}
		}

		public PersonViewModel ConversationBuddy
		{
			get { return conversationBuddy; }
			set
			{
				conversationBuddy = value;
				OnPropertyChanged("ConversationBuddy");
			}
		}

		public ObservableCollection<ProfileMessage> Messages
		{
			get
			{
				if (messages == null)
				{
					InitializeMessages();
				}
				return messages;
			}
			private set { messages = value; }
		}

		public ObservableCollection<PersonViewModel> People
		{
			get
			{
				if (people == null)
				{
					InitializePeople();
				}
				return people;
			}
			private set { people = value; }
		}

		private void InitializeMessages()
		{
			messages = new ObservableCollection<ProfileMessage>();
			messages.CollectionChanged += OnMessagesCollectionChanged;
			for (int i = 1; i <= 4; i++)
			{
				ProfileMessage message;
				message = new ProfileMessage("Message" + (i*3 - 2),
					DateTime.Now.AddMinutes(-5 + i),
					ConversationViewMessageType.Outgoing,
					You != null ? You.PersonId : Vault.UserId);
				messages.Add(message);
				message = new ProfileMessage("Message" + (i*3 - 1), DateTime.Now.AddMinutes(-5 + i),
					ConversationViewMessageType.Incoming, i.ToString());
				messages.Add(message);
				message = new ProfileMessage("Message" + (i*3), DateTime.Now.AddMinutes(-5 + i),
					ConversationViewMessageType.Incoming, i.ToString());
				messages.Add(message);
			}
		}

		private void OnMessagesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems == null)
			{
				return;
			}
			var message = e.NewItems[0] as ProfileMessage;
			if (previousMessage != null)
			{
				if (previousMessage.SenderId != message.SenderId)
				{
					currentGroup++;
				}
			}
			if (message.Group == null)
			{
				message.Group = currentGroup;
			}
			previousMessage = message;
		}

		private void InitializePeople()
		{
			people = new ObservableCollection<PersonViewModel>();

			for (int i = 1; i <= 5; i++)
			{
				var personViewModel = new PersonViewModel
				{
					PersonId = i.ToString(),
					Name = "PERSON " + i,
					Picture = new Uri("Images/FrameThumbnail.png", UriKind.RelativeOrAbsolute)
				};
				people.Add(personViewModel);
			}
		}
	}
}