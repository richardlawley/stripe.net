using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Stripe.Tests.infrastructure.test_data;

namespace Stripe.Tests.infrastructure
{
	public class when_building_parameters_with_expand
	{
		private const string origurl = "http://test/foo";
		private static sample_object _testObject;
		private static string _result;

		Establish context = () =>
		{
			_testObject = new sample_object();

			_testObject.ExpandExpand1 = true;
			_testObject.ExpandExpand2 = true;
		};

		Because of = () =>
		{
			_result = ParameterBuilder.ApplyAllParameters(_testObject, origurl);
		};

		It should_contain_first_expand_item = () =>
			_result.ShouldContain("expand[]=expand1");

		It should_contain_second_expand_item = () =>
			_result.ShouldContain("expand[]=expand2");
	}
}
