using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stripe
{
	public class StripeInvoiceItemGetOptions 
	{
		public bool ExpandCustomer { get; set; }
		public bool ExpandInvoice { get; set; }
	}
}
