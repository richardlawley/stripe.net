using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeInvoiceItem
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("amount")]
		public int? AmountInCents { get; set; }

		[JsonProperty("date")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Date { get; set; }

		[JsonProperty("proration")]
		public bool Proration { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

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
		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("quantity")]
		public int? Quantity { get; set; }

		[JsonProperty("plan")]
		public StripePlan Plan { get; set; }

		[JsonProperty("period")]
		public StripePeriod Period { get; set; }

		public string InvoiceId { get; private set; }
		public StripeInvoice Invoice { get; private set; }
		[JsonProperty("invoice")]
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

		[JsonProperty("metadata")]
		public Dictionary<string, string> Metadata { get; set; }
	}
}
