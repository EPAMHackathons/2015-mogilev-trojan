using System;
using Telerik.Windows.Controls;

namespace PickupMe.WindowsPhone.ViewModels
{
	public class PersonViewModel : ViewModelBase
	{
		private string personId;
		private string name;
		private Uri picture;

		public string PersonId
		{
			get
			{
				return this.personId;
			}
			set
			{
				if (this.personId != value)
				{
					this.personId = value;
					this.OnPropertyChanged("PersonId");
				}
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (this.name != value)
				{
					this.name = value;
					this.OnPropertyChanged("Name");
				}
			}
		}

		public Uri Picture
		{
			get
			{
				return this.picture;
			}
			set
			{
				if (this.picture != value)
				{
					this.picture = value;
					this.OnPropertyChanged("Picture");
				}
			}
		}
	}
}