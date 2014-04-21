using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeCharge : StripeObject
	{
		[JsonProperty("amount")]
		public int? Amount { get; set; }

		[JsonProperty("amount_refunded")]
		public int? AmountRefunded { get; set; }

		[JsonProperty("created")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("customer")]
		private object CustomerJson
		{
			set
			{
				ExpandableProperty<StripeCustomer>.Map(value, id => CustomerId = id, obj => Customer = obj);
			}
		}
		public StripeCustomer Customer { get; private set; }
		public string CustomerId { get; private set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("paid")]
		public bool? Paid { get; set; }

		[JsonProperty("refunded")]
		public bool? Refunded { get; set; }

		[JsonProperty("livemode")]
		public bool? LiveMode { get; set; }

		[JsonProperty("card")]
		public StripeCard StripeCard { get; set; }

		[JsonProperty("invoice")]
		public string InvoiceId { get; set; }

		[JsonProperty("failure_message")]
		public string FailureMessage { get; private set; }

		[JsonProperty("failure_code")]
		public string FailureCode { get; private set; }

		[JsonProperty("captured")]
		public bool? Captured { get; set; }

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }
	}
}