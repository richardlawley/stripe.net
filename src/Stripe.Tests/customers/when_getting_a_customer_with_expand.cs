using System;
using Machine.Specifications;
using System.Linq;

namespace Stripe.Tests
{
	public class when_getting_a_customer_with_expand
	{
		protected static StripeCustomerCreateOptions StripeCustomerCreateOptions;
		protected static StripeCustomer StripeCustomer;
		protected static StripePlan StripePlan;
		protected static StripeCoupon StripeCoupon;

		private static StripeCustomerService _stripeCustomerService;
		private static string _createdStripeCustomerId;
		private static StripeCustomerGetOptions _getOptions;

		Establish context = () =>
		{
			var _stripePlanService = new StripePlanService();
			StripePlan = _stripePlanService.Create(test_data.stripe_plan_create_options.Valid());

			var _stripeCouponService = new StripeCouponService();
			StripeCoupon = _stripeCouponService.Create(test_data.stripe_coupon_create_options.Valid());

			_stripeCustomerService = new StripeCustomerService();
			StripeCustomerCreateOptions = test_data.stripe_customer_create_options.ValidCard(StripePlan.Id, StripeCoupon.Id, DateTime.UtcNow.AddMonths(1));

			var stripeCustomer = _stripeCustomerService.Create(StripeCustomerCreateOptions);
			_createdStripeCustomerId = stripeCustomer.Id;

			_getOptions = new StripeCustomerGetOptions { ExpandDefault_Card = true };
		};

		Because of = () =>
		{
			StripeCustomer = _stripeCustomerService.Get(_createdStripeCustomerId, _getOptions);
		};

		It should_have_default_card_expanded = () =>
			StripeCustomer.StripeDefaultCard.ShouldNotBeNull();
	}
}