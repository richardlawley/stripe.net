using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeDiscount
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		
		[JsonProperty("start")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? Start { get; set; }

		[JsonProperty("end")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? End { get; set; }

		[JsonProperty("coupon")]
		public StripeCoupon StripeCoupon { get; set; }

		public string CustomerId { get; private set; }
		public StripeCustomer Customer { get; private set; }
		[JsonProperty("customer")]
		public object CustomerJson
		{
			set
			{
				if (value is JObject)
				{
					Customer = ((JToken)value).ToObject<StripeCustomer>();
					CustomerId = Customer.Id;
				}
				else if (value is string)
				{
					Customer = null;
					CustomerId = (string)value;
				}
			}
		}
	}
}
