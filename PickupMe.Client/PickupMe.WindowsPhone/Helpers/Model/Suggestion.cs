using System.Collections.Generic;

namespace PickupMe.Shared.Model
{
	public class Suggestion
	{
		public IEnumerable<Prediction> Predictions { get; set; } 
	}

	public class Prediction
	{
		public string Description { get; set; }
	}
}