using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stripe
{
	public class StripeChargeGetOptions
	{
		public bool ExpandBalance_Transaction { get; set; }
		public bool ExpandCustomer { get; set; }
		public bool ExpandInvoice { get; set; }
	}
}
