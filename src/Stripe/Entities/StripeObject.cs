using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stripe
{
	public abstract class StripeObject
	{
		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
