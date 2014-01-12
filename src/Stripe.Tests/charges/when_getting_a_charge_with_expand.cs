using Machine.Specifications;

namespace Stripe.Tests
{
	public class when_getting_a_charge_with_expand
	{
		protected static StripeChargeCreateOptions StripeChargeCreateOptions;
		protected static StripeCharge StripeCharge;
		protected static StripeCard StripeCard;

		private static StripeChargeService _stripeChargeService;
		private static string _createdStripeChargeId;
		private static StripeChargeGetOptions _getOptions;

		Establish context = () =>
		{
			_stripeChargeService = new StripeChargeService();
			StripeChargeCreateOptions = test_data.stripe_charge_create_options.ValidCard();

			var stripeCharge = _stripeChargeService.Create(StripeChargeCreateOptions);
			_createdStripeChargeId = stripeCharge.Id;

			_getOptions = new StripeChargeGetOptions
			{
				ExpandCustomer = true,
				ExpandBalance_Transaction = true,
				ExpandInvoice = true
			};
		};

		Because of = () =>
		{
			StripeCharge = _stripeChargeService.Get(_createdStripeChargeId, _getOptions);
			StripeCard = StripeCharge.StripeCard;
		};

		It should_have_balancetransaction_object = () =>
			StripeCharge.BalanceTransaction.ShouldNotBeNull();

		It should_have_balancetransaction_id = () =>
			StripeCharge.BalanceTransactionId.ShouldEqual(StripeCharge.BalanceTransaction.Id);
	}
}