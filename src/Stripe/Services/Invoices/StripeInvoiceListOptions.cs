using Newtonsoft.Json;

namespace Stripe
{
	public class StripeInvoiceListOptions : StripeListOptions
	{
		[JsonProperty("customer")]
		public string Customer { get; set; }

		[JsonProperty("date")]
		public StripeDateFilter Date { get; set; }

		public bool ExpandCustomer { get; set; }
		public bool ExpandCharge { get; set; }
	}
}