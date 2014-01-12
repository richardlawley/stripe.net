using Newtonsoft.Json;
using Stripe.Infrastructure;
using System;
using Newtonsoft.Json.Linq;

namespace Stripe
{
	public class StripeApplicationFeeRefund
	{
		[JsonProperty("amount")]
		public int Amount { get; set; }

		[JsonProperty("created")]
		[JsonConverter(typeof(StripeDateTimeConverter))]
		public DateTime Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		public string BalanceTransactionId { get; private set; }
		public StripeBalanceTransaction BalanceTransaction { get; private set; }
		[JsonProperty("balance_transaction")]
		private object BalanceTransactionJson
		{
			set
			{
				if (value is JObject)
				{
					BalanceTransaction = ((JToken)value).ToObject<StripeBalanceTransaction>();
					BalanceTransactionId = BalanceTransaction.Id;
				}
				else if (value is string)
				{
					BalanceTransaction = null;
					BalanceTransactionId = (string)value;
				}
			}
		}
	}
}
