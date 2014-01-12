using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeSubscription
	{
		[JsonProperty("id")]
		public string Id { get; set; }

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

		[JsonProperty("current_period_start")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? PeriodStart { get; set; }

		[JsonProperty("current_period_end")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? PeriodEnd { get; set; }

		[JsonProperty("start")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? Start { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("application_fee_percent")]
		public decimal? ApplicationFeePercent { get; set; }

		[JsonProperty("canceled_at")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? CanceledAt { get; set; }

		[JsonProperty("ended_at")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? EndedAt { get; set; }

		[JsonProperty("trial_start")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? TrialStart { get; set; }

		[JsonProperty("trial_end")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? TrialEnd { get; set; }

		[JsonProperty("quantity")]
		public int Quantity { get; set; }

		[JsonProperty("plan")]
		public StripePlan StripePlan { get; set; }

		[JsonProperty("cancel_at_period_end")]
		public bool CancelAtPeriodEnd { get; set; }
	}
}