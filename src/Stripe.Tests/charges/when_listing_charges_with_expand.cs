﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Stripe.Tests.charges
{
	public class when_listing_charges_with_expand
	{
		private static List<StripeCharge> _stripeChargeList;
		private static StripeCustomer _stripeCustomer;
		private static StripeChargeService _stripeChargeService;
		private static StripeChargeListOptions _listOptions;

		Establish context = () =>
		{
			var stripeCustomerService = new StripeCustomerService();
			_stripeCustomer = stripeCustomerService.Create(test_data.stripe_customer_create_options.ValidCard());

			_stripeChargeService = new StripeChargeService();
			StripeChargeCreateOptions createOptions = test_data.stripe_charge_create_options.ValidCustomer(_stripeCustomer.Id);

			_stripeChargeService.Create(createOptions);
			_stripeChargeService.Create(createOptions);

			_listOptions = new StripeChargeListOptions
			{
				Customer = _stripeCustomer.Id,
				ExpandBalance_Transaction = true,
				ExpandCustomer = true,
			};
		};

		Because of = () =>
			_stripeChargeList = _stripeChargeService.List(_listOptions).ToList();

		It should_have_balance_transaction_on_each_item = () =>
			_stripeChargeList.ShouldEachConformTo(c => c.BalanceTransaction != null);
		It should_have_customer_on_each_item = () =>
			_stripeChargeList.ShouldEachConformTo(c => c.Customer != null);
	}
}
