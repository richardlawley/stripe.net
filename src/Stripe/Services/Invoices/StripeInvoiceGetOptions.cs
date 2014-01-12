using Newtonsoft.Json;

namespace Stripe
{
	public class StripeInvoiceGetOptions 
	{
		public bool ExpandCustomer { get; set; }
		public bool ExpandCharge { get; set; }
	}
}