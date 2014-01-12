using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stripe.Tests.infrastructure.test_data
{
	public class sample_list_object : StripeListOptions
	{
		public bool ExpandExpand1 { get; set; }
		public bool ExpandExpand2 { get; set; }
	}
}
