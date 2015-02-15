using System;
using System.Collections.Generic;

namespace PickupMe.Shared.Model
{
	public class Trip
	{
		public string Origination { get; set; }
		public string Destination { get; set; }
		public DateTime DateTime { get; set; }
		public Car Car { get; set; }
		public User Driver { get; set; }
		public bool IsDriver { get; set; }
		public IEnumerable<User> Passengers { get; set; }
		public string State { get; set; }
		public string RepeatedState { get; set; }
	}
}