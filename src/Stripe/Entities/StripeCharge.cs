using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeCharge
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("amount")]
		public int? AmountInCents { get; set; }

		[JsonProperty("amount_refunded")]
		public int? AmountInCentsRefunded { get; set; }

		[JsonProperty("created")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		public string CustomerId { get; private set; }
		public StripeCustomer Customer { get; private set; }

		[JsonProperty("customer")]
		private object CustomerJson
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

		public string InvoiceId { get; private set; }
		public StripeInvoice Invoice { get; private set; }
		private object InvoiceJson
		{
			set
			{
				if (value is JObject)
				{
					Invoice = ((JToken)value).ToObject<StripeInvoice>();
					InvoiceId = Invoice.Id;
				}
				else if (value is string)
				{
					Invoice = null;
					InvoiceId = (string)value;
				}
			}
		}

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