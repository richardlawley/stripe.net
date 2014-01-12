using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Stripe.Tests.customers
{
	public class when_listing_customers_with_expand
	{
		private static List<StripeCustomer> _stripeCustomerList;
		private static StripeCustomerService _stripeCustomerService;
		private static StripeCustomerListOptions _listOptions;

		Establish context = () =>
		{
			_stripeCustomerService = new StripeCustomerService();

			_stripeCustomerService.Create(test_data.stripe_customer_create_options.ValidCard());

			_listOptions = new StripeCustomerListOptions { ExpandDefault_Card = true };
		};

		Because of = () =>
			_stripeCustomerList = _stripeCustomerService.List(_listOptions).ToList();

		It should_have_card_populated = () =>
			_stripeCustomerList.First().StripeDefaultCard.ShouldNotBeNull();
	}
}
