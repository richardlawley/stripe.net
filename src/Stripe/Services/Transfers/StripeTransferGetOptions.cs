using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stripe
{
	public class StripeTransferGetOptions 
	{
		public bool ExpandBalance_Transaction { get; set; }
	}
}
