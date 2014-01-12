using System;
using Newtonsoft.Json;
using Stripe.Infrastructure;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Stripe
{
	public class StripeApplicationFee
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("livemode")]
		public bool? LiveMode { get; set; }

		public string AccountId { get; private set; }
		public StripeAccount Account { get; private set; }
		[JsonProperty("account")]
		private object AccountJson
		{
			set
			{
				if (value is JObject)
				{
					Account = ((JToken)value).ToObject<StripeAccount>();
					AccountId = Account.Id;
				}
				else if (value is string)
				{
					Account = null;
					AccountId = (string)value;
				}
			}
		}

		[JsonProperty("amount")]
		public int AmountInCents { get; set; }

		[JsonProperty("application")]
		public string ApplicationId { get; set; }

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
		public DateTime Created { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("refunded")]
		public bool Refunded { get; set; }

		[JsonProperty("refunds")]
		public List<StripeApplicationFeeRefund> Refunds { get; set; }

		[JsonProperty("amount_refunded")]
		public int AmountRefundedInCents { get; set; }
	}
}