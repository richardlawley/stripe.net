using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeDispute
	{
		[JsonProperty("livemode")]
		public bool? LiveMode { get; set; }

		[JsonProperty("amount")]
		public int? AmountInCents { get; set; }

		public string ChargeId { get; private set; }
		public StripeCharge Charge { get; private set; }
		[JsonProperty("charge")]
		private object ChargeJson
		{
			set
			{
				if (value is JObject)
				{
					Charge = ((JToken)value).ToObject<StripeCharge>();
					ChargeId = Charge.Id;
				}
				else if (value is string)
				{
					Charge = null;
					ChargeId = (string)value;
				}
			}
		}

		[JsonProperty("created")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("evidence_due_by")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime? EvidenceDueBy { get; set; }

		[JsonProperty("reason")]
		public string Reason { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("evidence")]
		public string Evidence { get; set; }
	}
}