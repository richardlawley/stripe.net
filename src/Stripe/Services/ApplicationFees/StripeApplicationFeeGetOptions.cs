using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stripe
{
	public class StripeApplicationFeeGetOptions 
	{
		public bool ExpandAccount { get; set; }
		public bool ExpandBalance_Transaction { get; set; }
	}
}
