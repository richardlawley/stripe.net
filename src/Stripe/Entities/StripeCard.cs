﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stripe
{
	public class StripeCard
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("address_country")]
		public string AddressCountry { get; set; }

		[JsonProperty("address_city")]
		public string AddressCity { get; set; }

		[JsonProperty("address_state")]
		public string AddressState { get; set; }

		[JsonProperty("address_zip")]
		public string AddressZip { get; set; }

		[JsonProperty("address_zip_check")]
		public string AddressZipCheck { get; set; }

		[JsonProperty("address_line1")]
		public string AddressLine1 { get; set; }

		[JsonProperty("address_line1_check")]
		public string AddressLine1Check { get; set; }

		[JsonProperty("address_line2")]
		public string AddressLine2 { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("cvc_check")]
		public string CvcCheck { get; set; }

		[JsonProperty("exp_month")]
		public string ExpirationMonth { get; set; }

		[JsonProperty("exp_year")]
		public string ExpirationYear { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("last4")]
		public string Last4 { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("fingerprint")]
		public string Fingerprint { get; set; }

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