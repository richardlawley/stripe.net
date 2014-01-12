using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stripe
{
	public class StripeInvoiceItemListOptions : StripeListOptions
	{
		[JsonProperty("customer")]
		public string CustomerId { get; set; }

		[JsonProperty("created")]
		public StripeDateFilter Created { get; set; }

		public bool ExpandCustomer { get; set; }
		public bool ExpandInvoice { get; set; }
	}
}
