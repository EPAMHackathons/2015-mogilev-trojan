
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using PickupMe.WindowsPhone.Helpers;
using PickupMe.WindowsPhone.ViewModels;

namespace PickupMe.WindowsPhone
{
	public partial class UserProfile : UserControl
	{
		public UserProfile()
		{
			InitializeComponent();
			this.SetConversationParticipants();
			this.SetGroupDescriptors();
		}

		private void OnSendingMessage(object sender, ConversationViewMessageEventArgs e)
		{
			if (string.IsNullOrEmpty((e.Message as ConversationViewMessage).Text))
			{
				return;
			}
			ConversationViewMessage originalMessage = e.Message as ConversationViewMessage;
			UserProfileViewModel viewModel = this.DataContext as UserProfileViewModel;
			ProfileMessage previousMessage = viewModel.Messages.Last();
			int group = previousMessage.Group.HasValue ? previousMessage.Group.Value : 0;
			if (previousMessage.SenderId != viewModel.You.PersonId)
			{
				group++;
			}
			ProfileMessage profileMessage = new ProfileMessage(originalMessage.Text, originalMessage.TimeStamp, originalMessage.Type, viewModel.You.PersonId, group);
			viewModel.Messages.Add(profileMessage);
		}

		private void SetConversationParticipants()
		{
			UserProfileViewModel viewModel = this.DataContext as UserProfileViewModel;
			viewModel.ConversationBuddy = viewModel.People[0];
			viewModel.You = viewModel.People[4];
		}

		private void SetGroupDescriptors()
		{
			this.conversationView.GroupDescriptors = new DataDescriptor[] 
            { 
                new GenericGroupDescriptor<ProfileMessage, ProfileMessage>(message => message)
            };
		}
	}
}
